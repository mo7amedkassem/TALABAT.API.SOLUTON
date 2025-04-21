using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TALABAT.CORE.Entities;

namespace TALABAT.CORE.Specification
{
    public class BaseSpecefecation<T> : ISpecefication<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set; } = null;
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, Object>>>();
        public Expression<Func<T, object>> OrderBy { get ; set ; }
        public Expression<Func<T, object>> OrderBydes { get; set; }

        public BaseSpecefecation() 
        { 
            
        }
        public BaseSpecefecation(Expression<Func<T, bool>> CriteriaExpression)
        {
            Criteria =  CriteriaExpression;
        }

        public void AddOrderby(Expression<Func<T, object>> OrderByExpression)
        {
            OrderBy =  OrderByExpression ;
        }
        public void AddOrderbyDes(Expression<Func<T, object>> OrderByDesExpression)
        {
            OrderBydes = OrderByDesExpression ;
        }
    }
}
