﻿using GatekeeperLib.Data;
using GatekeeperLib.Models;
using System.Windows;

namespace Gatekeeper.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for CreatePersonWindow.xaml
    /// </summary>
    public partial class CreatePersonWindow : Window
    {
        private IDatabaseData _db;

        public CreatePersonWindow(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
        }

        private void createPersonButton_Click(object sender, RoutedEventArgs e)
        {
            PersonModel person = new PersonModel();

            if(firstNameTextBox.Text.Length > 0 && firstNameTextBox.Text.Length <= 50)
            {
                person.FirstName = firstNameTextBox.Text;
            }
            if (lastNameTextBox.Text.Length > 0 && lastNameTextBox.Text.Length <= 50)
            {
                person.LastName = lastNameTextBox.Text;
            }

            _db.CreatePerson(person.FirstName, person.LastName);
            this.Close();
        }
    }
}
