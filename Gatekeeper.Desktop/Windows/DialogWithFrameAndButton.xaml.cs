using Gatekeeper.Desktop.Pages;
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
        public event EventHandler ChangeConfirmed;

        public DialogWithFrameAndButton()
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            if(mainFrame.Content.GetType() == typeof(FindOrCreatePersonPage))
            {
                //mainFrame.Content.personListView.SelectedItem
                ChangeConfirmed?.Invoke(sender, EventArgs.Empty);
            }
            else if(mainFrame.Content.GetType() == typeof(FindOrCreateVehiclePage))
            {

            }
        }
    }
}
