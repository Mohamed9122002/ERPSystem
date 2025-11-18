using ERPSystem.DataAccessLayer.Repositories.RepositorieyGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Repositories.EmployeeRepo
{
    public interface IEmployeeRepository :IGenericRepository<Employee,int>
    {

    }
}
