

using Microsoft.IdentityModel.Tokens;

namespace ERPSystem.DataAccessLayer.Configurations.HR
{
    public class DeductionConfiguration:BaseEntityConfiguration<Deduction, int> , IEntityTypeConfiguration<Deduction>
    {
        public new void Configure(EntityTypeBuilder<Deduction> builder)
        {
            builder.ToTable("Deductions", "HR");
            builder.Property(d => d.Name).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Amount).IsRequired().HasColumnType("decimal(18,2)");
            builder.HasOne(d => d.Employee)
                   .WithMany(e => e.Deductions)
                   .HasForeignKey(d => d.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);
            base.Configure(builder);
        }
    

    }
}
