using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Configurations.HR
{
    public class PayrollItemConfiguration :BaseEntityConfiguration<PayrollItem, int>, IEntityTypeConfiguration<PayrollItem>
    {
        public new void Configure(EntityTypeBuilder<PayrollItem> builder)
        {
            builder.ToTable("PayrollItems", "HR");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            builder.Property(p => p.StartDate)
                .IsRequired();
            builder.Property(p => p.IsActive)
                .HasDefaultValue(true);
            builder.Property(p => p.Notes)
                .HasMaxLength(500);
            builder.HasOne(p => p.Employee)
                .WithMany(e => e.PayrollItems)
                .HasForeignKey(p => p.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.PayrollItemType)
                .WithMany(t => t.PayrollItems)
                .HasForeignKey(p => p.PayrollItemTypeId)
                .OnDelete(DeleteBehavior.Cascade);
            base.Configure(builder);
        }
    }
}
