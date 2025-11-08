using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Modules.HR
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; } = null!;
        // Fk 
        public int? ManagerId { get; set; }

        public Employee? Manager { get; set; }
       // one To many 
        public ICollection<Employee> Employees { get; set; } =new HashSet<Employee>();
        // One To Many 
        public ICollection<JobPosition> JobPositions { get; set; } = new HashSet<JobPosition>();
    }
}
