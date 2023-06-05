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
    public partial class VehiclesPage : Page
    {
        private IDatabaseData _db;
        private List<VehicleModel>? vehicles;

        public VehiclesPage(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
            LoadVehicles();
        }

        public void LoadVehicles()
        {
            vehicles = _db.LoadVehicles();
            vehicleListView.ItemsSource = vehicles;
        }

        private void createVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            var createVehicleWindow = App.serviceProvider!.GetService<CreateVehicleWindow>();

            createVehicleWindow!.VehicleCreated += OnPropertyChanged;       // ! dává vědět kompileru že není null
            createVehicleWindow.Owner = App.Current.MainWindow;
            createVehicleWindow.ShowDialog();
            createVehicleWindow.VehicleCreated -= OnPropertyChanged;
        }

        private void OnPropertyChanged(object? sender, EventArgs e)
        {
            LoadVehicles();
        }

        private void editVehicleButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void reloadButton_Click(object sender, RoutedEventArgs e)
        {
            LoadVehicles();
        }
    }
}
