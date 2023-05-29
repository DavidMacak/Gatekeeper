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
        }

        private void personsButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = App.serviceProvider.GetService<PersonsPage>();
        }

        private void personEntriesButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = App.serviceProvider.GetService<PersonEntriesPage>();
        }
    }
}
