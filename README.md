# Mini Market System 🛒

![.NET](https://img.shields.io/badge/.NET-8.0-blueviolet)
![Windows Forms](https://img.shields.io/badge/UI-Windows%20Forms-blue)
![Architecture](https://img.shields.io/badge/Architecture-Clean%20Architecture-success)
![Tests](https://img.shields.io/badge/Tests-xUnit-brightgreen)

A modern, C#-based Mini Market shopping system designed to provide a rich checkout, cart management, wallet system, and transaction history experience. Originally developed as an educational tool for university computer science students, heavily modernized into Clean Architecture with .NET 8.0.

## 🚀 Key Features

- **Clean Architecture & Service Layer**: Complete separation of UI (`MainForm`), Business Logic (`ProductService`, `WalletService`, `CartService`, `ReceiptService`), and Persistence (`JsonStorageService`).
- **JSON Data Persistence**: Automatic auto-saving and loading of product catalog, wallet balance, and purchase receipts to JSON files.
- **Dynamic Cart Management**: Add/remove products seamlessly using `DataGridView` tables, quantity controls, and live cart total calculations.
- **Catalog Search & Custom Products**: Live keyword search/filtering and dynamic new product creation window (`AddProductForm`).
- **Wallet & Payment System**: Load funds dynamically, validate transactions against balance, and deduct funds securely.
- **Interactive Receipt Dialog**: Displays formatted ASCII receipts with options to copy text to clipboard or export directly to `.txt` files.
- **Transaction History**: Comprehensive purchase log viewer (`HistoryForm`) to inspect past receipts and orders anytime.
- **Automated Unit Tests**: Built-in `MiniMarket.Tests` (xUnit) suite validating all core service logic.

## 🛠️ Technology Stack

- **Framework**: .NET 8.0 (SDK-Style)
- **Language**: C# 12
- **UI Framework**: Windows Forms (WinForms)
- **Testing**: xUnit

## 📦 How to Build & Run

### Via .NET CLI (Terminal)

```bash
# Build and run the application
dotnet run --project MiniMarket/MiniMarket.csproj

# Run unit tests
dotnet test
```

### Via Visual Studio
1. Open the `MiniMarketSystem.sln` solution file in **Visual Studio 2022**.
2. Make sure you have the *.NET Desktop Development* workload installed.
3. Press `F5` to build and run the project, or use **Test Explorer** to run xUnit tests.

## 📜 Changelog
Check the [CHANGELOG.md](CHANGELOG.md) file to see the latest updates and version history.

## 👨‍💻 Author
**Tolgahan Acar**
