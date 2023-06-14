using GatekeeperLib.Data;
using GatekeeperLib.Models;
using System;
using System.Collections.Generic;
using System.Windows;


namespace Gatekeeper.Desktop.Windows
{
    public partial class UpdatePersonEntryWindow : Window
    {
        private IDatabaseData _db;
        public event EventHandler ExitTimeSaved;
        private PersonEntriesFullModel _entry;

        public UpdatePersonEntryWindow(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
        }

        public void PopulateWindow(PersonEntriesFullModel data)
        {
            _entry = data;
            firstNameTextBlock.Text = _entry.FirstName;
            lastNameTextBlock.Text = _entry.LastName;
            entryTimeTextBlock.Text = _entry.EntryTime.ToString("dd.MM.yyyy HH:mm:ss");
        }

        private void currentTimeButton_Click(object sender, RoutedEventArgs e)
        {
            exitTimeTextBox.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime date;
            if (DateTime.TryParse(exitTimeTextBox.Text, out date))
            {
                if (date < DateTime.Now)
                {
                    _db.UpdatePersonExitTime(_entry.Id, date);

                    ExitTimeSaved?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
            }
        }
    }
}
