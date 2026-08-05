using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using MiniMarket.Services;

[assembly: System.Runtime.Versioning.SupportedOSPlatform("windows")]

namespace MiniMarket
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; } = null!;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            var mainForm = ServiceProvider.GetRequiredService<MainForm>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<IStorageService, JsonStorageService>();
            services.AddSingleton<ProductService>();
            services.AddSingleton<WalletService>();
            services.AddSingleton<CartService>();
            services.AddSingleton<ReceiptService>();

            services.AddTransient<MainForm>();
        }
    }
}
