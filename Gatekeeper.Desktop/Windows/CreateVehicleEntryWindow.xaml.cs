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
using System.Windows.Shapes;

namespace Gatekeeper.Desktop.Windows
{
    

    public partial class CreateVehicleEntryWindow : Window
    {
        private IDatabaseData _db;
        public event EventHandler EntryCreated;
        private List<PersonModel> _persons;
        private List<VehicleModel> _vehicles;
        private string _lastname;
        private string _licensePlate;

        public CreateVehicleEntryWindow(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
            SetTime();
        }

        private void SetTime()
        {
            dateTimeTextBox.Text = DateTime.Now.ToString();
        }
        private void timeNowButton_Click(object sender, RoutedEventArgs e)
        {
            SetTime();
        }

        private void LoadVehicles()
        {
            if (licensePlateTextBox.Text.Length > 0)
            {
                _vehicles = _db.FindVehicle(licensePlateTextBox.Text);
            }
            else
            {
                _vehicles = _db.LoadVehicles();
            }

            vehicleListView.ItemsSource = _vehicles;

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

        private void findByLicensePlateButton_Click(object sender, RoutedEventArgs e)
        {
            LoadVehicles();
        }

        private void createNewVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            var createVehicleWindow = App.serviceProvider!.GetService<CreateVehicleWindow>();
            createVehicleWindow.Owner = this;
            createVehicleWindow.VehicleCreated += OnVehicleCreated;
            if (licensePlateTextBox.Text.Length > 0)
                createVehicleWindow.licensePlateTextBox.Text = licensePlateTextBox.Text;
            createVehicleWindow.ShowDialog();
            createVehicleWindow.VehicleCreated -= OnVehicleCreated;
        }

        private void OnVehicleCreated(object? sender, EventArgs e)
        {
            if(sender != null)
            {
                licensePlateTextBox.Text = (sender as CreateVehicleWindow)!.licensePlateTextBox.Text;
            }
            LoadVehicles();

            if (vehicleListView.Items.Count > 0)
                vehicleListView.SelectedIndex = 0;
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
            if(sender != null)
            {
                lastNameTextBox.Text = (sender as CreatePersonWindow)!.lastNameTextBox.Text;
            }
            LoadPersons();

            if (personListView.Items.Count > 0)
                personListView.SelectedIndex = 0;
        }

        private void createEntryButton_Click(object sender, RoutedEventArgs e)
        {
            if (vehicleListView.SelectedItem != null && personListView.SelectedItem != null && dateTimeTextBox.Text.Length > 0)
            {
                DateTime time;

                if (DateTime.TryParse(dateTimeTextBox.Text, out time))
                {
                    _db.CreateVehicleEntry((vehicleListView.SelectedItem as VehicleModel).Id,
                                           (personListView.SelectedItem as PersonModel).Id,
                                           time);

                    EntryCreated?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
            }

        }

    }
}
