using Gatekeeper.Desktop.Windows;
using GatekeeperLib.Data;
using GatekeeperLib.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Gatekeeper.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for Persons.xaml
    /// </summary>
    public partial class PersonsPage : Page
    {
        private IDatabaseData _db;
        private List<PersonModel> persons;

        public PersonsPage(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
            LoadPersons();
        }

        private void LoadPersons()
        {
            persons = _db.LoadPersons();
            personsListView.ItemsSource = persons;
        }

        private void createPersonButton_Click(object sender, RoutedEventArgs e)
        {
            var createPersonWindow = App.serviceProvider.GetService<CreatePersonWindow>();

            createPersonWindow.PersonCreated += OnPersonCreated;
            createPersonWindow.Owner = Application.Current.MainWindow;
            createPersonWindow.ShowDialog();
            createPersonWindow.PersonCreated -= OnPersonCreated;
        }

        private void OnPersonCreated(object? sender, EventArgs e)
        {
            LoadPersons();
        }

        private void reloadButton_Click(object sender, RoutedEventArgs e)
        {
            LoadPersons();
        }
    }
}
