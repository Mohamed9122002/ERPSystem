using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Configurations.HR
{
    public class PerformanceReviewConfiguration : BaseEntityConfiguration<PerformanceReview>, IEntityTypeConfiguration<PerformanceReview>
    {
        public new void Configure(EntityTypeBuilder<PerformanceReview> builder)
        {
            builder.ToTable("PerformanceReviews", "HR");
            builder.Property(pr => pr.ReviewDate)
                   .IsRequired();

            builder.Property(pr => pr.Score)
                   .IsRequired();

            builder.Property(pr => pr.Notes)
                   .HasMaxLength(500)
                   .IsRequired(false);
            // Relationships
            builder.HasOne(pr => pr.Employee)
                   .WithMany(e => e.PerformanceReviews)
                   .HasForeignKey(pr => pr.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);
            base.Configure(builder);
        }
    }
}
