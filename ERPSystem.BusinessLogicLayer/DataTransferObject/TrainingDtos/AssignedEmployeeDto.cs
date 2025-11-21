using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.TrainingDtos
{
    public class AssignedEmployeeDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
    }
}
