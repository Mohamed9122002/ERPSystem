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
        IGenericRepository<Employee, int> repositoryEmployee = unitOfWork.CreateGenericRepository<Employee, int>();

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

        public async Task<Attendance> CheckInAsync(int employeeId)
        {
            var today = DateTime.Today;
            var employee = await repositoryEmployee.GetByIdAsync(employeeId) ?? throw new Exception("Employee not found");
            var attendance = (await repository.GetAllAsync()).FirstOrDefault(a => a.EmployeeId == employeeId && a.Date.Date == today);
            ;
            if (attendance is not null)
            {
                if (attendance.CheckIn.HasValue)
                    throw new Exception("You already checked in today.");

                attendance.CheckIn = DateTime.Now;
                attendance.Status = AttendanceStatus.Present;
                repository.Update(attendance);
            }
            else
            {

                attendance = new Attendance
                {
                    EmployeeId = employeeId,
                    Date = today,
                    CheckIn = DateTime.Now,
                    Status = AttendanceStatus.Present,
                    IsAbsent = false,
                    LateHours = 0,
                    OvertimeHours = 0,
                    WorkingHours = 0
                };
                await repository.AddAsync(attendance);
            }
            await unitOfWork.SaveChangeAsync();
            return attendance;
        }

        public async Task<Attendance> CheckOutAsync(int attendanceId)
        {
            var today = DateTime.Today;
            var attendance = await repository.GetByIdAsync(attendanceId) ?? throw new Exception("Attendance record not found.");
            if (!attendance.CheckIn.HasValue)
                throw new Exception("You have not checked in today.");

            if (attendance.CheckOut.HasValue)
                throw new Exception("You have already checked out today.");

            attendance.CheckOut = DateTime.Now;
            attendance.WorkingHours = (decimal)(attendance.CheckOut.Value - attendance.CheckIn.Value).TotalHours;
            var shiftStart = new DateTime(attendance.Date.Year, attendance.Date.Month, attendance.Date.Day, 9, 0, 0);
            var shiftEnd = new DateTime(attendance.Date.Year, attendance.Date.Month, attendance.Date.Day, 17, 0, 0);

            // حساب Late
            attendance.LateHours = attendance.CheckIn > shiftStart
                ? (decimal)(attendance.CheckIn.Value - shiftStart).TotalHours
                : 0;
            attendance.OvertimeHours = attendance.CheckOut > shiftEnd
                ? (decimal)(attendance.CheckOut.Value - shiftEnd).TotalHours
                : 0;
            attendance.Status = attendance.WorkingHours >= 8 ? AttendanceStatus.Present : AttendanceStatus.Late;
            attendance.IsAbsent = attendance.CheckIn == null;
            repository.Update(attendance);
            await unitOfWork.SaveChangeAsync();
            return attendance;

        }
    }
}


