using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Modules.HR
{
    public class RecruitmentRequest
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        public int JobPositionId { get; set; }
        public JobPosition JobPosition { get; set; } = null!;
        public string Status { get; set; } = "Open";
        public DateTime RequestedDate { get; set; }
        public ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();
        public ICollection<Interview> Interviews { get; set; } = new List<Interview>();
    }
}
