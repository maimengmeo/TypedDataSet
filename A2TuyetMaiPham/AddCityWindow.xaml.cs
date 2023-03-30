﻿using System;
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

namespace A2TuyetMaiPham
{
    /// <summary>
    /// Interaction logic for AddCityWindow.xaml
    /// </summary>
    public partial class AddCityWindow : Window
    {
        private WorldDBTableAdapters.CityTableAdapter adpCity;
        private WorldDB.CountryDataTable tblCountries;
        private bool isAdded;
        public AddCityWindow(WorldDBTableAdapters.CityTableAdapter adpCity, WorldDB.CountryDataTable tblCountries)
        {
            InitializeComponent();
            this.adpCity = adpCity;
            this.tblCountries = tblCountries;
        }

        public bool IsAdded { get { return isAdded; } }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbCountries.ItemsSource = tblCountries.DefaultView;
            cmbCountries.DisplayMemberPath = "CountryName";
            cmbCountries.SelectedValuePath = "CountryId";
        }

        private void btnAddCity_Click(object sender, RoutedEventArgs e)
        {
            string cityName = txtCityName.Text;
            string cityPopulation = txtCityPopulation.Text;
            string isCapital = chkCapital.ToString();

            

        }
    }
}
