using Microsoft.AspNetCore.Mvc.Rendering;

namespace ERPSystem.PresentationLayer.ViewModels
{
    public class JobPositionViewModel
    {
        public int Id { get; set; }  
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int DepartmentId { get; set; }
        public IEnumerable<SelectListItem>? Departments { get; set; }
    }
}