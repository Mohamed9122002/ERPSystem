using ERPSystem.DataAccessLayer.Modules.HR;
using ERPSystem.DataAccessLayer.Modules.HR.enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Configurations.HR
{
    public class EmployeeConfiguration : BaseEntityConfiguration<Employee, int>, IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees", "HR");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.FullName)
              .IsRequired()
              .HasMaxLength(100);
            builder.Property(e => e.NationalID)
           .IsRequired()
           .HasMaxLength(14);
            builder.Property(e => e.Phone).HasMaxLength(20);
            builder.Property(e => e.Email).HasMaxLength(100);
            builder.Property(e => e.Status)
           .HasMaxLength(20)
           .HasDefaultValue("Active");
            builder.Property(E => E.Salary).HasColumnType("decimal(10,2)");
            builder.Property(E => E.Gender)
         .HasConversion((EmpGender) => EmpGender.ToString(),
         (_gender) => (Gender)Enum.Parse(typeof(Gender), _gender));
            builder.Property(E => E.EmployeeType)
           .HasConversion((EmpType) => EmpType.ToString(),
       (_Type) => (ContractType)Enum.Parse(typeof(ContractType), _Type));
            builder.Property(e => e.HireDate).IsRequired();
            builder.Property(E => E.Address).HasColumnType("varchar(150)");

            // Relationships
            builder.HasOne(e => e.Department)
                   .WithMany(d => d.Employees)
                   .HasForeignKey(e => e.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.JobPosition)
                   .WithMany(j => j.Employees)
                   .HasForeignKey(e => e.JobPositionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Shift)
                   .WithMany(s => s.Employees)
                   .HasForeignKey(e => e.ShiftId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(e => e.Contract)
                   .WithOne(c => c.Employee)
                   .HasForeignKey<Contract>(c => c.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Payslips)
                   .WithOne(p => p.Employee)
                   .HasForeignKey(p => p.EmployeeId);
            builder.HasMany(e => e.Allowances)
                   .WithOne(a => a.Employee)
                   .HasForeignKey(a => a.EmployeeId);

            builder.HasMany(e => e.Deductions)
                   .WithOne(d => d.Employee)
                   .HasForeignKey(d => d.EmployeeId);

            builder.HasMany(e => e.Attendances)
                   .WithOne(a => a.Employee)
                   .HasForeignKey(a => a.EmployeeId);

            builder.HasMany(e => e.LeaveRequests)
                   .WithOne(l => l.Employee)
                   .HasForeignKey(l => l.EmployeeId);

            builder.HasMany(e => e.PerformanceReviews)
                   .WithOne(pr => pr.Employee)
                   .HasForeignKey(pr => pr.EmployeeId);

            builder.HasMany(e => e.EmployeeTrainings)
                   .WithOne(et => et.Employee)
                   .HasForeignKey(et => et.EmployeeId);

            base.Configure(builder);

        }
    }
}
