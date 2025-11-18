

using ERPSystem.DataAccessLayer.Modules.HR.enums;

namespace ERPSystem.DataAccessLayer.Configurations.HR
{
    public class LeaveRequestConfiguration : BaseEntityConfiguration<LeaveRequest>, IEntityTypeConfiguration<LeaveRequest>
    {
        public new void Configure(EntityTypeBuilder<LeaveRequest> builder)
        {
            builder.ToTable("LeaveRequests", "HR");
            builder.Property(l => l.StartDate)
                       .IsRequired();

            builder.Property(l => l.EndDate)
                   .IsRequired();

            builder.Property(l => l.Reason)
                   .HasMaxLength(500)
                   .IsRequired(false);
            builder.Property(T => T.Type).HasConversion((Type) => Type.ToString(),
                (_Type) => (LeaveRequestEnum)Enum.Parse(typeof(LeaveRequestEnum), _Type));
            builder.Property(s => s.Status).HasConversion((statu) => statu.ToString(),
                (_statu) => (LeaveRequestStatus)Enum.Parse(typeof(LeaveRequestStatus), _statu));
            builder.HasOne(l => l.Employee)
              .WithMany(e => e.LeaveRequests)
              .HasForeignKey(l => l.EmployeeId)
              .OnDelete(DeleteBehavior.Cascade);
            base.Configure(builder);
        }
    }
}
