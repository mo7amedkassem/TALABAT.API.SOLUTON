using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TALABAT.CORE.Entities;
using TALABAT.CORE.Repository.Contract;
using TALABAT.CORE.Specification;
using TALABAT.REPOSITORY.Data;

namespace TALABAT.REPOSITORY
{

    public class GenaricRepository<T> : IGenaricRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _dbcontext;

        public GenaricRepository(StoreContext dbcontext) 
        {
            _dbcontext = dbcontext;
        }






        public async Task<IEnumerable<T>> GetAllAsync()
        {

            //if (typeof(T) == typeof(Product))
            //    return (IEnumerable<T>)await _dbcontext.Set<Product>().Include(p => p.Brand).Include(p => p.Category).ToListAsync();

            return await _dbcontext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            return await _dbcontext.Set<T>().FindAsync(id);
        }




        public async Task<IEnumerable<T>> GetAllBySpecAsync(ISpecefication<T> Spec /* بتقلو خد البراميتر بتاعك من هناك علشان تاخد علي طول العناصر كلها من هناك */)
        {
           return await SpeceficationEvaluator<T>.GetQuery ( _dbcontext.Set<T>( ) , Spec ) . ToListAsync();
        }


        public async Task<T?> GetBySpecAsync(ISpecefication<T> Spec/*بتقلو خد البراميتر بتاعك من هناك علشان تاخد علي طول العنصر الي انت بتدور عليه بال where بتعتك  */)
        {
            return await SpeceficationEvaluator<T>.GetQuery(_dbcontext.Set<T>(), Spec).FirstOrDefaultAsync();
        }
    }
}
