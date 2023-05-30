using Gatekeeper.Desktop.Windows;
using GatekeeperLib.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace Gatekeeper.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for Persons.xaml
    /// </summary>
    public partial class PersonsPage : Page
    {
        private IDatabaseData _db;

        public PersonsPage(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
        }

        private void createPersonButton_Click(object sender, RoutedEventArgs e)
        {
            App.serviceProvider.GetService<CreatePersonWindow>().Show();
        }
    }
}
