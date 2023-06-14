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
    /// Interaction logic for UpdateVehicleEntryWindow.xaml
    /// </summary>
    public partial class UpdateVehicleEntryWindow : Window
    {
        private IDatabaseData _db;

        public event EventHandler EntryUpdated;
        private VehicleEntriesFullModel _entry;

        public UpdateVehicleEntryWindow(IDatabaseData db)
        {
            _db = db;
            InitializeComponent();
        }

        public void PopulateWindow(VehicleEntriesFullModel entry)
        {
            _entry = entry;
            licensePlateTextBlock.DataContext = _entry;
            fullNameTextBlock.DataContext = _entry;
            entryTimeTextBlock.DataContext = _entry;
        }

        private void timeNowButton_Click(object sender, RoutedEventArgs e)
        {
            exitTimeTextBox.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if(exitTimeTextBox.Text != null)
            {
                DateTime date;

                if (DateTime.TryParse(exitTimeTextBox.Text, out date))
                {
                    if(date <= DateTime.Now)
                    {
                        _db.UpdateVehicleExit(_entry.Id, date);

                        EntryUpdated?.Invoke(this, EventArgs.Empty);
                        this.Close();
                    }

                }
            }
        }
    }
}
