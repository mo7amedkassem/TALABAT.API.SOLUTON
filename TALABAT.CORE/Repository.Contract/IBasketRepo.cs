using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TALABAT.CORE.Entities;

namespace TALABAT.CORE.Repository.Contract
{
    public interface IBasketRepo
    {
        Task<CustomerBasket?> GetBasketAsync(String basketid);
        Task<CustomerBasket?> UpdateBasket(CustomerBasket? basket);
        Task<bool> DeleteBasketasync(String basketid);

    }
}
