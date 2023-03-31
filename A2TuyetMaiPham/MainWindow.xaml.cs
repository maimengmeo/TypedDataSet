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
        private WorldDB.CountryDataTable tblCountriesInContinent;

        private AddContinentWindow addContinentWindow;
        private AddCountryWindow addCountryWindow;
        private AddCityWindow addCityWindow;

        private int continentId;
        private int countryId;

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


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetAllContinents();
        }

        private void GetAllContinents()
        {
            adpContinent.FillContinent(tblContinents);

            cmbContinents.ItemsSource = tblContinents.DefaultView;
            cmbContinents.DisplayMemberPath = "ContinentName";
            cmbContinents.SelectedValuePath = "ContinentId";

        }

        private void GetCountries()
        {
            int continentId = Convert.ToInt32(cmbContinents.SelectedValue);
            adpCountry.FillCountries(tblCountries);
        }

        private void GetCountriesInContinent()
        {
            continentId = Convert.ToInt32(cmbContinents.SelectedValue);
            tblCountriesInContinent = adpCountry.GetCountriesInContinent(continentId);
        }

        private void GetCitiesInCountry(int countryId)
        {
            adpCity.FillCities(tblCities, countryId);
        }

        private void LoadCountryListBox()
        {
            lstCountries.ItemsSource = tblCountriesInContinent.DefaultView;
            lstCountries.DisplayMemberPath = "CountryName";
            lstCountries.SelectedValuePath = "CountryId";
        }

        private void LoadCityGrid(int countryId)
        {
            GetCitiesInCountry(countryId);
            grdCities.ItemsSource = tblCities.DefaultView;
        }

        private void cmbContinents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetCountriesInContinent();

            lblLanguages.Content = "";
            lblCurrency.Content = "";

            LoadCountryListBox();

        }

        private void lstCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            countryId = Convert.ToInt32(lstCountries.SelectedValue);
            
            var country = tblCountriesInContinent.FindByCountryId(countryId);

            if (country != null)
            {
                lblLanguages.Content = country.Language;
                lblCurrency.Content = country.Currency;
            }

            LoadCityGrid(countryId);

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
                LoadCountryListBox();
            }
        }

        private void btnAddCity_Click(object sender, RoutedEventArgs e)
        {
            GetCountries();

            addCityWindow = new AddCityWindow(adpCity, tblCountries);
            addCityWindow.Owner = this;
            addCityWindow.ShowDialog();

            if (addCityWindow.IsAdded == true)
            {
                LoadCityGrid(countryId);
            }

        }
    }
}
