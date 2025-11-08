using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Modules.HR
{
    public class Allowance
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Amount { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
    }
}
