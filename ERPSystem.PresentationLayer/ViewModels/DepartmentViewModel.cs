namespace ERPSystem.PresentationLayer.ViewModels
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ManagerName { get; set; }
        public DateOnly? DateOfCreation { get; set; }
    }
}
