using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Modules.HR
{
    public class PerformanceReview :BaseEntity
    {
        public DateTime ReviewDate { get; set; }
        public int Score { get; set; }
        public string? Notes { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!; 
    }
}
