using GatekeeperLib.Data;
using GatekeeperLib.Models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Gatekeeper.Desktop.Windows
{
    public partial class CreatePersonEntryWindow : Window
    {
        private IDatabaseData _db;

        public event EventHandler? EntryCreated;
        public CreatePersonEntryWindow(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
        }
        private void currentDateTimeButton_Click(object sender, RoutedEventArgs e)
        {
            entryDateTimeTextBox.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        }

        private void findPersonButton_Click(object sender, RoutedEventArgs e)
        {
            if(lastNameTextBox.Text.Length > 0)
            {
                List<PersonModel> persons = _db.FindPersons(lastNameTextBox.Text);
                personsListView.ItemsSource = persons;
            }
            else
            {
                List<PersonModel> persons = _db.LoadPersons();
                personsListView.ItemsSource = persons;
            }
        }

        private void createEntryButton_Click(object sender, RoutedEventArgs e)
        {
            if(personsListView.SelectedItem != null)
            {
                DateTime date;

                if(DateTime.TryParse(entryDateTimeTextBox.Text, out date))
                {
                    if(date <= DateTime.Now)
                    {
                        PersonModel selectedPerson = (personsListView.SelectedItem as PersonModel)!;
                        _db.CreatePersonEntry(selectedPerson.Id, date);
                        EntryCreated?.Invoke(this, new EventArgs());
                        this.Close();

                    }
                }
            }
        }
    }
}
