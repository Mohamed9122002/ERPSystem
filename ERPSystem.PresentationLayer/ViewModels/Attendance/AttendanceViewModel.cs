using ERPSystem.DataAccessLayer.Modules.HR.enums;

namespace ERPSystem.PresentationLayer.ViewModels.Attendance
{
    public class AttendanceViewModel
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public AttendanceStatus Status { get; set; }
    }
}
