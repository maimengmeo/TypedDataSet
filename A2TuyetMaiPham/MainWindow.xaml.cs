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
        private WorldDBTableAdapters.CityTableAdapter adpCity;
        
        private WorldDB.ContinentDataTable tblContinents;
        private WorldDB.CountryDataTable tblCountries;
        private WorldDB.CityDataTable tblCities;

        private AddContinentWindow addContinentWindow;
        private AddCountryWindow addCountryWindow;
        private AddCityWindow addCityWindow;

        public MainWindow()
        {
            InitializeComponent();

            adpContinent = new WorldDBTableAdapters.ContinentTableAdapter();
            tblContinents = new WorldDB.ContinentDataTable();

            adpCountry = new WorldDBTableAdapters.CountryTableAdapter();
            tblCountries = new WorldDB.CountryDataTable();

            adpCity = new WorldDBTableAdapters.CityTableAdapter();
            tblCities = new WorldDB.CityDataTable();

        }

        private void GetAllContinents()
        {
            adpContinent.FillContinent(tblContinents);
            
            cmbContinents.ItemsSource = tblContinents.DefaultView;
            cmbContinents.DisplayMemberPath = "ContinentName";
            cmbContinents.SelectedValuePath = "ContinentId";

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetAllContinents();
        }

        private void GetCountries()
        {
            int continentId = Convert.ToInt32(cmbContinents.SelectedValue);
            adpCountry.FillCountries(tblCountries);
        }

        private void GetCountriesInContinent()
        {
            int continentId = Convert.ToInt32(cmbContinents.SelectedValue);
            tblCountries = adpCountry.GetCountriesInContinent(continentId);
        }

        private void cmbContinents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetCountriesInContinent();

            lblLanguages.Content = "";
            lblCurrency.Content = "";

            lstCountries.ItemsSource = tblCountries.DefaultView;
            lstCountries.DisplayMemberPath = "CountryName";
            lstCountries.SelectedValuePath = "CountryId";
        }

        private void lstCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int countryId = Convert.ToInt32(lstCountries.SelectedValue);
            
            var country = tblCountries.FindByCountryId(countryId);

            if (country != null)
            {
                lblLanguages.Content = country.Language;
                lblCurrency.Content = country.Currency;
            }

            GetCitiesInCountry(countryId);
            grdCities.ItemsSource = tblCities.DefaultView;

        }

        private void GetCitiesInCountry(int countryId)
        {
            adpCity.FillCities(tblCities, countryId);
        }

        private void btnAddContinent_Click(object sender, RoutedEventArgs e)
        {
            addContinentWindow = new AddContinentWindow(adpContinent,tblContinents);
            addContinentWindow.Owner = this;
            addContinentWindow.ShowDialog();

            if (addContinentWindow.IsAdded == true)
            {
                GetAllContinents();
            }
        }

        private void btnAddCountry_Click(object sender, RoutedEventArgs e)
        {
            addCountryWindow = new AddCountryWindow(adpCountry, tblContinents);
            addCountryWindow.Owner = this;
            addCountryWindow.ShowDialog();

            if(addCountryWindow.IsAdded == true)
            {
                GetCountriesInContinent();
            }
        }

        private void btnAddCity_Click(object sender, RoutedEventArgs e)
        {
            GetCountries();

            addCityWindow = new AddCityWindow(adpCity, tblCountries);
            addCityWindow.Owner = this;
            addCityWindow.ShowDialog();
        }
    }
}
