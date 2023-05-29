using Gatekeeper.Desktop.Pages;
using GatekeeperLib.Data;
using GatekeeperLib.Databases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Windows;

namespace Gatekeeper.Desktop
{
    public partial class App : Application
    {
        public static ServiceProvider serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();
            services.AddTransient<MainWindow>();
            services.AddTransient<PersonsPage>();
            services.AddTransient<PersonEntriesPage>();
            services.AddTransient<ISqlDataAccess, SqlDataAccess>();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration config = builder.Build();
            services.AddSingleton(config);

            // Tady můžeme udělat if pokud bychom potřebovali jinou DB (sqlite)
            services.AddTransient<IDatabaseData, SqlData>();

            serviceProvider = services.BuildServiceProvider();
            var mainWindow = serviceProvider.GetService<MainWindow>();

            mainWindow.Show();
        }

    }
}
