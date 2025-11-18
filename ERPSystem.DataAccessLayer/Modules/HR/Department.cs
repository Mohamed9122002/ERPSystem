using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Modules.HR
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = null!;
        // Fk 
        public int? ManagerId { get; set; }

        public Employee? Manager { get; set; }
        // one To many 
        public HashSet<Employee> Employees { get; set; } = new();
        // One To Many 
        public HashSet<JobPosition> JobPositions { get; set; } = new();

        public HashSet<RecruitmentRequest> RecruitmentRequests { get; set; } = new();

    }
}
