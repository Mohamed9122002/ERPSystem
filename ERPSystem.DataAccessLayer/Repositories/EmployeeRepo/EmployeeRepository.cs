using ERPSystem.DataAccessLayer.Contexts;
using ERPSystem.DataAccessLayer.Repositories.RepositorieyGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Repositories.EmployeeRepo
{
    public class EmployeeRepository(ERPDbContext _dbContext) :GenericRepository<Employee,int>(_dbContext), IEmployeeRepository
    {
    }
}
