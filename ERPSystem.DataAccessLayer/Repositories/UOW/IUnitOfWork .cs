using ERPSystem.DataAccessLayer.Modules;
using ERPSystem.DataAccessLayer.Repositories.EmployeeRepo;
using ERPSystem.DataAccessLayer.Repositories.RepositorieyGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Repositories.UOW
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity, TKey> CreateGenericRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
        Task<int> SaveChangeAsync();
    }
}
