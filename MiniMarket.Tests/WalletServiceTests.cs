using System.Collections.Generic;
using MiniMarket.Models;
using MiniMarket.Services;
using Xunit;

namespace MiniMarket.Tests
{
    public class FakeStorageService : IStorageService
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public decimal Balance { get; set; } = 0m;
        public List<SaleTransaction> Transactions { get; set; } = new List<SaleTransaction>();

        public List<Product> LoadProducts() => Products;
        public void SaveProducts(List<Product> products) => Products = products;
        public decimal LoadBalance() => Balance;
        public void SaveBalance(decimal balance) => Balance = balance;
        public List<SaleTransaction> LoadTransactions() => Transactions;
        public void SaveTransactions(List<SaleTransaction> transactions) => Transactions = transactions;
    }

    public class WalletServiceTests
    {
        [Fact]
        public void Deposit_ValidAmount_ShouldIncreaseBalance()
        {
            // Arrange
            var storage = new FakeStorageService { Balance = 50m };
            var wallet = new WalletService(storage);

            // Act
            bool success = wallet.Deposit(30m);

            // Assert
            Assert.True(success);
            Assert.Equal(80m, wallet.Balance);
            Assert.Equal(80m, storage.Balance);
        }

        [Fact]
        public void Withdraw_InsufficientBalance_ShouldFail()
        {
            // Arrange
            var storage = new FakeStorageService { Balance = 20m };
            var wallet = new WalletService(storage);

            // Act
            bool success = wallet.Withdraw(50m);

            // Assert
            Assert.False(success);
            Assert.Equal(20m, wallet.Balance);
        }

        [Fact]
        public void Withdraw_SufficientBalance_ShouldDeductBalance()
        {
            // Arrange
            var storage = new FakeStorageService { Balance = 100m };
            var wallet = new WalletService(storage);

            // Act
            bool success = wallet.Withdraw(40m);

            // Assert
            Assert.True(success);
            Assert.Equal(60m, wallet.Balance);
            Assert.Equal(60m, storage.Balance);
        }
    }
}
