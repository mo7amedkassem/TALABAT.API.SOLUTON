using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TALABAT.CORE.Entities;

namespace TALABAT.CORE.Specification
{
    public interface ISpecefication<T> where T : BaseEntity
    {

        public Expression<Func<T, bool>> Criteria { get; set; }

        public List<Expression<Func<T, Object>>> Includes { get; set; }

        public Expression<Func< T , object >> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderBydes { get; set; }

    }
}
