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
    public partial class PersonEntriesPage : Page
    {
        IDatabaseData _db;

        public PersonEntriesPage(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
            LoadPersonEntries();
        }

        private void LoadPersonEntries()
        {
            List<PersonEntriesFullModel> entries = _db.LoadPersonEntries();

            personEntriesListView.ItemsSource = entries;
        }
        private void createPersonEntryButton_Click(object sender, RoutedEventArgs e)
        {
            var createPersonEntryWindow = App.serviceProvider.GetService<CreatePersonEntryWindow>();

            createPersonEntryWindow.EntryCreated += OnPropertyChanged;
            createPersonEntryWindow.Owner = Application.Current.MainWindow;
            createPersonEntryWindow.ShowDialog();
            createPersonEntryWindow.EntryCreated -= OnPropertyChanged;
        }

        private void editPersonEntryButton_Click(object sender, RoutedEventArgs e)
        {
            if(personEntriesListView.SelectedItem != null)
            {
                PersonEntriesFullModel personEntry = (personEntriesListView.SelectedItem as PersonEntriesFullModel)!;

                if(personEntry.ExitTime == null)
                {
                    var updatePersonEntryWindow = App.serviceProvider!.GetService<UpdatePersonEntryWindow>();

                    updatePersonEntryWindow!.PopulateWindow((personEntriesListView.SelectedItem as PersonEntriesFullModel)!);

                    updatePersonEntryWindow.ExitTimeSaved += OnPropertyChanged;
                    updatePersonEntryWindow.Owner = Application.Current.MainWindow;
                    updatePersonEntryWindow.ShowDialog();
                    updatePersonEntryWindow.ExitTimeSaved -= OnPropertyChanged;
                }
            }
        }

        private void reloadButton_Click(object sender, RoutedEventArgs e)
        {
            LoadPersonEntries();
        }

        private void OnPropertyChanged(object? sender, EventArgs e)
        {
            LoadPersonEntries();
        }
    }
}
