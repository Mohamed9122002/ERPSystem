using ERPSystem.DataAccessLayer.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Specifications
{
    public static class SpecificationsEvaluator
    {
        public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(IQueryable<TEntity> entities,ISpecification<TEntity, TKey>? specification)where TEntity : BaseEntity<TKey>
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            if (specification == null) return entities;

            IQueryable<TEntity> query = entities;

            if (specification.WhereExpressions != null)
                query = query.Where(specification.WhereExpressions);

            if (specification.IncludeExpressions?.Count > 0)
            {
                foreach (var include in specification.IncludeExpressions)
                {
                    query = query.Include(include);
                }
            }
            if (specification.IncludePaths?.Count > 0)
            {
                foreach (var includePath in specification.IncludePaths)
                {
                    query = includePath(query);
                }
            }

            return query;
        }

    }
}
