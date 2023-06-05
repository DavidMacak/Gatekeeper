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
    public partial class PersonsPage : Page
    {
        private IDatabaseData _db;
        private List<PersonModel>? persons;

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
            var createPersonWindow = App.serviceProvider!.GetService<CreatePersonWindow>();

            createPersonWindow!.PersonCreated += OnPropertyChanged;
            createPersonWindow.Owner = Application.Current.MainWindow;
            createPersonWindow.ShowDialog();
            createPersonWindow.PersonCreated -= OnPropertyChanged;
        }

        private void OnPropertyChanged(object? sender, EventArgs e)
        {
            LoadPersons();
        }

        private void reloadButton_Click(object sender, RoutedEventArgs e)
        {
            LoadPersons();
        }

        private void editPersonButton_Click(object sender, RoutedEventArgs e)
        {
            var editPersonWindow = App.serviceProvider!.GetService<EditPersonWindow>();
            editPersonWindow!.Owner = Application.Current.MainWindow;
            editPersonWindow.PersonEdited += OnPropertyChanged;

            if(personsListView.SelectedItem != null)
            {
                PersonModel selectedPerson = (personsListView.SelectedItem as PersonModel)!;
                editPersonWindow.PopulateEditPersonWindow(selectedPerson);
                editPersonWindow.ShowDialog();
            }

            editPersonWindow.PersonEdited -= OnPropertyChanged;
        }
    }
}
