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
using System.Windows.Shapes;

namespace Gatekeeper.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for EditVehicleWindow.xaml
    /// </summary>
    public partial class EditVehicleWindow : Window
    {
        private IDatabaseData _db;
        private VehicleModel _vehicle;
        public event EventHandler VehicleEdited;


        public EditVehicleWindow(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
        }

        public void PopulateEditVehicleWindow(VehicleModel vehicle)
        {
            _vehicle = vehicle;
            originalLicensePlate.Text = _vehicle!.LicensePlate;
            licensePlateTextBox.Text = _vehicle!.LicensePlate;
        }

        private void saveVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            if(licensePlateTextBox.Text.Length > 0)
            {
                _db.EditVehicle(_vehicle.Id, licensePlateTextBox.Text);
                VehicleEdited?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
        }
    }
}
