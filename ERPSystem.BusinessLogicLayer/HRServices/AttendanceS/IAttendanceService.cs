using ERPSystem.BusinessLogicLayer.DataTransferObject.AttendanceDtos;
using ERPSystem.DataAccessLayer.Modules.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.HRServices.AttendanceS
{
    public interface IAttendanceService
    {
        Task<int> CreateAttendanceAsync(CreateAttendanceDto attendanceDto);
        Task<int> UpdateAttendanceAsync(UpdateAttendanceDto attendanceDto);
        Task<bool> DeleteAttendanceAsync(int id);
        Task<AttendanceDetailsDto?> GetAttendanceByIdAsync(int id);
        Task<IEnumerable<AttendanceListDto>> GetAllAttendanceAsync();
        Task<Attendance> CheckInAsync(int attendanceIdId);
        Task<Attendance> CheckOutAsync(int attendanceId);

    }
}
