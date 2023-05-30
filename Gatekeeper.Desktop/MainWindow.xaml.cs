using Gatekeeper.Desktop.Pages;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using GatekeeperLib.Data;

namespace Gatekeeper.Desktop
{
    public partial class MainWindow : Window
    {
        private PersonsPage personsPage;
        private PersonEntriesPage personEntriesPage;
        private readonly IDatabaseData _db;

        public MainWindow(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
            mainFrame.Content = App.serviceProvider.GetService<HomePage>();
        }

        private void personsButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = App.serviceProvider.GetService<PersonsPage>();
        }

        private void personEntriesButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = App.serviceProvider.GetService<PersonEntriesPage>();
        }

        private void homePageButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = App.serviceProvider.GetService<HomePage>();
        }

        private void vehiclesButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = App.serviceProvider.GetService<VehiclesPage>();
        }

        private void vehicleEntriesButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = App.serviceProvider.GetService<VehicleEntriesPage>();
        }
    }
}
