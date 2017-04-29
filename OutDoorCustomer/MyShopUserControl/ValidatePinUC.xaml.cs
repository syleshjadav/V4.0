using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MyShopExpress.MyShopUserControl {
  /// <summary>
  /// Interaction logic for ValidatePinUC.xaml
  /// </summary>
  public partial class ValidatePinUC : UserControl {
        public ValidatePinUC() {
            InitializeComponent();
            this.DataContext = this;
        }
     

        //public static readonly DependencyProperty PINTextProperty = DependencyProperty.Register("PINText", typeof(string), typeof(ValidatePinUC), new FrameworkPropertyMetadata(null));
        //public string PINText {
        //    get { return (string)GetValue(PINTextProperty); }
        //    set { SetValue(PINTextProperty, value); }
        //}


        #region "Keyboard"

        private void cmdBack_Click(object sender, RoutedEventArgs e) {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("KeyDropWindow.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnOne_Click(object sender, RoutedEventArgs e) {
            TxtPin.Text += "1";
        }

        private void btnTwo_Click(object sender, RoutedEventArgs e) {
            TxtPin.Text += "2";
        }

        private void bthThree_Click(object sender, RoutedEventArgs e) {
            TxtPin.Text += "3";
        }

        private void btnFour_Click(object sender, RoutedEventArgs e) {
            TxtPin.Text += "4";
        }

        private void btnFive_Click(object sender, RoutedEventArgs e) {
            TxtPin.Text += "5";
        }

        private void btnSix_Click(object sender, RoutedEventArgs e) {
            TxtPin.Text += "6";
        }

        private void btnSeven_Click(object sender, RoutedEventArgs e) {
            TxtPin.Text += "7";
        }

        private void btnEight_Click(object sender, RoutedEventArgs e) {
            TxtPin.Text += "8";
        }

        private void btnNine_Click(object sender, RoutedEventArgs e) {
            TxtPin.Text += "9";
        }

        private void btnZero_Click(object sender, RoutedEventArgs e) {
            TxtPin.Text += "0";
        }

        private void btnBackSpace_Click(object sender, RoutedEventArgs e) {
            if (TxtPin.Text.Length > 0) {

                TxtPin.Text = TxtPin.Text.Substring(0, TxtPin.Text.Length - 1);
            }
        }

        private void btnClearAll_Click(object sender, RoutedEventArgs e) {
            TxtPin.Text = "";
        }

        #endregion
    }
}
