using System.Collections.Generic;
using MiniMarket.Models;
using MiniMarket.Services;
using Xunit;

namespace MiniMarket.Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public void AddProduct_ShouldAssignNextIdAndSave()
        {
            // Arrange
            var storage = new FakeStorageService();
            var productService = new ProductService(storage);

            // Act
            var newProduct = productService.AddProduct("Pizza", 45m, "Yiyecek");

            // Assert
            Assert.NotNull(newProduct);
            Assert.Equal("Pizza", newProduct.Name);
            Assert.Equal(45m, newProduct.Price);
            Assert.Contains(storage.Products, p => p.Name == "Pizza");
        }

        [Fact]
        public void UpdateProduct_ShouldModifyProductDetailsAndSave()
        {
            // Arrange
            var storage = new FakeStorageService
            {
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "Hamburger", Price = 22m, Category = "Yiyecek" }
                }
            };
            var productService = new ProductService(storage);

            // Act
            bool updated = productService.UpdateProduct(1, "Cheeseburger", 28m, "Fast Food");

            // Assert
            Assert.True(updated);
            Assert.Equal("Cheeseburger", storage.Products[0].Name);
            Assert.Equal(28m, storage.Products[0].Price);
            Assert.Equal("Fast Food", storage.Products[0].Category);
        }

        [Fact]
        public void SearchProducts_ShouldFilterByKeyword()
        {
            // Arrange
            var storage = new FakeStorageService
            {
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "Hamburger", Category = "Yiyecek" },
                    new Product { Id = 2, Name = "Coca Cola", Category = "İçecek" },
                    new Product { Id = 3, Name = "Fanta", Category = "İçecek" }
                }
            };
            var productService = new ProductService(storage);

            // Act
            var results = productService.SearchProducts("cola");

            // Assert
            Assert.Single(results);
            Assert.Equal("Coca Cola", results[0].Name);
        }

        [Fact]
        public void DeleteProduct_ShouldRemoveProduct()
        {
            // Arrange
            var storage = new FakeStorageService
            {
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "Hamburger", Price = 22m, Category = "Yiyecek" },
                    new Product { Id = 2, Name = "Su", Price = 3m, Category = "İçecek" }
                }
            };
            var productService = new ProductService(storage);

            // Act
            bool deleted = productService.DeleteProduct(1);

            // Assert
            Assert.True(deleted);
            Assert.Single(storage.Products);
            Assert.Equal("Su", storage.Products[0].Name);
        }

        [Fact]
        public void DeleteProduct_NonExistentId_ShouldReturnFalse()
        {
            // Arrange
            var storage = new FakeStorageService
            {
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "Hamburger", Price = 22m }
                }
            };
            var productService = new ProductService(storage);

            // Act
            bool deleted = productService.DeleteProduct(999);

            // Assert
            Assert.False(deleted);
            Assert.Single(storage.Products);
        }

        [Fact]
        public void SearchProducts_EmptyKeyword_ShouldReturnAll()
        {
            // Arrange
            var storage = new FakeStorageService
            {
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "Hamburger" },
                    new Product { Id = 2, Name = "Su" },
                    new Product { Id = 3, Name = "Coca Cola" }
                }
            };
            var productService = new ProductService(storage);

            // Act
            var results = productService.SearchProducts("");

            // Assert
            Assert.Equal(3, results.Count);
        }

        [Fact]
        public void SearchProducts_ByCategory_ShouldFilterCorrectly()
        {
            // Arrange
            var storage = new FakeStorageService
            {
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "Hamburger", Category = "Yiyecek" },
                    new Product { Id = 2, Name = "Coca Cola", Category = "İçecek" },
                    new Product { Id = 3, Name = "Su", Category = "İçecek" }
                }
            };
            var productService = new ProductService(storage);

            // Act
            var results = productService.SearchProducts("İçecek");

            // Assert
            Assert.Equal(2, results.Count);
        }

        [Fact]
        public void GetCategories_ShouldReturnDistinctCategoriesAndDefaults()
        {
            // Arrange
            var storage = new FakeStorageService
            {
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "Elma", Category = "Meyve" },
                    new Product { Id = 2, Name = "Armut", Category = "Meyve" },
                    new Product { Id = 3, Name = "Kola", Category = "İçecek" }
                }
            };
            var productService = new ProductService(storage);

            // Act
            var categories = productService.GetCategories();

            // Assert
            Assert.Contains("Meyve", categories);
            Assert.Contains("Yiyecek", categories); // Default
            Assert.Contains("İçecek", categories); // From product and Default
            Assert.Contains("Tatlı", categories); // Default
            Assert.Contains("Genel", categories); // Default
            Assert.Equal(categories.Count, categories.Distinct().Count()); // Ensure no duplicates
        }
    }
}
