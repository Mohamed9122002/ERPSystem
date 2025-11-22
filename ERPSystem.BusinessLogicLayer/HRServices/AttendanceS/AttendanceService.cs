using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.AttendanceDtos;
using ERPSystem.BusinessLogicLayer.Specifications;
using ERPSystem.DataAccessLayer.Modules.HR;
using ERPSystem.DataAccessLayer.Modules.HR.enums;
using ERPSystem.DataAccessLayer.Repositories.RepositorieyGeneric;
using ERPSystem.DataAccessLayer.Repositories.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.HRServices.AttendanceS
{
    public class AttendanceService(IUnitOfWork unitOfWork, IMapper mapper) : IAttendanceService
    {
        IGenericRepository<Attendance, int> repository = unitOfWork.CreateGenericRepository<Attendance, int>();

        public async Task<int> CreateAttendanceAsync(CreateAttendanceDto attendanceDto)
        {
            var attendance = mapper.Map<Attendance>(attendanceDto);
            await repository.AddAsync(attendance);
            return await unitOfWork.SaveChangeAsync();
        }
        public async Task<int> UpdateAttendanceAsync(UpdateAttendanceDto attendanceDto)
        {
            var attendance = mapper.Map<Attendance>(attendanceDto);
            repository.Update(attendance);
            return await unitOfWork.SaveChangeAsync();
        }

        public async Task<bool> DeleteAttendanceAsync(int id)
        {
            var attendance = await repository.GetByIdAsync(id);
            if (attendance is null)
                throw new Exception($"Attendance {id} not found.");
            repository.Remove(attendance);
            var result = await unitOfWork.SaveChangeAsync();
            return result > 0 ? true : false;
        }

        public async Task<IEnumerable<AttendanceListDto>> GetAllAttendanceAsync()
        {
            var spec = new AttendanceWithEmployeeSpecification();
            var attendances = await repository.GetAllAsync(spec);
            var attendanceDtos = mapper.Map<IEnumerable<AttendanceListDto>>(attendances);
            return attendanceDtos;
        }

        public async Task<AttendanceDetailsDto?> GetAttendanceByIdAsync(int id)
        {
            var spec = new AttendanceWithEmployeeSpecification(id);
            var attendance = await repository.GetByIdAsync(spec);
            if (attendance is null)
                return null;
            var attendanceDto = mapper.Map<AttendanceDetailsDto>(attendance);
            return attendanceDto;
        }

        public async Task<Attendance> CheckInAsync(int attendanceId)
        {
            var today = DateTime.Today;
            var attandance = await repository.GetByIdAsync(attendanceId);
            if (attandance is null)
            {
                attandance = new Attendance
                {
                    EmployeeId = attendanceId,
                    Date = today,
                    CheckIn = DateTime.Now,
                    Status = AttendanceStatus.Present
                };
                await repository.AddAsync(attandance);
            }
            else
            {
                if (attandance.CheckIn != null)
                {
                    throw new Exception("You already checked in today.");
                }
                attandance.CheckIn = DateTime.Now;
                attandance.Status = AttendanceStatus.Present;
                repository.Update(attandance);
            }
            await unitOfWork.SaveChangeAsync();
            return attandance;
        }

        public async Task<Attendance> CheckOutAsync(int attendanceId)
        {
            var attendance = await repository.GetByIdAsync(attendanceId);

            if (attendance == null)
                throw new Exception("Attendance record not found.");

            if (!attendance.CheckIn.HasValue)
                throw new Exception("You have not checked in today.");

            if (attendance.CheckOut.HasValue)
                throw new Exception("You have already checked out today.");

            attendance.CheckOut = DateTime.Now;

            var totalHours = (attendance.CheckOut.Value - attendance.CheckIn.Value).TotalHours;
            attendance.Status = totalHours >= 8 ? AttendanceStatus.Present : AttendanceStatus.Late;

            repository.Update(attendance);
            await unitOfWork.SaveChangeAsync();

            return attendance;
        }
    }
}
