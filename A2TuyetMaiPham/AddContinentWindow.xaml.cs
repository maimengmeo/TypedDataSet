using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using static A2TuyetMaiPham.WorldDB;

namespace A2TuyetMaiPham
{
    /// <summary>
    /// Interaction logic for AddContinentWindow.xaml
    /// </summary>
    public partial class AddContinentWindow : Window
    {
        private WorldDBTableAdapters.ContinentTableAdapter adpContinent;
        private bool _isAdded;

        public AddContinentWindow(WorldDBTableAdapters.ContinentTableAdapter adpContinent,
                                    WorldDB.ContinentDataTable tblContinents)
        {
            InitializeComponent();
            this.adpContinent = adpContinent;
        }

        public bool IsAdded { get { return _isAdded; } }

        private void btnAddContinent_Click(object sender, RoutedEventArgs e)
        {
            string continentName = txtInputContinent.Text;

            if (String.IsNullOrWhiteSpace(continentName))
            {
                lblMessage.Content = "Invalid name for new Continent. Try again!";
            }
            else
            {
                lblMessage.Content = "";
                adpContinent.Insert(continentName);
                _isAdded = true;
                MessageBox.Show("New Continent is Added!", "Add Continent", MessageBoxButton.OK, MessageBoxImage.Information);
                txtInputContinent.Text = "";
                txtInputContinent.Focus();
                
                
            }            

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
