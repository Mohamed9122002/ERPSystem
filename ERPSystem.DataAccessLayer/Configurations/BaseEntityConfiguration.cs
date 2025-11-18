using ERPSystem.DataAccessLayer.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Configurations
{
    public class BaseEntityConfiguration<T,Tkey> : IEntityTypeConfiguration<T> where T : BaseEntity<Tkey>
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(B => B.CreatedOn).HasDefaultValueSql("GetDate()");
            builder.Property(B=> B.LastModifiedOn).HasComputedColumnSql("GetDate()");
            builder.Property(b => b.IsDeleted).HasDefaultValue(false);
        }
    }
}
