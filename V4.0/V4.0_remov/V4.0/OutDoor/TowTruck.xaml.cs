using ATP.Kiosk.Views;
using MyShopOutDoor.Common;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MyShopOutDoor {
    /// <summary>
    /// Interaction logic for TowTruck.xaml
    /// </summary>
    public partial class TowTruck : Page {

        private AdamMessageBox wnd;
        public TowTruck() {
            InitializeComponent();
            wnd = new AdamMessageBox ();

         
            wnd.BtnNo.Click += BtnNo_Click;
            wnd.cmdDropKeys.Click += CmdDropKeys_Click;
            
        
            this.Loaded += TowTruck_Loaded;
        }

     
        private void TowTruck_Loaded(object sender, RoutedEventArgs e) {
          
            
        }

      

        private void BtnNo_Click(object sender, RoutedEventArgs e) {
        }

  

        private void cmdBack_Click(object sender, RoutedEventArgs e) {

        }
        private string FindHomeAndMoveStepsReading { get; set; }
        private string RotateKeyFloorReading { get; set; }
        private string DoorLatchReading { get; set; }
        int _dealerId = ConfigClass.DealerId;


        private void CmdDropKeys_Click(object sender, RoutedEventArgs e) {

            ConfigClass.SendCommandToBoard("FH" + FindHomeAndMoveStepsReading, "C");
            // _serialPort.Write("KF170000 \n");
            ConfigClass.SendCommandToBoard(RotateKeyFloorReading, "C");
        }


        private void cmdDropKeys_Click(object sender, RoutedEventArgs e) {
            wnd = new AdamMessageBox();


            var stepsLst = ATP.Common.ProxyHelper.Service<OutDoorProxy.IOutDoor>.Use(svcs => {
                return svcs.GetKeyLockerSteps(_dealerId, null, true).ToList();
            });

            if (stepsLst != null && stepsLst.Count > 0) {
                FindHomeAndMoveStepsReading = stepsLst.Where(m => m.StepCode == "FH").SingleOrDefault().NoOfRotation;
                RotateKeyFloorReading = stepsLst.Where(m => m.StepCode == "KF").SingleOrDefault().StepReading;
                DoorLatchReading = stepsLst.Where(m => m.StepCode == "DL").SingleOrDefault().StepReading;



               

                var msg = "The Door is now open, Place the key and click DROP KEY button";


                wnd.TxtError.Text = msg;
                wnd.TxtHeader.Text = "Information";
                wnd.BtnNo.Visibility = System.Windows.Visibility.Visible;
                wnd.BtnYes.Visibility = System.Windows.Visibility.Collapsed;
                wnd.CmdOk.Visibility = System.Windows.Visibility.Collapsed;
                wnd.cmdDropKeys.Visibility = System.Windows.Visibility.Visible;

                var confirm = wnd.ShowDialog();

                if(confirm== true) {
                    ConfigClass.SendCommandToBoard("DL" + DoorLatchReading, "C");

                }
                else {
                    System.Windows.MessageBox.Show("said  now");
                }
            }
            else {
                MessageBox("Electronic Key Locker is Full \n Sorry try another time..", "Information");
            }


           
        }

        private static void MessageBox(string msg, string header = "Information") {
            var wnd = new AdamMessageBox();
            wnd.TxtError.Text = msg;
            wnd.TxtHeader.Text = header;
            wnd.BtnNo.Visibility = System.Windows.Visibility.Collapsed;
            wnd.BtnYes.Visibility = System.Windows.Visibility.Collapsed;
            wnd.CmdOk.Visibility = System.Windows.Visibility.Visible;

            var confirm = wnd.ShowDialog();
        }
    }
}
