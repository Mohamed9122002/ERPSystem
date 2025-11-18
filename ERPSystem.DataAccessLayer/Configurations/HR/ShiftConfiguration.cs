using ERPSystem.DataAccessLayer.Modules.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Configurations.HR
{
    public class ShiftConfiguration :BaseEntityConfiguration<Shift>, IEntityTypeConfiguration<Shift>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Shift> builder)
        {
            builder.ToTable("Shifts", "HR");
            builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
            builder.Property(s => s.StartTime).IsRequired();
            builder.Property(s => s.EndTime).IsRequired();
            builder.HasMany(s => s.Employees)
                   .WithOne(e => e.Shift)
                   .HasForeignKey(e => e.ShiftId)
                   .OnDelete(DeleteBehavior.SetNull);
            base.Configure(builder);
        }
    }
}
