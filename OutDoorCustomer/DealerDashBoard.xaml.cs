using ATP.DataModel;
using ATP.Kiosk.Views;
using MyShopExpress.Common;
using OutDoorCustomer.ServiceReference1;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace MyShopExpress
{


    public partial class DealerDashBoard : Window
    {
        static public void Serialize(StickerInvoice details)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(StickerInvoice));
            using (TextWriter writer = new StreamWriter(@"C:\temp\StickerInvoiceXml.xml"))
            {
                serializer.Serialize(writer, details);
            }
        }

        int _dealerId = ConfigClass.DealerId;
        public DispatcherTimer dispatcherTimer;
        public DealerDashBoard()
        {
            InitializeComponent();



            StickerInvoice SI = new StickerInvoice();

            SI.CustomerVehicle = new MSCustomerVehicle
            {
                Address1 = "",
                Address2 = "",
                City = "",
                State = "",
                CurrMileage = "",
                DealerPersonGroupId = "",
                DeviceTypeId = "",
                NextInspectionDate = "",
                NextServiceDate = "",
                EmailAddress = "",
                FirstName = "",
                GoogleGuid = "",
                GroupName = "",
                IsValid = "",
                LastName = "",
                MiddleName = "",
                MileageIn = "",
                MileageOut = "",
                NextSvcInfo = "",
                OldMileage = "",
                PersonGuid = "",
                PhoneNumber = "",
                Plate = "",
                VehicleGuid = "",
                VehicleId = "",
                VehicleMake = "",
                VehicleModel = "",
                VehicleName = "",
                VehicleTrim = "",
                VehicleYrMkMod = "",
                VehicleYear = "",
                VehPhId = "",
                VIN = "",
                Zip = "",
                InsExpDate="",
                InsPolicyNum="",
                NAIC=""
            };
            SI.DealerEmp = new MSDealerEmp
            {
                DealerEmpGuid = "",
                DealerId = "",
                DeptId = "",
                DeptName = "",
                EmailAddress = "",
                EmpName = "",
                InspectionYr = "",
                PhoneNumber = "",
                StationNumber = "",
                StationYr = "",
                StickerCharge = ""

            };
            SI.InspectionInfo = new MsInspectionInfo
            {
                Insurance =   new InspectionItem
                {
                    Comments = "",
                    Cost = "",
                    DuringInsp = "",
                    PostInsp = ""
                },

                BodyDoorAndLatches = new InspectionItem {
                    Comments = "",
                    Cost = "",
                    DuringInsp = "",
                    PostInsp = ""
                },

                BrakeSystems = new InspectionItem {
                    Comments = "",
                    Cost = "",
                    DuringInsp = "",
                    PostInsp = ""
                },
                ExhaustSystems = new InspectionItem {
                    Comments = "",
                    Cost = "",
                    DuringInsp = "",
                    PostInsp = ""
                },
                FuelSystems = new InspectionItem {
                    Comments = "",
                    Cost = "",
                    DuringInsp = "",
                    PostInsp = ""
                },
                GlazingAndMirrors = new InspectionItem {
                    Comments = "",
                    Cost = "",
                    DuringInsp = "",
                    PostInsp = ""
                },
                InspectionResult = new InspectionItem {
                    Comments = "",
                    Cost = "",
                    DuringInsp = "",
                    PostInsp = ""
                },
                RegistrationVerified = new InspectionItem {
                    Comments = "",
                    Cost = "",
                    DuringInsp = "",
                    PostInsp = ""
                },
                RoadTest = new InspectionItem {
                    Comments = "",
                    Cost = "",
                    DuringInsp = "",
                    PostInsp = ""
                },
                SteeringandSuspension = new InspectionItem {
                    Comments = "",
                    Cost = "",
                    DuringInsp = "",
                    PostInsp = ""
                },
                StickerNumber = new InspectionItem {
                    Comments = "",
                    Cost = "",
                    DuringInsp = "",
                    PostInsp = ""
                },
                TireReadings = new FrontRear
                {
                    LF = new Findings { Readings = "", BondOrRevet = "", Comments = "" },
                    LR = new Findings { Readings = "", BondOrRevet = "", Comments = "" },
                    RF = new Findings { Readings = "", BondOrRevet = "", Comments = "" },
                    RR = new Findings { Readings = "", BondOrRevet = "", Comments = "" },
                },
                BrakeReadings = new FrontRear {
                    LF = new Findings { Readings = "", Comments = "" },
                    LR = new Findings { Readings = "", Comments = "" },
                    RF = new Findings { Readings = "", Comments = "" },
                    RR = new Findings { Readings = "", Comments = "" },
                },
                TiresAndWheels = new InspectionItem {
                    Comments = "",
                    Cost = "",
                    DuringInsp = "",
                    PostInsp = ""

                },
                VisualAntiTampering = new InspectionItem {
                    Comments = "",
                    Cost = "",
                    DuringInsp = "",
                    PostInsp = ""
                },
            };


            Serialize(SI);


            LoadConfig();
            _dealerId = ConfigClass.DealerId;
            this.Loaded += DealerDashBoard_Loaded;
            this.Unloaded += DealerDashBoard_Unloaded;
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 60);
        }

        private void LoadConfig()
        {


            var dir = @"c:\Sites";
            var filedir = dir + "\\MyShopAppConfig.xml";
            XmlDocument xdoc = new XmlDocument();
            try
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                if (!File.Exists(filedir))
                {
                    string s = "<ROOT><DEALERID>116</DEALERID><MYSHOPCOMMPORT>COM4</MYSHOPCOMMPORT><DEALORCUST>C</DEALORCUST></ROOT>";

                    xdoc.LoadXml(s);
                    xdoc.Save(@"c:\Sites\MyShopAppConfig.xml");
                }

                xdoc.Load(filedir);
                XmlNode xmlnode;
                xmlnode = xdoc.SelectSingleNode("ROOT");
                ConfigClass.DealerId = Convert.ToInt32(xmlnode["DEALERID"].InnerText);





                SerialPortInterface sp = new SerialPortInterface(); // load port details
                ConfigClass.MyShopSerialPort.PortName = xmlnode["MYSHOPCOMMPORT"].InnerText;




                // if (!ConfigClass.MyShopSerialPort.IsOpen) { ConfigClass.MyShopSerialPort.Open(); }


                if (xmlnode["DEALORCUST"].InnerText == "C")
                {

                    var wnd = new MenuWindow();
                    wnd.Show();
                    this.Close();
                }


            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);



            }
        }

        private void DealerDashBoard_Unloaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //RefreshGrid();
        }
        private void DealerDashBoard_Loaded(object sender, RoutedEventArgs e)
        {
            // //satish added
            //var allScreen = Screen.AllScreens;
            //Screen scr1 = allScreen[0];
            //Screen scr2 = allScreen[1];
            //Screen primary = allScreen[1];
            //if (allScreen.Length >= 2) {
            //  scr2 = allScreen[1];
            //}
            //else {
            //  scr1 = allScreen[0];
            //}
            //if (scr1.Primary) {
            //  primary = scr2;
            //}
            //else {
            //  primary = scr2;
            //}
            //// System.Windows.MessageBox.Show(primary.DeviceName);
            //Rectangle r = primary.WorkingArea;
            //this.WindowState = WindowState.Maximized;
            //this.WindowStyle = WindowStyle.None;
            //this.Width = r.Width;
            //this.Height = r.Height;
            //this.Top = r.Top;
            //this.Left = r.Left;
            // satish end
            //RefreshGrid();


            //var res1 = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs => {
            //  return svcs.UpsertKioskInUSE(_dealerId, null, new Guid("A0B1C2D3-E4F5-AABB-CCDD-9F8E7D6C5B4A"));
            //});

            // dispatcherTimer.Start();
        }

        //private void RefreshGrid() {
        //  try {

        //    var res = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs => {
        //      return svcs.SelAllKeyDropPegByDealerId(ConfigClass.DealerId);
        //    });
        //    LstPerson.ItemsSource = null;
        //    // LstPerson.Items.Clear();
        //    LstPerson.ItemsSource = res;
        //    //  LstPerson.Items.Refresh();
        //  }
        //  catch (Exception ex) {
        //    MessageBox(ex.Message.ToString(), "Error !");
        //  }
        //}

        //private void LstPerson_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        //  if (LstPerson.SelectedItem == null) { return; }

        //  var wnd = new MyShopExpress.PickUpOrDrop();
        //  this.Opacity = 0.5;
        //  var selectedPerson = (MyShopOutDoor.ServiceReference1.uspSelAllKeyDropPegByDealerId_Result)LstPerson.SelectedItem;

        //  if (selectedPerson.VehicleGuid == null) {
        //    //wnd.TxtMessage.Text = "Go To the web site and change the status to ready for keydrop..";
        //    //wnd.cmdCustomer.Visibility = Visibility.Collapsed;
        //    //wnd.cmdPlaceKeys.Visibility = Visibility.Collapsed;
        //    MessageBox("Go To Service Writer's Desk, Using MyShopAuto web site and change the status to ready for keydrop..");
        //  }
        //  else {
        //    wnd.SelectedPerson = selectedPerson;


        //    var confirm = wnd.ShowDialog();


        //    var res1 = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs => {
        //      return svcs.UpsertKioskInUSE(116, null, new Guid("A0B1C2D3-E4F5-AABB-CCDD-9F8E7D6C5B4A"));
        //    });

        //  }
        //  // LstPerson.UnselectAll();
        //  this.Opacity = 1;
        //  RefreshGrid();

        //}

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
    }
}
