﻿using Gatekeeper.Desktop.Pages;
using GatekeeperLib;
using GatekeeperLib.Data;
using GatekeeperLib.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace Gatekeeper.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for CreatePersonWindow.xaml
    /// </summary>
    public partial class CreatePersonWindow : Window
    {
        private IDatabaseData _db;
        public event EventHandler PersonCreated;

        public CreatePersonWindow(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
        }

        private void createPersonButton_Click(object sender, RoutedEventArgs e)
        {
            bool success = false;
            PersonModel person = new PersonModel();
            
            if(firstNameTextBox.Text.IsPersonNameInCorrectFormat())
            {
                person.FirstName = firstNameTextBox.Text.FirstLetterToCapital();
                success = true;
            }

            if (lastNameTextBox.Text.IsPersonNameInCorrectFormat())
            {
                person.LastName = lastNameTextBox.Text.FirstLetterToCapital();
                success = true;
            }
            else 
            { 
                success = false;
            }

            if (success)
            {
                _db.CreatePerson(person.FirstName, person.LastName);
                PersonCreated?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
        }


    }
}
