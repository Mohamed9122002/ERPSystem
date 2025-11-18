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
    public class DepartmentConfiguration : BaseEntityConfiguration<Department, int>, IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments", "HR");
            builder.Property(d => d.Name).IsRequired().HasMaxLength(100);

            builder.HasMany(d => d.Employees)
              .WithOne(e => e.Department)
              .HasForeignKey(e => e.DepartmentId)
              .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(d => d.JobPositions)
               .WithOne(j => j.Department)
               .HasForeignKey(j => j.DepartmentId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.Manager)
                   .WithMany()
                   .HasForeignKey(d => d.ManagerId)
                   .OnDelete(DeleteBehavior.SetNull);
            base.Configure(builder);


        }
    }
}
