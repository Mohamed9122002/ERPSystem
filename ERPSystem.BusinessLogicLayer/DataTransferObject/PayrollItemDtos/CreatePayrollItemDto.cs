using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.PayrollItemDtos
{
    public class CreatePayrollItemDto
    {
        public int EmployeeId { get; set; }
        public int PayrollItemTypeId { get; set; }
        public decimal? Amount { get; set; }  // لو IsPercentage = false
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Notes { get; set; }
    }
}
