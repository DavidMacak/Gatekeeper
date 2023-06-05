using GatekeeperLib.Data;
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
    /// Interaction logic for CreateVehicleWindow.xaml
    /// </summary>
    public partial class CreateVehicleWindow : Window
    {
        private IDatabaseData _db;
        public event EventHandler? VehicleCreated;

        public CreateVehicleWindow(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
        }

        private void createVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            if(licensePlateTextBox.Text.Length > 0)
            {
                _db.CreateVehicle(licensePlateTextBox.Text);
                VehicleCreated?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
        }
    }
}
