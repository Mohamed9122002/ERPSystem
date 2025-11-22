namespace ERPSystem.PresentationLayer.ViewModels.Attendance
{
    public class AttendanceViewModel
    {
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; } = DateTime.Today;
        public DateTime? CheckIn { get; set; }
    }
}
