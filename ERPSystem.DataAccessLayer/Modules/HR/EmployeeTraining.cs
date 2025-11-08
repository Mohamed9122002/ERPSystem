using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Modules.HR
{
    public class EmployeeTraining
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public int TrainingId { get; set; }
        public Training Training { get; set; } = null!;
    }
}
