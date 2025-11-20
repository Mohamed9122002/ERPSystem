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
        // CreateQuery 
        public static  IQueryable<TEntity>CreateQuery<TEntity,TKey>(IQueryable<TEntity> entities , ISpecification<TEntity,TKey> specifications) where  TEntity :BaseEntity<TKey>
        {
            var Query = entities; 
            if(specifications.WhereExpressions != null)
            {
                Query = Query.Where(specifications.WhereExpressions);
            }
            if(specifications.IncludeExpressions != null && specifications.IncludeExpressions.Count > 0)
            {
                Query = specifications.IncludeExpressions.Aggregate(Query, (current, include) => current.Include(include));
            }
            return Query;
        }
    }
}
