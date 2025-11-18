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
    public class EmployeeTrainingConfiguration : IEntityTypeConfiguration<EmployeeTraining>
    {
        public void Configure(EntityTypeBuilder<EmployeeTraining> builder)
        {
            builder.ToTable("EmployeeTrainings", "HR");
            builder.HasKey(et => new { et.EmployeeId, et.TrainingId });

            builder.HasOne(et => et.Employee)
                   .WithMany(e => e.EmployeeTrainings)
                   .HasForeignKey(et => et.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(et => et.Training)
                   .WithMany(t => t.EmployeeTrainings)
                   .HasForeignKey(et => et.TrainingId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
