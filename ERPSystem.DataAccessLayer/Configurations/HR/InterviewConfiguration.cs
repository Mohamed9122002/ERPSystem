using ERPSystem.DataAccessLayer.Modules.HR.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Configurations.HR
{
    public class InterviewConfiguration : BaseEntityConfiguration<Interview>, IEntityTypeConfiguration<Interview>
    {
        public new void Configure(EntityTypeBuilder<Interview> builder)
        {
            builder.ToTable("Interviews", "HR");
            builder.Property(i => i.InterviewDate).IsRequired();

            builder.Property(r => r.Result).HasConversion((IResult) => IResult.ToString(),
                (_IType) => (InterviewType)Enum.Parse(typeof(InterviewType), _IType));
            builder.Property(i => i.Notes)
                   .HasMaxLength(500)
                   .IsRequired(false);
            builder.HasOne(i => i.Candidate)
                   .WithMany()
                   .HasForeignKey(i => i.CandidateId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.RecruitmentRequest)
                   .WithMany(r => r.Interviews)
                   .HasForeignKey(i => i.RecruitmentRequestId)
                   .OnDelete(DeleteBehavior.Restrict);
            base.Configure(builder);
        }
    }
}
