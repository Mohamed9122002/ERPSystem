using ERPSystem.DataAccessLayer.Contexts;
using ERPSystem.DataAccessLayer.Modules;
using ERPSystem.DataAccessLayer.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Repositories.RepositorieyGeneric
{
    public class GenericRepository<TEntity,Tkey>(ERPDbContext _dbContext) : IGenericRepository<TEntity,Tkey> where TEntity : BaseEntity<Tkey>
    {
        public async Task AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool withTracking = false)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>()
                .Where(e => e.IsDeleted != true);

            if (!withTracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }


        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }

        public void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, bool withTracking = false)
        {
            return await _dbContext.Set<TEntity>()
                                    .Where(predicate)
                                    .ToListAsync();
        }

        #region With Specification
        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity, Tkey> specifications)
        {
            return await SpecificationsEvaluator.CreateQuery(_dbContext.Set<TEntity>(), specifications).ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(ISpecification<TEntity, Tkey> specifications)
        {
            return await SpecificationsEvaluator.CreateQuery(_dbContext.Set<TEntity>(), specifications).FirstOrDefaultAsync();

        }
        #endregion
    }
}
