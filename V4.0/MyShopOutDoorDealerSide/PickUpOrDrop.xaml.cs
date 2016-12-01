using ATP.Kiosk.Views;
using MyShopOutDoor.Common;
using MyShopOutDoorDealerSide.ServiceReference1;
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

namespace MyShopOutDoor.DealerSide {
  /// <summary>
  /// Interaction logic for PickUpOrDrop.xaml
  /// </summary>
  public partial class PickUpOrDrop : Window {

    int dealerid = 116;

    public PickUpOrDrop() {
      InitializeComponent();

      this.Loaded += PickUpOrDrop_Loaded;
    }

    private void PickUpOrDrop_Loaded(object sender, RoutedEventArgs e) {
      GrdSelection.DataContext = SelectedPerson;

      //Ready for pickup
      if (SelectedPerson.ServiceStatus == 10) {
        TxtPlaceKeysInfo.Visibility = Visibility.Collapsed;
        cmdPlaceKeys.Visibility = Visibility.Collapsed;
        cmdOpenDoor.Visibility = Visibility.Collapsed;

        cmdTakeKeys.Visibility = Visibility.Visible;
        TxtTakeKeysInfo.Visibility = Visibility.Visible;
        GrdButtons.Columns = 1;



      }
    }



    public uspSelAllKeyDropPegByDealerId_Result SelectedPerson { get; set; }




    private void cmdBack_Click(object sender, RoutedEventArgs e) {
      this.Close();
      this.Close();

    }

    private void cmdTakeKeys_Click(object sender, RoutedEventArgs e) {


      var FindHomeAndMoveStepsReading = SelectedPerson.NoOfRotationDealer;

      ConfigClass.SendCommandToBoard(FindHomeAndMoveStepsReading);

      ConfigClass.SendCommandToBoard("BC0075000 \n");

      UpdateVehicleServiceStatus(3);//Currently being serviced


    }

    private void UpdateVehicleServiceStatus(byte? serviceStatusId) {
      try {

        var res = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs => {
          return svcs.UpdateVehiceServiceStatus(dealerid, SelectedPerson.VehicleServiceGuid, SelectedPerson.VehicleGuid, SelectedPerson.PersonGuid, serviceStatusId, SelectedPerson.VehicleGuid);
        });

      }
      catch (Exception ex) {
        MessageBox(ex.Message.ToString(), "Error !");
      }
      this.Close();
    }



    private bool? MessageBox(string msg, string header = "Information") {
      var wnd = new AdamMessageBox();
      wnd.TxtError.Text = msg;
      wnd.TxtHeader.Text = header;
      wnd.BtnNo.Visibility = System.Windows.Visibility.Collapsed;
      wnd.BtnYes.Visibility = System.Windows.Visibility.Collapsed;
      wnd.CmdOk.Visibility = System.Windows.Visibility.Visible;

      var x = wnd.ShowDialog();
      return x;
    }

    private void cmdOpenDoor_Click(object sender, RoutedEventArgs e) {
      ConfigClass.SendCommandToBoard("DL5000");
      var FindHomeAndMoveStepsReading = SelectedPerson.NoOfRotationDealer;

      ConfigClass.SendCommandToBoard(FindHomeAndMoveStepsReading);
      var res = MessageBox("The Door is now Open please place the keys and close the door.", "Attention");
    }

    private void cmdPlaceKeys_Click(object sender, RoutedEventArgs e) {

      var wnd = new AdamMessageBox();
      wnd.TxtError.Text = "Is the Key Placed in and doors are closed if so .";
      wnd.TxtHeader.Text = "Confirmation";
      wnd.BtnNo.Visibility = System.Windows.Visibility.Visible;
      wnd.BtnYes.Visibility = System.Windows.Visibility.Visible;
      wnd.CmdOk.Visibility = System.Windows.Visibility.Collapsed;

      var x = wnd.ShowDialog();

      if (x == true) {
        MessageBox("key placed");


        ConfigClass.SendCommandToBoard("KF170000"); // key floor

        UpdateVehicleServiceStatus(10);//Ready for Pickup
      }

    }


  }
}
