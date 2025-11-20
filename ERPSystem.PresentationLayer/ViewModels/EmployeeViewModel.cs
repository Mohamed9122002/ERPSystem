using ERPSystem.DataAccessLayer.Modules.HR.enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ERPSystem.PresentationLayer.ViewModels
{
    public class EmployeeViewModel
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
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
        public Gender Gender { get; set; }
        public ContractType EmployeeType { get; set; }
        public string? Address { get; set; } 
        public decimal Salary { get; set;   }
        public int Age { get; set; }
        // DropDownLists for View
        public IEnumerable<SelectListItem>? Departments { get; set; }
        public IEnumerable<SelectListItem>? JobPositions { get; set; }
        public IEnumerable<SelectListItem>? Shifts { get; set; }
    }
}
