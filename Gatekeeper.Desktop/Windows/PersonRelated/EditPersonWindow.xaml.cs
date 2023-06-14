using GatekeeperLib;
using GatekeeperLib.Data;
using GatekeeperLib.Models;
using Microsoft.Extensions.Configuration;
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
    /// Interaction logic for EditPersonWindow.xaml
    /// </summary>
    public partial class EditPersonWindow : Window
    {
        IDatabaseData _db;
        PersonModel _person;
        public event EventHandler PersonEdited;

        public EditPersonWindow(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
        }

        public void PopulateEditPersonWindow(PersonModel data)
        {
            _person = data;
            firstNameTextBlock.Text = _person.FirstName;
            lastNameTextBlock.Text = _person.LastName;

            firstNameTextBox.Text = _person.FirstName;
            lastNameTextBox.Text = _person.LastName;
        }

        private void savePersonButton_Click(object sender, RoutedEventArgs e)
        {
            bool isGoodFormat = false;

            if(firstNameTextBox.Text.IsPersonNameInCorrectFormat())
            {
                isGoodFormat = true;
            }

            if(lastNameTextBox.Text.IsPersonNameInCorrectFormat())
            {
                isGoodFormat = true;
            }
            else
            {
                isGoodFormat = false;
            }

            if(isGoodFormat)
            {
                _db.EditPerson(_person.Id, firstNameTextBox.Text.FirstLetterToCapital(), lastNameTextBox.Text.FirstLetterToCapital());
                PersonEdited?.Invoke(this, EventArgs.Empty);
                this.Close();

            }
        }
    }
}
