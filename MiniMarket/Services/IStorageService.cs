using System.Collections.Generic;
using MiniMarket.Models;

namespace MiniMarket.Services
{
    public interface IStorageService
    {
        List<Product> LoadProducts();
        void SaveProducts(List<Product> products);
        decimal LoadBalance();
        void SaveBalance(decimal balance);
        List<SaleTransaction> LoadTransactions();
        void SaveTransactions(List<SaleTransaction> transactions);
    }
}
