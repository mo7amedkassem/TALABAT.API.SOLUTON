using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TALABAT.CORE.Entities;
using TALABAT.CORE.Specification;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TALABAT.REPOSITORY
{
    internal class SpeceficationEvaluator <TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> InputQuery ,ISpecefication<TEntity> spec)
        {
            var Query = InputQuery; //_dbcontext.set<product>()

            if ( spec.Criteria is not null ) // p => p.Id == 1  
                Query = Query.Where ( spec.Criteria );

            if(spec.OrderBy is not null)
                Query =Query.OrderBy ( spec.OrderBy );

            else if (spec.OrderBydes is not null)
                Query=Query.OrderByDescending ( spec.OrderBydes );
            
            //query = _dbcontext.set<product>().where(p => p.Id == 1)
            //Includes
            // 1.p => p.Brand
            // 2.p => p.Category

            Query = spec.Includes.Aggregate(Query  ,(CurrentQuery,includeExpression) => CurrentQuery.Include(includeExpression));

                           // query = _dbcontext.set<product>().where(p => p.Id == 1).Include(p => p.Brand)
            // query = _dbcontext.set<product>().where(p => p.Id == 1).Include(p => p.Brand).Include(p =>p.Category)


            return Query;
        }
    }
}
