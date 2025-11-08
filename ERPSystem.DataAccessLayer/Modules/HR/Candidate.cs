using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Modules.HR
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        public string FullName { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? CVUrl { get; set; }
        public string Status { get; set; } = "New";
        public int RecruitmentRequestId { get; set; }
        public RecruitmentRequest RecruitmentRequest { get; set; } = null!;
    }
}
