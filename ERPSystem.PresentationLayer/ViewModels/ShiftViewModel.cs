using ERPSystem.DataAccessLayer.Modules.HR.enums;

namespace ERPSystem.PresentationLayer.ViewModels
{
    public class ShiftViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ShiftType ShiftType { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int BreakMinutes { get; set; }
    }
}
