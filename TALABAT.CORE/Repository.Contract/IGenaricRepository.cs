using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TALABAT.CORE.Entities;
using TALABAT.CORE.Specification;

namespace TALABAT.CORE.Repository.Contract
{
    public interface IGenaricRepository<T> where T : BaseEntity
    {
        Task<T?> GetAsync(int id);

        Task<IEnumerable<T>> GetAllAsync ();

        Task<IEnumerable<T>> GetAllBySpecAsync(ISpecefication<T> Spec);

        Task<T?> GetBySpecAsync(ISpecefication<T> Spec);
      
    }
}
