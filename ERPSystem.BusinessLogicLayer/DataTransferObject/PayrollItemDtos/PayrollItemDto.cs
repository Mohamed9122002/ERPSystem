using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.PayrollItemDtos
{
    public class PayrollItemDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int PayrollItemTypeId { get; set; }
        public string PayrollItemTypeName { get; set; } = null!;
        public bool IsPercentage { get; set; }
        public decimal? FixedAmount { get; set; }
        public decimal? Percentage { get; set; }

        public decimal? Amount { get; set; } 
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }
    }
}
