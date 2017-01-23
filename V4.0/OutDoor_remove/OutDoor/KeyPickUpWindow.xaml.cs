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
  public partial class KeyPickUpWindow : Page {
    public KeyPickUpWindow() {
      InitializeComponent();
    }

    private void cmdKeysPickUp_Click(object sender, RoutedEventArgs e) {
      // var wnd = new MainWindow();
      //wnd.ctrlKeyPickUp.Visibility = Visibility.Collapsed;
      //wnd.ctrlMenu.Visibility = Visibility.Visible;

      NavigationService nav = NavigationService.GetNavigationService(this);
      nav.Navigate(new Uri("MenuWindow.xaml", UriKind.RelativeOrAbsolute));

    }
  }
}
