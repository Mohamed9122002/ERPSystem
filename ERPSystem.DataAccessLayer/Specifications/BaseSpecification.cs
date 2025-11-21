using ERPSystem.DataAccessLayer.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Specifications
{
    public abstract class BaseSpecification<TEntity, TKey> : ISpecification<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public Expression<Func<TEntity, bool>>? WhereExpressions { get; private set; }
        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = new List<Expression<Func<TEntity, object>>>();

        public List<Func<IQueryable<TEntity>, IQueryable<TEntity>>> IncludePaths { get; } = new();

        protected BaseSpecification(Expression<Func<TEntity, bool>>? whereExpression)
        {
            WhereExpressions = whereExpression;
        }
        protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            IncludeExpressions.Add(includeExpression);
        }
        protected void AddInclude(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeExpression)
        {
            IncludePaths.Add(includeExpression);
        }

    }
}
