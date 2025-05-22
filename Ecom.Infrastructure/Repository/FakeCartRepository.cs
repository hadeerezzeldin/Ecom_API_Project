using Ecom.Core.Interfaces;
using Ecom.Core.Models;
using System.Collections.Concurrent;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Repository
{
    public class FakeCartRepository : ICartReository
    {
        private readonly ConcurrentDictionary<string, Cart> _store = new();

        public Task<Cart> GetBasketAsync(string basketId)
        {
            _store.TryGetValue(basketId, out var cart);
            return Task.FromResult(cart);
        }

        public Task<Cart> UpdateBasketAsync(Cart cart)
        {
            _store[cart.Id] = cart;
            return Task.FromResult(cart);
        }

        public Task<bool> DeleteBasketAsync(string basketId)
        {
            return Task.FromResult(_store.TryRemove(basketId, out _));
        }
    }
}

