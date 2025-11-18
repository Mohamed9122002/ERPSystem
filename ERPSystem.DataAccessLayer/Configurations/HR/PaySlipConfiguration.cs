

namespace ERPSystem.DataAccessLayer.Configurations.HR
{
    public class PaySlipConfiguration :BaseEntityConfiguration<PaySlip, int>, IEntityTypeConfiguration<PaySlip>
    {
        public new  void Configure(EntityTypeBuilder<PaySlip> builder)
        {
            builder.ToTable("PaySlips", "HR");
            builder.Property(p => p.Month).IsRequired();
            builder.Property(p => p.Year).IsRequired();
            builder.Property(p => p.BasicSalary).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.TotalAllowance).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.TotalDeduction).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.NetSalary).IsRequired().HasColumnType("decimal(18,2)");
            builder.HasOne(p => p.Employee)
                   .WithMany(e => e.Payslips)
                   .HasForeignKey(p => p.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);
            base.Configure(builder);
        }
    }
}
