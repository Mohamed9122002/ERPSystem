using ERPSystem.DataAccessLayer.Modules.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Contexts
{
    public class ERPDbContext(DbContextOptions<ERPDbContext> options) : DbContext(options)
    {
       public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ERPDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
