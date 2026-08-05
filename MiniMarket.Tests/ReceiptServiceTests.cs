using System.Collections.Generic;
using MiniMarket.Models;
using MiniMarket.Services;
using Xunit;

namespace MiniMarket.Tests
{
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

        [Fact]
        public void GetTransactionHistory_ShouldReturnAllTransactions()
        {
            // Arrange
            var storage = new FakeStorageService
            {
                Transactions = new List<SaleTransaction>
                {
                    new SaleTransaction { TotalAmount = 50m },
                    new SaleTransaction { TotalAmount = 30m }
                }
            };
            var receiptService = new ReceiptService(storage);

            // Act
            var history = receiptService.GetTransactionHistory();

            // Assert
            Assert.Equal(2, history.Count);
        }
    }
}
