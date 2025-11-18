using ERPSystem.DataAccessLayer.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Repositories.RepositorieyGeneric
{
    public interface IGenericRepository<TEntity,Tkey> where TEntity : BaseEntity<Tkey>
    {
        Task AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync(bool withTracking = false);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, bool withTracking = false);

        Task<TEntity?> GetByIdAsync(int id);

        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}
