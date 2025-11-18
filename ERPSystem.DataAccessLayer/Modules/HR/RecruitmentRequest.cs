using ERPSystem.DataAccessLayer.Modules.HR.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Modules.HR
{
    public class RecruitmentRequest :BaseEntity<int>
    {
        public RecruitmentRequestStatus Status { get; set; } = RecruitmentRequestStatus.Open;
        public DateTime RequestedDate { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        public int JobPositionId { get; set; }
        public JobPosition JobPosition { get; set; } = null!;
        public HashSet<Candidate> Candidates { get; set; } = new();
        public HashSet<Interview> Interviews { get; set; } = new();

    }
}
