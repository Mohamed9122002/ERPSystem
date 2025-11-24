using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Modules.HR
{
    public class PayrollItem :BaseEntity<int>
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public int PayrollItemTypeId { get; set; }
        public PayrollItemType PayrollItemType { get; set; } = null!;

        public decimal Amount { get; set; }           

        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; }         

        public bool IsActive { get; set; } = true;    
        public string? Notes { get; set; }
    }
}
