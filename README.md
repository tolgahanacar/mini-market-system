# Mini Market System 🛒

![.NET](https://img.shields.io/badge/.NET-8.0-blueviolet)
![Windows Forms](https://img.shields.io/badge/UI-Windows%20Forms-blue)
![Architecture](https://img.shields.io/badge/Architecture-OOP-success)

A modern, C#-based Mini Market shopping system designed to provide an easy-to-use checkout and cart management experience. This project was originally developed as an educational tool for university students studying computer science and has been heavily modernized.

## 🚀 Features

- **Modern OOP Architecture**: Clean separation between Data Models (`Product`, `CartItem`) and the UI layer.
- **Dynamic Cart Management**: Add/remove products seamlessly using dynamic `DataGridView` tables instead of static TextBoxes.
- **Wallet System**: Load balance dynamically and process payments based on available funds.
- **Smart Checkout**: Automatically validates cart totals against the wallet balance and warns on insufficient funds.
- **Printable Receipt**: Generates a detailed string-based checkout receipt (Alışveriş Fişi) summarizing the purchase and remaining balance upon successful checkout.
- **Polished UI**: Transparent containers with high-resolution scaling icons.

## 🛠️ Technology Stack

- **Framework**: .NET 8.0 (SDK-Style)
- **Language**: C#
- **UI Framework**: Windows Forms (WinForms)

## 📦 How to Build & Run

You can easily run this project using the .NET CLI or Visual Studio.

### Via .NET CLI (Terminal)

```bash
# Clone the repository and navigate into it
cd MiniMarket

# Build and run the application
dotnet run
```

### Via Visual Studio
1. Open the `MiniMarketSystem.sln` solution file in **Visual Studio 2022**.
2. Make sure you have the *.NET Desktop Development* workload installed.
3. Press `F5` to build and run the project.

## 📜 Changelog
Check the [CHANGELOG.md](CHANGELOG.md) file to see the latest updates and version history.

## 👨‍💻 Author
**Tolgahan Acar**
