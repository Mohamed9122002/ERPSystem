using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ERPSystem.PresentationLayer.ViewModels
{
    public class EmployeeViewModel
    {
        [Required]
        [Display(Name = "Full Name")]
        public int Id { get; set; }
        public string FullName { get; set; } = null!;

        [Required]
        [Display(Name = "National ID")]
        public string NationalID { get; set; } = null!;

        [Phone]
        public string? Phone { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; } = DateTime.Now;

        [Required]
        public string Status { get; set; } = "Active";

        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Required]
        [Display(Name = "Job Position")]
        public int JobPositionId { get; set; }

        [Display(Name = "Shift")]
        public int? ShiftId { get; set; }

        // DropDownLists for View
        public IEnumerable<SelectListItem>? Departments { get; set; }
        public IEnumerable<SelectListItem>? JobPositions { get; set; }
        public IEnumerable<SelectListItem>? Shifts { get; set; }
    }
}
