using ERPSystem.DataAccessLayer.Modules.HR.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Configurations.HR
{
    public class PayrollItemTypeConfiguration : BaseEntityConfiguration<PayrollItemType, int>, IEntityTypeConfiguration<PayrollItemType>
    {
        public new void Configure(EntityTypeBuilder<PayrollItemType> builder)
        {
            builder.ToTable("PayrollItemTypes", "HR");
            builder.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            builder.Property(K => K.Kind).HasConversion((KType) => KType.ToString(),
                (_PType) => (PayrollItemKind)Enum.Parse(typeof(PayrollItemKind), _PType));
            builder.Property(p => p.IsPercentage)
                .HasDefaultValue(false);
            builder.Property(p => p.IsTaxRelated)
                .HasDefaultValue(false);

            builder.HasMany(p => p.PayrollItems)
                .WithOne(p => p.PayrollItemType)
                .HasForeignKey(p => p.PayrollItemTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
