using ERPSystem.BusinessLogicLayer.DataTransferObject.EmployeeDtos;

namespace ERPSystem.PresentationLayer.ViewModels
{
    public class AssignEmployeeViewModel
    {
        public int TrainingId { get; set; }
        public string TrainingTitle { get; set; } = string.Empty;
        public List<int> SelectedEmployeeIds { get; set; } = new();

    
        public List<EmployeeDto> Employees { get; set; } = new();
    }
}
