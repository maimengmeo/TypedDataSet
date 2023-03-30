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
        private WorldDB.ContinentDataTable tblContinents;
        public bool isAdded;

        public AddContinentWindow(WorldDBTableAdapters.ContinentTableAdapter adpContinent,
                                    WorldDB.ContinentDataTable tblContinents)
        {
            InitializeComponent();
            this.adpContinent = adpContinent;
            this.tblContinents = tblContinents;
        }

        public bool IsAdded { get { return isAdded; } }

        private void btnAddContinent_Click(object sender, RoutedEventArgs e)
        {
            string continentName = txtInputContinent.Text;

            if (String.IsNullOrWhiteSpace(continentName))
            {
                lblMessage.Content = "Invalid name for new Continent. Try again!";
            }
            else
            {
                adpContinent.Insert(continentName);
                MessageBox.Show("New Continent is Added!", "Add Continent", MessageBoxButton.OK, MessageBoxImage.Information);
                isAdded = true;               
            }            

        }



    }
}
