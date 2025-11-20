using ERPSystem.DataAccessLayer.Modules.HR.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.EmployeeDtos
{
    public class UpdatedEmployeeDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        [MaxLength(50, ErrorMessage = "Name Must be less than 50 Characters")]
        [MinLength(5, ErrorMessage = "Name Must be More than 5 Characters")]
        public string FullName { get; set; } = null!;

        public string NationalID { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime? HireDate { get; set; }
        public string? Status { get; set; }
        [Range(22, 30, ErrorMessage = "Age Must be Between 18 and 60")]
        public int Age { get; set; }
        //[RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}[a-zA-Z]{5,10}$",
        //    ErrorMessage = "Address Must be Like 123-Street-City-Country")]
        public string? Address { get; set; }
        public Gender Gender { get; set; }
        public ContractType EmployeeType { get; set; }
        public int DepartmentId { get; set; }
        public int JobPositionId { get; set; }
        public int? ShiftId { get; set; }

    }
}
