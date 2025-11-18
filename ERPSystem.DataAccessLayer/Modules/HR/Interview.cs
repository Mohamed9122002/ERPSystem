using ERPSystem.DataAccessLayer.Modules.HR.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Modules.HR
{
    public class Interview :BaseEntity
    {
        public DateTime InterviewDate { get; set; }
        public InterviewType? Result { get; set; }  // Passed, Failed, Pending
        public string? Notes { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; } = null!;
        public RecruitmentRequest RecruitmentRequest { get; set; } = null!;
        // Fk 
        public int RecruitmentRequestId { get; set; } 
    }
}
