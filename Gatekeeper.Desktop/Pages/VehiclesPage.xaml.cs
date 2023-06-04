using GatekeeperLib.Data;
using GatekeeperLib.Models;
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
        private List<VehicleModel> vehicles;

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

        }

        private void editVehicleButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void reloadButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
