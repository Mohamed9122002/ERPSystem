using ERPSystem.DataAccessLayer.Modules.HR.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.EmployeeDtos
{
    public class CreatedEmployeeDto
    {

        [Required(ErrorMessage = "Name Is Required")]
        [MaxLength(50, ErrorMessage = "Name Must be less than 50 Characters")]
        [MinLength(5, ErrorMessage = "Name Must be More than 5 Characters")]
        public string FullName { get; set; } = null!;
        public string NationalID { get; set; } = null!;
        [Phone]
        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Range(22, 50, ErrorMessage = "Age Must be Between 18 and 60")]
        public int Age { get; set; }
        [Display(Name = "Hiring Date")]
        public Gender Gender { get; set; }
        public DateTime HireDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Active";
        public int DepartmentId { get; set; }
        public int JobPositionId { get; set; }
        public int? ShiftId { get; set; }
        public decimal Salary { get; set; }
        public ContractType EmployeeType { get; set; }
        public string? Address { get; set; }

 
    }
}
