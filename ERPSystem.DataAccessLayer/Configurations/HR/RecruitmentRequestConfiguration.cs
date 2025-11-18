using ERPSystem.DataAccessLayer.Modules.HR.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Configurations.HR
{
    public class RecruitmentRequestConfiguration : BaseEntityConfiguration<RecruitmentRequest>, IEntityTypeConfiguration<RecruitmentRequest>
    {
        public new void Configure(EntityTypeBuilder<RecruitmentRequest> builder)
        {
            builder.ToTable("RecruitmentRequests", "HR");
            builder.Property(r => r.RequestedDate).IsRequired();
            builder.Property(R => R.Status).HasConversion((RRS) => RRS.ToString(),
                (_Type) => (RecruitmentRequestStatus)Enum.Parse(typeof(RecruitmentRequestStatus), _Type));

            builder.HasOne(r => r.JobPosition)
                   .WithMany(j => j.RecruitmentRequests)
                   .HasForeignKey(r => r.JobPositionId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(r => r.Department)
                    .WithMany(d => d.RecruitmentRequests)
                    .HasForeignKey(r => r.DepartmentId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(r => r.Candidates)
                   .WithOne(c => c.RecruitmentRequest)
                   .HasForeignKey(c => c.RecruitmentRequestId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(r => r.Interviews)
                   .WithOne(i => i.RecruitmentRequest)
                   .HasForeignKey(i => i.RecruitmentRequestId)
                   .OnDelete(DeleteBehavior.Restrict);
            base.Configure(builder);
        }
    }
}
