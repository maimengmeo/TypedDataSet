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

namespace A2TuyetMaiPham
{
    /// <summary>
    /// Interaction logic for AddCountryWindow.xaml
    /// </summary>
    public partial class AddCountryWindow : Window
    {
        private WorldDBTableAdapters.CountryTableAdapter adpCountry;
        private WorldDB.ContinentDataTable tblContinents;
        private bool isAdded;

        public AddCountryWindow(WorldDBTableAdapters.CountryTableAdapter adpCountry,
                                 WorldDB.ContinentDataTable tblContinents)
        {
            InitializeComponent();
            this.adpCountry = adpCountry;
            this.tblContinents = tblContinents;
        }

        public bool IsAdded { get { return isAdded; } }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbContinents.ItemsSource = tblContinents.DefaultView;
            cmbContinents.DisplayMemberPath = "ContinentName";
            cmbContinents.SelectedValuePath = "ContinentId";
        }

        private void btnAddCountry_Click(object sender, RoutedEventArgs e)
        {
            
            string countryName = txtCountryName.Text;
            string language  = txtLanguage.Text;
            string currency = txtCurrency.Text;
            int continentId  = Convert.ToInt32(cmbContinents.SelectedValue);

            if (String.IsNullOrWhiteSpace(countryName))
            {
                lblMessage.Content = "Country Name is invalid. Try again!";
            }
            else if (String.IsNullOrWhiteSpace(language))
            {
                lblMessage.Content = "Language is invalid. Try again!";
            }
            else if (String.IsNullOrWhiteSpace(currency))
            {
                lblMessage.Content = "Currency is invalid. Try again!";
            }
            else if (cmbContinents.SelectedItem == null)
            {
                lblMessage.Content = "Please select Continent";
            }
            else
            {
                lblMessage.Content = "";
                adpCountry.Insert(countryName, language, currency, continentId);
                isAdded = true;
                MessageBox.Show("New Country is Added!", "Add Country", MessageBoxButton.OK, MessageBoxImage.Information);
                txtCountryName.Text = txtCurrency.Text = txtLanguage.Text = "";
                txtCountryName.Focus();
                                
            }
            
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
