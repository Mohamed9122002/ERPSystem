using ERPSystem.DataAccessLayer.Modules.HR.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Modules.HR
{
    public class Candidate :BaseEntity<int>
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; }   = null!;
        public string CVUrl { get; set; } = null!;
        public CandidateStatus Status { get; set; } = CandidateStatus.New;
        public int RecruitmentRequestId { get; set; }
        public RecruitmentRequest RecruitmentRequest { get; set; } = null!;
    }
}
