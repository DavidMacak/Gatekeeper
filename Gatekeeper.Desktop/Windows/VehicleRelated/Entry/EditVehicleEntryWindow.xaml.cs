using GatekeeperLib.Data;
using GatekeeperLib.Models;
using System;
using System.Windows;

namespace Gatekeeper.Desktop.Windows
{
    public partial class EditVehicleEntryWindow : Window
    {
        private IDatabaseData _db;
        public event EventHandler EntryEdited;
        private VehicleEntriesFullModel _entryFullModel;

        public EditVehicleEntryWindow(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
        }

        public void PopulateDialogWindow(VehicleEntriesFullModel entryFullModel)
        {
            _entryFullModel = entryFullModel;
            UpdateUI();
        }

        private void UpdateUI()
        {
            licensePlateTextBlock.Text = null;
            licensePlateTextBlock.Text = _entryFullModel.LicensePlate;

            fullNameTextBlock.Text = null;
            fullNameTextBlock.Text = _entryFullModel.FirstName + " " + _entryFullModel.LastName;

            if (entryTimeTextBox.Text.Length == 0)
            {
                entryTimeTextBox.Text = null;
                entryTimeTextBox.Text = _entryFullModel.EnterTime.ToString("dd.MM.yyyy HH:mm:ss");
            }

            if(exitTimeTextBox.Text.Length == 0)
            {
                exitTimeTextBox.Text = null;
                if(_entryFullModel.ExitTime != null)
                {
                    exitTimeTextBox.Text = ((DateTime)_entryFullModel.ExitTime).ToString("dd.MM.yyyy HH:mm:ss");
                }
            }

        }

        private void changePersonButton_Click(object sender, RoutedEventArgs e)
        {
            var dialogWindow = new DialogWithFrameAndButton(typeof(PersonModel));
            dialogWindow.Owner = this;

            dialogWindow.ValueEdited += DialogWindow_ChangeConfirmed;
            dialogWindow.ShowDialog();
            dialogWindow.ValueEdited -= DialogWindow_ChangeConfirmed;
        }

        private void DialogWindow_ChangeConfirmed(object? sender, EventArgs e)
        {
            if(sender is PersonModel) 
            {
                var person = (PersonModel)sender;
                _entryFullModel.ChangePerson(person);

            }
            else if(sender is VehicleModel)
            {
                var vehicle = (VehicleModel)sender;
                _entryFullModel.ChangeVehicle(vehicle);
            }
            UpdateUI();
        }

        private void changeLicensePlateButton_Click(object sender, RoutedEventArgs e)
        {
            var dialogWindow = new DialogWithFrameAndButton(typeof(VehicleModel));
            dialogWindow.Owner = this;

            dialogWindow.ValueEdited += DialogWindow_ChangeConfirmed;
            dialogWindow.ShowDialog();
            dialogWindow.ValueEdited -= DialogWindow_ChangeConfirmed;
        }

        private void entryTimeNowButton_Click(object sender, RoutedEventArgs e)
        {
            entryTimeTextBox.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        }

        private void exitTimeNowButton_Click(object sender, RoutedEventArgs e)
        {
            exitTimeTextBox.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if(entryTimeTextBox.Text.Length > 0 && exitTimeTextBox.Text.Length > 0)
            {
                DateTime enterTime;
                DateTime exitTime;

                if(DateTime.TryParse(entryTimeTextBox.Text, out enterTime) && DateTime.TryParse(exitTimeTextBox.Text, out exitTime))
                {
                    _db.EditVehicleEntry(_entryFullModel.Id, _entryFullModel.PersonId, _entryFullModel.VehicleId, enterTime, exitTime);
                    EntryEdited?.Invoke(this, e);
                    this.Close();
                }
            }
            else if(entryTimeTextBox.Text.Length > 0 && exitTimeTextBox.Text.Length == 0)
            {
                DateTime enterTime;

                if (DateTime.TryParse(entryTimeTextBox.Text, out enterTime))
                {
                    _db.EditVehicleEntry(_entryFullModel.Id, _entryFullModel.PersonId, _entryFullModel.VehicleId, enterTime);
                    EntryEdited?.Invoke(this, e);
                    this.Close();
                }
            }
        }
    }
}
