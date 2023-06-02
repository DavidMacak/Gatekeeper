using GatekeeperLib.Data;
using GatekeeperLib.Models;
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
    /// <summary>
    /// Interaction logic for CreatePersonEntryWindow.xaml
    /// </summary>
    public partial class CreatePersonEntryWindow : Window
    {
        private IDatabaseData _db;

        public event EventHandler EntryCreated;
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
        }

        private void createEntryButton_Click(object sender, RoutedEventArgs e)
        {
            if(personsListView.SelectedItem != null)
            {
                PersonModel selectedPerson = personsListView.SelectedItem as PersonModel;
                _db.CreatePersonEntry(selectedPerson.Id, DateTime.Now);
                EntryCreated?.Invoke(this, new EventArgs());
                this.Close();
            }
        }
    }
}
