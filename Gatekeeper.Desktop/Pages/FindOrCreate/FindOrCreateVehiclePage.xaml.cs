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
    public partial class FindOrCreateVehiclePage : Page, IFindOrCreatePage
    {
        private IDatabaseData _db;
        private List<VehicleModel> _vehicles;
        private string _licensePlate;
        public object SelectedItem { get; set; }

        public FindOrCreateVehiclePage(IDatabaseData db)
        {
            _db = db;
            InitializeComponent();
        }
        public object GetSelectedItem()
        {
            if (vehicleListView.SelectedItems != null)
            {
                SelectedItem = vehicleListView.SelectedItem as VehicleModel;
            }
            return SelectedItem;
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
        private void findByLicensePlateButton_Click(object sender, RoutedEventArgs e)
        {
            LoadVehicles();
        }

        private void createNewVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            var createVehicleWindow = App.serviceProvider!.GetService<CreateVehicleWindow>();
            createVehicleWindow.Owner = App.Current.MainWindow;
            createVehicleWindow.VehicleCreated += OnVehicleCreated;
            if (licensePlateTextBox.Text.Length > 0)
                createVehicleWindow.licensePlateTextBox.Text = licensePlateTextBox.Text;
            createVehicleWindow.ShowDialog();
            createVehicleWindow.VehicleCreated -= OnVehicleCreated;
        }

        private void OnVehicleCreated(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                licensePlateTextBox.Text = (sender as CreateVehicleWindow)!.licensePlateTextBox.Text;
            }
            LoadVehicles();

            if (vehicleListView.Items.Count > 0)
                vehicleListView.SelectedIndex = 0;
        }
    }
}
