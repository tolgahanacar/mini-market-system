using System.Collections.Generic;
using System.Linq;
using MiniMarket.Models;

namespace MiniMarket.Services;

public class ProductService(IStorageService storageService)
{
    private readonly IStorageService _storageService = storageService;
    private readonly List<Product> _products = storageService.LoadProducts();

        public IReadOnlyList<Product> GetAllProducts() => _products.AsReadOnly();

        public List<string> GetCategories()
        {
            var categories = _products.Select(p => p.Category).Distinct().OrderBy(c => c).ToList();
            // Ensure default categories are always available
            foreach (var def in new[] { "Yiyecek", "İçecek", "Tatlı", "Genel" })
            {
                if (!categories.Contains(def)) categories.Add(def);
            }
            return categories;
        }

        public List<Product> SearchProducts(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return _products.ToList();
            keyword = keyword.Trim().ToLower();
            return _products.Where(p => p.Name.ToLower().Contains(keyword) || p.Category.ToLower().Contains(keyword)).ToList();
        }

        public Product AddProduct(string name, decimal price, string category = "Genel")
        {
            int nextId = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
            var product = new Product
            {
                Id = nextId,
                Name = name,
                Price = price,
                Category = string.IsNullOrWhiteSpace(category) ? "Genel" : category
            };
            _products.Add(product);
            _storageService.SaveProducts(_products);
            return product;
        }

        public bool UpdateProduct(int id, string name, decimal price, string category)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return false;

            product.Name = name;
            product.Price = price;
            product.Category = string.IsNullOrWhiteSpace(category) ? "Genel" : category;

            _storageService.SaveProducts(_products);
            return true;
        }

        public bool DeleteProduct(int productId)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                _products.Remove(product);
                _storageService.SaveProducts(_products);
                return true;
            }
            return false;
        }
}
