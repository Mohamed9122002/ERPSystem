using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Modules.HR
{
    public class JobPosition :BaseEntity
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int DepartmentId { get; set; } // Fk 
        // Many-to-One
        public Department Department { get; set; } = null!;
        // One To Many
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public HashSet<RecruitmentRequest> RecruitmentRequests { get; set; } = new();
    }
}
