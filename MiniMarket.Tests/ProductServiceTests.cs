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
    }

    public class ReceiptServiceTests
    {
        [Fact]
        public void ProcessCheckout_ShouldGenerateReceiptAndSaveTransaction()
        {
            // Arrange
            var storage = new FakeStorageService();
            var receiptService = new ReceiptService(storage);
            var cartItems = new List<CartItem>
            {
                new CartItem { Product = new Product { Id = 1, Name = "Hamburger", Price = 25m }, Quantity = 2 }
            };

            // Act
            var transaction = receiptService.ProcessCheckout(cartItems, 50m, 100m, 50m);

            // Assert
            Assert.NotNull(transaction);
            Assert.Equal(50m, transaction.TotalAmount);
            Assert.Equal(100m, transaction.PreviousBalance);
            Assert.Equal(50m, transaction.RemainingBalance);
            Assert.Contains("Hamburger", transaction.ReceiptText);
            Assert.Contains("Ara Toplam", transaction.ReceiptText);
            Assert.Contains("KDV", transaction.ReceiptText);
            Assert.Single(storage.Transactions);
        }
    }
}
