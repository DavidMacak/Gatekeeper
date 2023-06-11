using Gatekeeper.Desktop.Pages;
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

        private FindOrCreateVehiclePage _vehiclePage;
        private FindOrCreatePersonPage _personPage;

        public CreateVehicleEntryWindow(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;

            _vehiclePage = App.serviceProvider.GetService<FindOrCreateVehiclePage>();
            _personPage = App.serviceProvider.GetService<FindOrCreatePersonPage>();
            vehicleFrame.Content = _vehiclePage;
            personFrame.Content = _personPage;

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

        private void createEntryButton_Click(object sender, RoutedEventArgs e)
        {
            if (_vehiclePage.vehicleListView.SelectedItem != null && _personPage.personListView.SelectedItem != null && dateTimeTextBox.Text.Length > 0)
            {
                DateTime time;

                if (DateTime.TryParse(dateTimeTextBox.Text, out time))
                {
                    _db.CreateVehicleEntry((_vehiclePage.vehicleListView.SelectedItem as VehicleModel).Id,
                                           (_personPage.personListView.SelectedItem as PersonModel).Id,
                                           time);

                    EntryCreated?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
            }

        }

    }
}
