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
  public partial class KeyDropWindow : UserControl {
    public KeyDropWindow() {
      InitializeComponent();
    }

        private void cmdTowTruck_Click(object sender, RoutedEventArgs e) {

        }

        private void cmdCustomer_Click(object sender, RoutedEventArgs e) {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("CustomerKeyDropWindow.xaml", UriKind.RelativeOrAbsolute));
    }

        private void cmdBack_Click(object sender, RoutedEventArgs e) {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("MenuWindow.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
