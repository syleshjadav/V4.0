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

namespace MyShopOutDoor {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class KeyDropWindow : Page {

        public KeyDropWindow() {
            InitializeComponent();
           
        }


        private void cmdTowTruck_Click(object sender, RoutedEventArgs e) {
            NaviageTo("TowTruck.xaml");
        }


        private void cmdCustomer_Click(object sender, RoutedEventArgs e) {
            NaviageTo("CustomerKeyDropWindow.xaml");

        }

        private void cmdBack_Click(object sender, RoutedEventArgs e) {
            NaviageTo("MenuWindow.xaml");
        }


        private void NaviageTo(string pageName) {
            var nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri(pageName, UriKind.RelativeOrAbsolute));
        }
    }
}
