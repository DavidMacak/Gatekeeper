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
    public partial class FindOrCreatePersonPage : Page, IFindOrCreatePage
    {
        private IDatabaseData _db;
        private List<PersonModel> _persons;
        private string _lastname;
        public object SelectedItem { get; set; }

        public object GetSelectedItem()
        {
            if(personListView.SelectedItems != null)
            {
                SelectedItem = personListView.SelectedItem as PersonModel;
            }
            return SelectedItem;
        }

        public FindOrCreatePersonPage(IDatabaseData db)
        {
            _db = db;
            InitializeComponent();
        }
        private void LoadPersons()
        {
            if (lastNameTextBox.Text.Length > 0)
            {
                _persons = _db.FindPersons(lastNameTextBox.Text);
            }
            else
            {
                _persons = _db.LoadPersons();
            }

            personListView.ItemsSource = _persons;

        }
        private void findByLastNameButton_Click(object sender, RoutedEventArgs e)
        {
            LoadPersons();
        }

        private void createNewPersonButton_Click(object sender, RoutedEventArgs e)
        {
            var createPersonWindow = App.serviceProvider!.GetService<CreatePersonWindow>();
            createPersonWindow.Owner = App.Current.MainWindow;
            createPersonWindow.PersonCreated += OnPersonCreated;
            createPersonWindow.lastNameTextBox.Text = lastNameTextBox.Text;
            createPersonWindow.ShowDialog();
            if (lastNameTextBox.Text.Length > 0)
                createPersonWindow.lastNameTextBox.Text = lastNameTextBox.Text;
            createPersonWindow.PersonCreated -= OnPersonCreated;
        }

        private void OnPersonCreated(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                lastNameTextBox.Text = (sender as CreatePersonWindow)!.lastNameTextBox.Text;
            }
            LoadPersons();

            if (personListView.Items.Count > 0)
                personListView.SelectedIndex = 0;
        }
    }
}
