using ERPSystem.DataAccessLayer.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Configurations.HR
{
    public class TrainingConfiguration : BaseEntityConfiguration<Training, int>, IEntityTypeConfiguration<Training>   
    {
        public  new void Configure(EntityTypeBuilder<Training> builder)
        {
            builder.ToTable("Trainings", "HR");
            builder.Property(t => t.Title)
              .IsRequired()
              .HasMaxLength(200);
            builder.Property(t => t.Description)
              .HasMaxLength(1000);
            builder.Property(t => t.StartDate)
              .IsRequired();
            builder.Property(t => t.EndDate)
              .IsRequired();
            builder.Property(t => t.Location)
              .HasMaxLength(200);
            builder.HasMany(t => t.EmployeeTrainings)
              .WithOne(et => et.Training)
              .HasForeignKey(et => et.TrainingId)
              .OnDelete(DeleteBehavior.Cascade);
            base.Configure(builder);
        }
    }
}
