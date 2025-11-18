using ERPSystem.DataAccessLayer.Modules.HR.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Configurations.HR
{
    public class CandidateConfiguration :BaseEntityConfiguration<Candidate> , IEntityTypeConfiguration<Candidate>
    {
        public new void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.ToTable("Candidates", "HR");
            builder.Property(c => c.FullName)
             .IsRequired()
             .HasMaxLength(150);

            builder.Property(c => c.Email)
                   .HasMaxLength(100)
                   .IsRequired(true);

            builder.Property(c => c.Phone)
                   .HasMaxLength(20)
                   .IsRequired(true);

            builder.Property(c => c.CVUrl)
                   .HasMaxLength(500)
                   .IsRequired(true);

            builder.Property(s => s.Status).HasConversion((CStatus) => CStatus.ToString(),
                (_CType) => (CandidateStatus)Enum.Parse(typeof(CandidateStatus), _CType));
            builder.HasOne(c => c.RecruitmentRequest)
                   .WithMany(r => r.Candidates)
                   .HasForeignKey(c => c.RecruitmentRequestId)
                   .OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}
