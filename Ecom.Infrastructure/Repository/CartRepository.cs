//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;
//using Ecom.Core.Interfaces;
//using Ecom.Core.Models;
//using Ecom.Infrastructure.Data;
//using Microsoft.EntityFrameworkCore.Storage;
//using StackExchange.Redis;

//namespace Ecom.Infrastructure.Repository
//{
//    public class CartRepository : ICartReository
//    {
//        private readonly AppDbContext context;
//        private readonly StackExchange.Redis.IDatabase _database;
//        public CartRepository(AppDbContext context)
//        {
//            this.context = context;
       
//        }


//        public Task<bool> DeleteBasketAsync(string basketId)
//        {
//             return _database.KeyDeleteAsync(basketId); 
//        }

//        public async Task<Cart> GetBasketAsync(string basketId)
//        {
//            var result = await _database.StringGetAsync(basketId);
//            if (!string.IsNullOrEmpty(result))
//            {
//                return System.Text.Json.JsonSerializer.Deserialize<Cart>(result);
//            }
//            return null;
//        }

//        public async Task<Cart> UpdateBasketAsync(Cart cart)
//        {
//            var result = await _database.StringSetAsync(cart.Id, System.Text.Json.JsonSerializer.Serialize(cart), TimeSpan.FromDays(30));
//            if (result != null)
//            {
//                return await GetBasketAsync(cart.Id);
//            }
//            return null;
//        }
//    }
//}
