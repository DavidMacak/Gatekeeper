using Gatekeeper.Desktop.Pages;
using GatekeeperLib.Data;
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
    public partial class EditVehicleEntryWindow : Window
    {
        private IDatabaseData _db;
        public event EventHandler EntryEdited;

        public EditVehicleEntryWindow(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
        }

        private void changePersonButton_Click(object sender, RoutedEventArgs e)
        {
            //var dialogWindow = App.serviceProvider.GetService<FindOrCreatePersonPage>();
            var dialogWindow = new DialogWithFrameAndButton();
            dialogWindow.mainFrame.Content = App.serviceProvider.GetService<FindOrCreatePersonPage>();
            dialogWindow.ChangeConfirmed += DialogWindow_ChangeConfirmed;
            dialogWindow.ShowDialog();
            dialogWindow.ChangeConfirmed -= DialogWindow_ChangeConfirmed;
        }

        private void DialogWindow_ChangeConfirmed(object? sender, EventArgs e)
        {
            sender.GetType();
        }

        private void changeLicensePlateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void entryTimeNowButton_Click(object sender, RoutedEventArgs e)
        {
            entryTimeTextBox.Text = DateTime.Now.ToString();
        }

        private void exitTimeNowButton_Click(object sender, RoutedEventArgs e)
        {
            exitTimeTextBox.Text = DateTime.Now.ToString();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //_db.EditVehicleEntry(entryId, personId, vehicleId, entryTime, exitTime);
            EntryEdited?.Invoke(this, e);
        }
    }
}
