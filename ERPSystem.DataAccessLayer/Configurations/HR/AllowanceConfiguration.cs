

namespace ERPSystem.DataAccessLayer.Configurations.HR
{
    public class AllowanceConfiguration : BaseEntityConfiguration<Allowance,int>, IEntityTypeConfiguration<Allowance>
    {
        public new void Configure(EntityTypeBuilder<Allowance> builder)
        {
            builder.ToTable("Allowances", "HR");
            builder.Property(a => a.Name)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(a => a.Amount)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");
            builder.HasOne(a => a.Employee)
                   .WithMany(e => e.Allowances)
                   .HasForeignKey(a => a.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);
            base.Configure(builder);
        }
    }
}
