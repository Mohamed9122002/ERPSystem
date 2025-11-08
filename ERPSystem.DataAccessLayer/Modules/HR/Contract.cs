using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Modules.HR
{
    public class Contract
    {
        public int Id { get; set; }
        // Fk 
        public int EmployeeId { get; set; }
        // Nav One-to-One 
        public Employee Employee { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Salary { get; set; }
        public string ContractType { get; set; } = null!;
    }
}
