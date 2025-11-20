using ERPSystem.DataAccessLayer.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Specifications
{
    public interface ISpecification<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        // Property Signature For Each Dynamic Part in Query  
        public Expression<Func<TEntity, bool>>? WhereExpressions { get; }
        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; }
    }
}
