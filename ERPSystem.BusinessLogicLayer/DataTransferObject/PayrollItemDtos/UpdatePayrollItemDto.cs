using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.PayrollItemDtos
{
    public class UpdatePayrollItemDto
    {
        public int Id { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }
    }
}
