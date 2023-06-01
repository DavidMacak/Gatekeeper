using Gatekeeper.Desktop.Pages;
using Gatekeeper.Desktop.Windows;
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
            services.AddSingleton<PersonsPage>();
            services.AddSingleton<PersonEntriesPage>();                     // tranzient= každé volání = nová instance
            services.AddSingleton<VehiclesPage>();
            services.AddSingleton<VehicleEntriesPage>();
            services.AddTransient<CreatePersonWindow>();
            services.AddTransient<EditPersonWindow>();
            services.AddSingleton<HomePage>();                              // singleton = pokaždé stejné okno
            services.AddTransient<ISqlDataAccess, SqlDataAccess>();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration config = builder.Build();
            services.AddSingleton(config);

            string dbChoice = config.GetValue<string>("DatabaseChoice").ToLower();

            if(dbChoice == "sqldb")
            {
                services.AddTransient<IDatabaseData, SqlData>();

            }
            else
            {
                services.AddTransient<IDatabaseData, SqlData>();
            }

            serviceProvider = services.BuildServiceProvider();
            var mainWindow = serviceProvider.GetService<MainWindow>();

            mainWindow.Show();
        }

    }
}
