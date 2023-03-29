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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace A2TuyetMaiPham
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WorldDBTableAdapters.ContinentTableAdapter adpContinent;
        private WorldDBTableAdapters.CountryTableAdapter adpCountry;
        
        private WorldDB.ContinentDataTable tblContinent;
        private WorldDB.CountryDataTable tblCountry;
        public MainWindow()
        {
            InitializeComponent();

            adpContinent = new WorldDBTableAdapters.ContinentTableAdapter();
            tblContinent = new WorldDB.ContinentDataTable();

            adpCountry = new WorldDBTableAdapters.CountryTableAdapter();
            tblCountry = new WorldDB.CountryDataTable();

        }

        private void GetAllContinents()
        {
            adpContinent.FillContinent(tblContinent);
            
            cmbContinents.Items.Clear();
            
            cmbContinents.ItemsSource = tblContinent.DefaultView;
            cmbContinents.DisplayMemberPath = "ContinentName";
            cmbContinents.SelectedValuePath = "ContinentId";

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetAllContinents();
        }

        private void GetCountriesInContinent()
        {
            int continentId = Convert.ToInt32(cmbContinents.SelectedValue);
            adpCountry.FillCountries(tblCountry, continentId);
            
        }

        private void cmbContinents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetCountriesInContinent();

            lstCountries.ItemsSource = tblCountry.DefaultView;
            lstCountries.DisplayMemberPath = "CountryName";
        }
    }
}
