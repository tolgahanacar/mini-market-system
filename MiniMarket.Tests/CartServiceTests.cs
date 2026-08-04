using MiniMarket.Models;
using MiniMarket.Services;
using Xunit;

namespace MiniMarket.Tests
{
    public class CartServiceTests
    {
        [Fact]
        public void AddItem_ShouldAddProductToCart()
        {
            // Arrange
            var cartService = new CartService();
            var product = new Product { Id = 1, Name = "Hamburger", Price = 20m };

            // Act
            cartService.AddItem(product, 2);

            // Assert
            Assert.Single(cartService.Items);
            Assert.Equal(2, cartService.Items[0].Quantity);
            Assert.Equal(40m, cartService.TotalAmount);
        }

        [Fact]
        public void AddItem_ExistingProduct_ShouldIncreaseQuantity()
        {
            // Arrange
            var cartService = new CartService();
            var product = new Product { Id = 1, Name = "Hamburger", Price = 20m };

            // Act
            cartService.AddItem(product, 2);
            cartService.AddItem(product, 3);

            // Assert
            Assert.Single(cartService.Items);
            Assert.Equal(5, cartService.Items[0].Quantity);
            Assert.Equal(100m, cartService.TotalAmount);
        }

        [Fact]
        public void RemoveItem_ShouldRemoveProductFromCart()
        {
            // Arrange
            var cartService = new CartService();
            var product = new Product { Id = 1, Name = "Hamburger", Price = 20m };
            cartService.AddItem(product, 1);
            var item = cartService.Items[0];

            // Act
            bool result = cartService.RemoveItem(item);

            // Assert
            Assert.True(result);
            Assert.Empty(cartService.Items);
            Assert.Equal(0m, cartService.TotalAmount);
        }

        [Fact]
        public void Clear_ShouldRemoveAllItems()
        {
            // Arrange
            var cartService = new CartService();
            cartService.AddItem(new Product { Id = 1, Name = "Hamburger", Price = 20m }, 1);
            cartService.AddItem(new Product { Id = 2, Name = "Su", Price = 3m }, 2);

            // Act
            cartService.Clear();

            // Assert
            Assert.Empty(cartService.Items);
            Assert.Equal(0m, cartService.TotalAmount);
        }
    }
}
