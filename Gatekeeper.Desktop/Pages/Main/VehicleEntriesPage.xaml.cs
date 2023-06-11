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
    public partial class VehicleEntriesPage : Page
    {
        private IDatabaseData _db;
        private List<VehicleEntriesFullModel> _vehicleEntries;

        public VehicleEntriesPage(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
            LoadEntries();
        }

        private void LoadEntries()
        {
            _vehicleEntries = _db.LoadVehicleEntries();
            vehicleEntriesListView.ItemsSource = _vehicleEntries;
        }
        private void OnPropertyChanged(object? sender, EventArgs e)
        {
            LoadEntries();
        }
        private void reloadButton_Click(object sender, RoutedEventArgs e)
        {
            LoadEntries();
        }

        private void createVehicleEntryButton_Click(object sender, RoutedEventArgs e)
        {
            var createVehicleEntryWindow = App.serviceProvider.GetService<CreateVehicleEntryWindow>();
            createVehicleEntryWindow.Owner = App.Current.MainWindow;
            createVehicleEntryWindow.EntryCreated += OnPropertyChanged;
            createVehicleEntryWindow.ShowDialog();
            createVehicleEntryWindow.EntryCreated -= OnPropertyChanged;

        }

        private void addVehicleEntryButton_Click(object sender, RoutedEventArgs e)
        {
            if(vehicleEntriesListView.SelectedItem != null)
            {
                var updateVehicleEntryWindow = App.serviceProvider.GetService<UpdateVehicleEntryWindow>();
                updateVehicleEntryWindow.Owner = App.Current.MainWindow;
                updateVehicleEntryWindow.EntryUpdated += OnPropertyChanged;
                updateVehicleEntryWindow.PopulateWindow(vehicleEntriesListView.SelectedItem as VehicleEntriesFullModel);
                updateVehicleEntryWindow.ShowDialog();
                updateVehicleEntryWindow.EntryUpdated -= OnPropertyChanged;

            }
        }
        private void editVehicleEntryButton_Click(object sender, RoutedEventArgs e)
        {
            if (vehicleEntriesListView.SelectedItem != null)
            {
                var editVehicleEntryWindow = App.serviceProvider.GetService<EditVehicleEntryWindow>();
                editVehicleEntryWindow.Owner = App.Current.MainWindow;
                editVehicleEntryWindow.EntryEdited += OnPropertyChanged;
                editVehicleEntryWindow.PopulateDialogWindow(vehicleEntriesListView.SelectedItem as VehicleEntriesFullModel);
                editVehicleEntryWindow.ShowDialog();
                editVehicleEntryWindow.EntryEdited -= OnPropertyChanged;

            }
        }
    }
}
