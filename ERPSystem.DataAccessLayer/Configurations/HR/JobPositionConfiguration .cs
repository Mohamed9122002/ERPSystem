using ERPSystem.DataAccessLayer.Modules.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Configurations.HR
{
    public class JobPositionConfiguration:BaseEntityConfiguration<JobPosition, int>, IEntityTypeConfiguration<JobPosition>
    {
        public void Configure(EntityTypeBuilder<JobPosition> builder)
        {
            builder.ToTable("JobPositions", "HR");
            builder.Property(j => j.Title).IsRequired().HasMaxLength(50);
            builder.Property(j => j.Description).HasMaxLength(300);

            builder.HasMany(j => j.Employees)
                   .WithOne(e => e.JobPosition)
                   .HasForeignKey(e => e.JobPositionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(j => j.Department)
                   .WithMany(d => d.JobPositions)
                   .HasForeignKey(j => j.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);
            base.Configure(builder);
        }
    }
}
