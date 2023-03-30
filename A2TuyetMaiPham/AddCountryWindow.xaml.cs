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

        public AddCountryWindow(WorldDBTableAdapters.CountryTableAdapter adpCountry,
                                 WorldDB.ContinentDataTable tblContinents)
        {
            InitializeComponent();
            this.adpCountry = adpCountry;
            this.tblContinents = tblContinents;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
