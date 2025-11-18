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
    public class ContractConfiguration :BaseEntityConfiguration<Contract>, IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable("Contracts", "HR");
            builder.Property(c => c.StartDate).IsRequired();
            builder.Property(c => c.Salary).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(C=>C.ContractType).HasConversion((EmpType)=> EmpType.ToString(),
                (_Type)=> (ContractType)Enum.Parse(typeof(ContractType),_Type));
            builder.HasOne(c => c.Employee)
                   .WithOne(e => e.Contract)
                   .HasForeignKey<Contract>(c => c.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);
            base.Configure(builder);
        }
    }
}
