using System.Collections.Generic;
using System.Linq;
using MiniMarket.Models;

namespace MiniMarket.Services
{
    public class CartService
    {
        private readonly List<CartItem> _items = new List<CartItem>();

        public IReadOnlyList<CartItem> Items => _items.AsReadOnly();

        public decimal TotalAmount => _items.Sum(item => item.TotalPrice);

        public void AddItem(Product product, int quantity = 1)
        {
            if (product == null || quantity <= 0) return;

            var existingItem = _items.FirstOrDefault(i => i.Product.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _items.Add(new CartItem { Product = product, Quantity = quantity });
            }
        }

        public bool RemoveItem(CartItem item)
        {
            return _items.Remove(item);
        }

        public void Clear()
        {
            _items.Clear();
        }
    }
}
