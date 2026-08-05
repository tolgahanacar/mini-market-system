using System;

namespace MiniMarket.Services;

public class WalletService(IStorageService storageService)
{
    private readonly IStorageService _storageService = storageService;
    private decimal _balance = storageService.LoadBalance();

        public decimal Balance => _balance;

        public bool Deposit(decimal amount)
        {
            if (amount <= 0) return false;
            _balance += amount;
            _storageService.SaveBalance(_balance);
            return true;
        }

        public bool CanAfford(decimal amount)
        {
            return _balance >= amount;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0 || !CanAfford(amount)) return false;
            _balance -= amount;
            _storageService.SaveBalance(_balance);
            return true;
        }
}
