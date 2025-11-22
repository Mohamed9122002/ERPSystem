using ERPSystem.BusinessLogicLayer.DataTransferObject.EmployeeDtos;
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
        public int EmployeesCount
        {
            get
            {
                return AssignedEmployees?.Count ?? 0;
            }
        }

        public bool IsOvernight { get; set; }
        public List<EmployeeDto>  AllEmployees { get; set; } = new List<EmployeeDto>();
        public List<EmployeeDto> AssignedEmployees { get; set; } = new List<EmployeeDto>();
    }
}
