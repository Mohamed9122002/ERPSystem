using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.EmployeeDtos
{
    public class CreatedEmployeeDto
    {
        public string FullName { get; set; } = null!;
        public string NationalID { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime HireDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Active";
        public int DepartmentId { get; set; }
        public int JobPositionId { get; set; }
        public int? ShiftId { get; set; }
    }
}
