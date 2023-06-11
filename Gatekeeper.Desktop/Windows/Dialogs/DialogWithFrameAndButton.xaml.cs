using Gatekeeper.Desktop.Pages;
using GatekeeperLib.Models;
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
    public partial class DialogWithFrameAndButton : Window
    {
        public event EventHandler ValueEdited;
        private object _selectedItem;
        private readonly Type _modelType;
        private IFindOrCreatePage _page;

        public DialogWithFrameAndButton(Type modelType)
        {
            InitializeComponent();
            _modelType = modelType;


            if( _modelType == typeof(PersonModel))
            {
                _page = App.serviceProvider.GetService<FindOrCreatePersonPage>();
            }
            else if(_modelType == typeof(VehicleModel))
            {
                _page = App.serviceProvider.GetService<FindOrCreateVehiclePage>();
            }

            mainFrame.Content = _page;

        }

        private void ListViewSelectionChanged(object? sender, EventArgs e)
        {
            _selectedItem = sender;
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            _selectedItem = _page.GetSelectedItem();
            if( _selectedItem != null )
            {
                ValueEdited?.Invoke(_selectedItem, EventArgs.Empty);
                this.Close();
            }
        }
    }
}
