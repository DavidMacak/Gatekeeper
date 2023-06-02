using Gatekeeper.Desktop.Windows;
using GatekeeperLib.Data;
using GatekeeperLib.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gatekeeper.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for PersonEntriesPage.xaml
    /// </summary>
    public partial class PersonEntriesPage : Page
    {
        IDatabaseData _db;

        public PersonEntriesPage(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
            LoadPersonEntries();
        }

        private void LoadPersonEntries()
        {
            List<PersonEntriesFullModel> entries = _db.LoadPersonEntries();
            personEntriesListView.ItemsSource = entries;
        }
        private void createPersonEntryButton_Click(object sender, RoutedEventArgs e)
        {
            var createEntryWindow = App.serviceProvider.GetService<CreatePersonEntryWindow>();

            createEntryWindow.EntryCreated += OnPropertyChanged;
            createEntryWindow.Owner = Application.Current.MainWindow;
            createEntryWindow.ShowDialog();
            createEntryWindow.EntryCreated -= OnPropertyChanged;
        }

        private void editPersonEntryButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void reloadButton_Click(object sender, RoutedEventArgs e)
        {
            LoadPersonEntries();
        }

        private void OnPropertyChanged(object? sender, EventArgs e)
        {
            LoadPersonEntries();
        }
    }
}
