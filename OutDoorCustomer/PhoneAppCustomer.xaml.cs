
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ATP.Kiosk.Views;
using System.Xml.Serialization;
using ATP.Kiosk.Helpers;
using ATP.Common;
using System.IO;
using System.Collections;
using System.Runtime.Serialization;
using OutDoorCustomer.ServiceReference1;
using ATP.DataModel;
using MyShopExpress.Common;


namespace MyShopExpress
{
    /// <summary>
    /// Interaction logic for CustomerKeyDropWindow.xaml
    /// </summary>
    public partial class PhoneAppCustomer : Window
    {

        private ATP.DataModel.uspVerifyPinGetCustInfoExpress_Result CustomerInfo { get; set; }
        //private string FindHomeAndMoveStepsReading { get; set; }
        //private string RotateKeyFloorReading { get; set; }
        //private string DoorLatchReading { get; set; }
        //public int OutDoorKeyDroppedBy { get; set; }

        //SerialPort _serialPort = ConfigClass.MyShopSerialPort;
        int _dealerId = ConfigClass.DealerId;
        public PhoneAppCustomer()
        {
            InitializeComponent();
            // App.Current.SessionEnding += Current_SessionEnding;
            cmdVerifyPIN.Click += CmdVerifyPIN_Click;
            //  _serialPort = new SerialPort();
            // _serialPort.DataReceived += _serialPort_DataReceived;
            //  _serialPort.ErrorReceived += _serialPort_ErrorReceived;


            this.Loaded += CustomerKeyDropWindow_Loaded;

            //TxtName.Text = "John Hayes";
            //TxtVehicle.Text = "2015 , Honda CRV ";
            //TxtComments.Text = "Check for vibration in front.";
            //TxtContacts.Text = " 717-865-8975";
        }

        private void CustomerKeyDropWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // CmdVerifyPIN_Click(sender,e);

            SelectedServiceList = new List<uspSelSvcTypeByDealerId_Result>();

            // LstServiceItems.Items.Clear();
            // LstServiceItems.SelectedIndex = -1;

            // CmdVerifyPIN_Click(sender, e);
            TxtPin.Focus();
        }
        public List<uspSelSvcTypeByDealerId_Result> SelectedServiceList { get; set; }

        public uspSelSvcTypeByDealerId_Result SelectedService { get; set; }
       // private List<uspSelSvcTypeByDealerId_Result> _dealerServiceList;
        public List<uspSelSvcTypeByDealerId_Result> DealerServiceList { get; set; }


        private void LstServiceItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var currentSelectedService = new uspSelSvcTypeByDealerId_Result();

            ////if (!App.GatpUserRecord.SelectedServiceTypeList.Any())
            ////{
            ////    LstServiceItems.UnselectAll();
            ////}

            //if (TxtDescription != null)
            //{
            //    TxtDescription.Document = null;
            //}
            //currentSelectedService.IsSelected = false;
            // LstServiceItems.SelectedItem = currentSelectedService;
            //if (DealerServiceList != null)
            //{
            //    DealerServiceList.Where(d => d.ServiceTypeId == currentSelectedService.ServiceTypeId).Update(x => x.IsSelected = false);

            //    LstServiceItems.ItemsSource = DealerServiceList;
            //    LstServiceItems.Items.Refresh();
            //    return;
            //}
            if (e.RemovedItems.Count > 0                )
            {
                //currentSelectedService = (uspSelSvcTypeByDealerId_Result)e.RemovedItems[0];
                currentSelectedService.IsSelected = false;
                currentSelectedService = (uspSelSvcTypeByDealerId_Result) e.RemovedItems[ 0];
               currentSelectedService.IsSelected = false;
                //LstServiceItems.SelectedItem = currentSelectedService;

                LstServiceItems.SelectedItems.Remove(currentSelectedService);
                DealerServiceList.Where(mm => mm.ServiceTypeId == currentSelectedService.ServiceTypeId).Update(xx => xx.IsSelected = false);
                // LstServiceItems.SelectedItem

                //
                //  SelectedServiceList.Remove(currentSelectedService);

                //    if (currentSelectedService.ShortName.ToLower().Contains("multi point inspection") || currentSelectedService.ShortName.ToLower().Contains("complimentary 16 point inspection"))
                //    {
                //        var multipoint = DealerServiceList.SingleOrDefault(m => m.ShortName.ToLower().Contains("multi point inspection"));
                //        var multipoint1 = DealerServiceList.SingleOrDefault(m => m.ShortName.ToLower().Contains("complimentary 16 point inspection"));

                //        if (multipoint != null)
                //        {
                //            LstServiceItems.SelectedItems.Add(multipoint);
                //            return;
                //        }
                //        if (multipoint1 != null)
                //        {
                //            LstServiceItems.SelectedItems.Add(multipoint1);
                //            return;
                //        }
                //    }

            }

            if (e.AddedItems.Count > 0 )
            {
                currentSelectedService.IsSelected = true;
                currentSelectedService = (uspSelSvcTypeByDealerId_Result)e.AddedItems[0];
                LstServiceItems.SelectedItems.Add(currentSelectedService);

                DealerServiceList.Where(mm=>mm.ServiceTypeId == currentSelectedService.ServiceTypeId).Update(xx => xx.IsSelected = true);

               // 
                //LstServiceItems.r
            }



        }



        private void CtrlCustomerKeyDrop_Unloaded(object sender, RoutedEventArgs e)
        {

            // if (_serialPort.IsOpen) { _serialPort.Close(); }
        }


        public bool IsPickUpOrDrop { get; set; }
        private void CmdVerifyPIN_Click(object sender, RoutedEventArgs e)
        {
            cmdVerifyPIN.IsEnabled = false;
            //this.Cursor = System.input. Cursor.Wait;

            // pickup = false, drop = true

            var res = new List<uspVerifyPinGetCustInfoExpress_Result>();
            var x = new List<uspSelVehicleMakes_Result>();

           // CtrlValidatePin.TxtPin.Text = "13727";

            try
            {
                res = ProxyHelper.Service<IOutDoor>.Use(svcs =>
                {
                    return svcs.VerifyPinGetCustInfoExpress(_dealerId, TxtPin.Text).ToList();
                });

                var svclist = new List<uspSelVehicleServiceDetails_Result>();

                try
                {
                    if (res[0].PinStatus == "G" && IsPickUpOrDrop == true)
                    {
                        //lstStatus.Items.Add("Good Pin");
                        //var cust = new uspVerifyPinGetCustInfo_Result();
                        GrdEnterPin.Visibility = Visibility.Collapsed;
                        GrdKeyDrop.Visibility = Visibility.Visible;

                        CustomerInfo = res[0];

                        var pGuid = CustomerInfo.PersonGuid;
                        var vGuid = CustomerInfo.VehicleGuid;
                        var vsGuid = CustomerInfo.VehicleServiceGuid;

                        cmdNext.Visibility = Visibility.Visible;

                        TxtName.Text = String.Format("{0} {1}", CustomerInfo.FirstName, CustomerInfo.LastName);
                        TxtVehicle.Text = String.Format("{0} {1} {2} {3}",
                          CustomerInfo.VehicleYear,
                           CustomerInfo.VehicleMake,
                           CustomerInfo.VehicleModel,
                           CustomerInfo.VehicleTrim);

                        
                        TxtContacts.Text = String.Format("{0}", CustomerInfo.PhoneNumber);


                        svclist = ProxyHelper.Service<IOutDoor>.Use(svcs =>
                        {
                            return svcs.SelVehicleServiceDetails(_dealerId, vsGuid, vGuid, pGuid, null, null).ToList();
                        });

                        //DealerServiceList = ProxyHelper.Service<IOutDoor>.Use(svcs =>
                        //{

                        //    return svcs.GetServiceTypes(_dealerId.ToString()).Where(m => m.Express == true).ToList();
                        //});


                        if (App.gDealerServiceList == null)
                        {
                            DealerServiceList = ProxyHelper.Service<IOutDoor>.Use(svcs =>
                            {

                                return svcs.GetServiceTypes(_dealerId.ToString()).Where(m => m.Express == true).ToList();
                            });
                            App.gDealerServiceList = DealerServiceList;
                        }
                        else
                        {
                            DealerServiceList = App.gDealerServiceList;
                        }



                        DealerServiceList.Update(xx => xx.OpacityVal = 1);
                        DealerServiceList.Update(xx => xx.IsEnabledVal = true);
                        DealerServiceList.Update(xx => xx.IsSelected = false);
                        LstServiceItems.UnselectAll();


                        LstServiceItems.ItemsSource = DealerServiceList;

                        if (svclist != null && svclist.FirstOrDefault().VEHSVCS != null)
                        {
                            XmlSerializer ser = new XmlSerializer(typeof(VEHSVCS));
                          //  ser.UnknownElement += new XmlElementEventHandler(Serializer_UnknownElement);

                            using (TextReader reader = new StringReader(svclist.FirstOrDefault().VEHSVCS.ToString()))
                            {
                                var result = (VEHSVCS)ser.Deserialize(reader);

                                var icount = result.VEHSVC.Count();

                                for (var i = 0; i < icount; i++)
                                {
                                    var item = DealerServiceList.SingleOrDefault(m => m.ServiceTypeId == Convert.ToInt32(result.VEHSVC[i].ServiceTypeId.ToString()));
                                    item.IsSelected = true;
                                    SelectedServiceList.Add(item);

                                    DealerServiceList.Where(mm => mm.ServiceTypeId == item.ServiceTypeId).Update(xx => xx.IsSelected = true);
                                }
                            }
                            LstServiceItems.Items.Refresh();
                        }
                        TxtComments.Text = svclist.FirstOrDefault().Comments;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox(ex.Message);
                }

            }
            catch (Exception ex)
            {
                MessageBox(ex.Message);
            }

            cmdVerifyPIN.IsEnabled = true;
        }

   

        private void GoHome()
        {
            this.Close();
        }


        //static AdamMessageBox wnd;

        private static void MessageBox(string msg, string header = "Information")
        {
            var wnd = new AdamMessageBox();
            wnd.TxtError.Text = msg;
            wnd.TxtHeader.Text = header;
            wnd.BtnNo.Visibility = System.Windows.Visibility.Collapsed;
            wnd.BtnYes.Visibility = System.Windows.Visibility.Collapsed;
            wnd.CmdOk.Visibility = System.Windows.Visibility.Visible;

            var confirm = wnd.ShowDialog();
        }

        private void cmdNext_Click(object sender, RoutedEventArgs e)
        {
            // var sKeyLockerId = res[0].KeyLockerId;
            //GrdVerifiedPinInfo.Visibility = Visibility.Visible;
            //GrdVerifyPinInfo.Visibility = Visibility.Collapsed;
            //Keyboard.IsOpen = false;
            //var wnd = new VerifyAndPrint();
          
            //wnd.CustomerInfo = CustomerInfo;
            //wnd.SelectedServiceList = DealerServiceList.Where(m => m.IsSelected == true).ToList();
            //wnd.CustNotes = TxtComments.Text;
            //wnd.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //wnd.ShowDialog();

            //this.Opacity = 1;
            // MyKeyboard.Visibility = Visibility.Visible;
            // MyKeyboard.IsOpen = true;

            // if (wnd.IsKeyDroppedClcked == true) {
           // GoHome();

            //var wnd = new OpenDoorAndDropKeys {
            //          FindHomeAndMoveStepsReading = FindHomeAndMoveStepsReading,
            //          CustomerInfo = CustomerInfo
            //      };

            //      wnd.ShowDialog();
            //      GoHome();

        }

        private void cmdBack_Click(object sender, RoutedEventArgs e)
        {
            Keyboard.IsOpen = false;
            GoHome();
        }

        private void TxtComments_GotFocus(object sender, RoutedEventArgs e)
        {
           // this.Opacity = 0.5;
            Keyboard.IsOpen = true;
        }


        //private void TxtPin_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    TextBox textbox = sender as TextBox;
        //    Keypad keypadWindow = new Keypad(textbox, this,"Enter PIN");
        //    keypadWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        //    this.Opacity = .8;
        //    if (keypadWindow.ShowDialog() == true)
        //        textbox.Text = keypadWindow.Result;

        //    this.Opacity = 1;

        //}

        //private void TxtComments_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    InvokeKeyBoard(sender, "Enter Comments :");
        //}
        //private void InvokeKeyBoard(object sender, string title)
        //{
        //    TextBox tb = sender as TextBox;
        //    VirtualKeyboard kbWin = new VirtualKeyboard(tb, this, title);
        //    kbWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        //    this.Opacity = .8;
        //    if (kbWin.ShowDialog() == true)
        //        tb.Text = kbWin.Result;
        //    this.Opacity = 1;
        //}
    }


    [XmlRoot(ElementName = "VEHSVC")]
    public class VEHSVC 
    {
        [DataMember]
        [XmlElement(ElementName = "VehicleServiceGUID")]
        public string VehicleServiceGUID { get; set; }

        [DataMember]
        [XmlElement(ElementName = "ServiceTypeId")]
        public string ServiceTypeId { get; set; }

        [DataMember]
        [XmlElement(ElementName = "Sequence")]
        public string Sequence { get; set; }

        [DataMember]
        [XmlElement(ElementName = "ShortName")]
        public string ShortName { get; set; }

    }

    [XmlRoot(ElementName = "VEHSVCS")]
    [Serializable]
    
    public class VEHSVCS 
    {
        [DataMember]
        [XmlElement(ElementName = "VEHSVC")]
        public List<VEHSVC> VEHSVC { get; set; }

    
    }
}
