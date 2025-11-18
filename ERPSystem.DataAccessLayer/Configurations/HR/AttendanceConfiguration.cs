
using ERPSystem.DataAccessLayer.Modules.HR.enums;

namespace ERPSystem.DataAccessLayer.Configurations.HR
{
    public class AttendanceConfiguration : BaseEntityConfiguration<Attendance>, IEntityTypeConfiguration<Attendance>
    {
        public new void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.ToTable("Attendances", "HR");
            builder.Property(a => a.Date).IsRequired();

            builder.Property(a => a.CheckIn).IsRequired(false);

            builder.Property(a => a.CheckOut).IsRequired(false);
            builder.Property(s => s.Status).HasConversion((AType) => AType.ToString(),
                (_AType) => (AttendanceStatus)Enum.Parse(typeof(AttendanceStatus), _AType));
            builder.HasOne(a => a.Employee)
                   .WithMany(e => e.Attendances)
                   .HasForeignKey(a => a.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);
            base.Configure(builder);
        }

    }
}
