using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TALABAT.CORE.Entities;
using TALABAT.CORE.Repository.Contract;

namespace TALABAT.REPOSITORY
{
    public class BasketRepo : IBasketRepo
    {
        private readonly IDatabase _database;

        public BasketRepo(IConnectionMultiplexer redis) 
        {
            _database = redis.GetDatabase();
        }

        public async Task<bool> DeleteBasketasync(string basketid)
        {
           return await _database.KeyDeleteAsync(basketid);
        }

        public async Task<CustomerBasket?> GetBasketAsync(string basketid)
        {
         
            if (string.IsNullOrEmpty(basketid))
            {
                throw new Exception("Id not found");
            }
            else
            {
                var basket = await _database.StringGetAsync(basketid);
                return basket.IsNull ? null : JsonSerializer.Deserialize<CustomerBasket>(basket);
            }       
        }

        public async Task<CustomerBasket?> UpdateBasket(CustomerBasket basket)
        {
            var updatedOrCreatedBasket = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(1));
            if (updatedOrCreatedBasket is false) return null;
            return await GetBasketAsync(basket.Id);
        }
    }
}
