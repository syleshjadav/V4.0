using ATP.DataModel;
using ATP.Kiosk.Helpers;
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

namespace ATP.KioskExpress15.Views.Service
{
    /// <summary>
    /// Interaction logic for SelectServiceItemsView.xaml
    /// </summary>
    public partial class SelectServiceItemsView : PageFunction<WizardResult>
    {

        public uspSelVehicleByPersonId_Result SelectedVehicle { get; set; }

        public SelectServiceItemsView(uspSelVehicleByPersonId_Result selectedVehicle)
        {
            InitializeComponent();

            SelectedVehicle = selectedVehicle;

            Loaded += SelectServiceItemsView_Loaded;
        }


        private readonly int _dealerId = ATPDealerRecord.DealerId;
        private readonly string _dealertoken = ATPDealerRecord.SystemToken;


 

        private List<uspSelPkgByDealerId_Result> _dealerPackageList;
        public List<uspSelPkgByDealerId_Result> DealerPackageList
        {
            get
            {
                if (_dealerPackageList == null)
                {
                    if (ATP.DataModel.ATPDealerRecord.DealerPackageList != null)
                    {
                        return ATP.DataModel.ATPDealerRecord.DealerPackageList;
                    }
                    _dealerPackageList = new ATP.SvcsLibrary.Dealer().GetServicePackages(_dealerId.ToString(), "").ToList();

                    ATP.DataModel.ATPDealerRecord.DealerPackageList = _dealerPackageList;
                }

                return _dealerPackageList;
            }
            set
            {
                _dealerPackageList = value;
            }
        }

        private List<uspSelPackageByDealerId_Result> _dealerPackageServiceList;
        public List<uspSelPackageByDealerId_Result> DealerPackageServiceList
        {
            get
            {
                if (_dealerPackageServiceList == null)
                {
                    if (ATP.DataModel.ATPDealerRecord.DealerPackageServiceList != null)
                    {
                        return ATP.DataModel.ATPDealerRecord.DealerPackageServiceList;
                    }
                    _dealerPackageServiceList = new ATP.SvcsLibrary.Dealer().SelPackageByDealerId(_dealerId.ToString()).ToList();

                    ATP.DataModel.ATPDealerRecord.DealerPackageServiceList = _dealerPackageServiceList;
                }

                return _dealerPackageServiceList;
            }
            set
            {
                _dealerPackageServiceList = value;
            }
        }

        private List<uspSelSvcTypeByDealerId_Result> _dealerServiceList;
        public List<uspSelSvcTypeByDealerId_Result> DealerServiceList
        {
            get
            {
                if (_dealerServiceList == null)
                {
                    if (ATP.DataModel.ATPDealerRecord.DealerServiceTypeList != null)
                    {
                        return ATP.DataModel.ATPDealerRecord.DealerServiceTypeList;
                    }
                    _dealerServiceList = new ATP.SvcsLibrary.Dealer().GetServiceTypes(_dealerId.ToString(), "").Where(m => m.Express == true).ToList();

                    _dealerServiceList.Update(x => x.OpacityVal = 1);
                    _dealerServiceList.Update(x => x.IsEnabledVal = true);

                    ATP.DataModel.ATPDealerRecord.DealerServiceTypeList = _dealerServiceList;
                }

                return _dealerServiceList;
            }
            set
            {
                _dealerServiceList = value;
            }
        }

        public uspSelPkgByDealerId_Result SelectedPackage { get; set; }
        public uspSelSvcTypeByDealerId_Result SelectedService { get; set; }

        private List<uspSelPkgByDealerId_Result> _selectedPackageList = new List<uspSelPkgByDealerId_Result>();
        private List<uspSelSvcTypeByDealerId_Result> _selectedServiceTypeList = new List<uspSelSvcTypeByDealerId_Result>();

        private void SelectServiceItemsView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                BtnNextClick(sender, e);
                e.Handled = true;
            }
        }

        private void SelectServiceItemsView_Loaded(object sender, RoutedEventArgs e)
        {


            //App.APTMainWindow.SelectedVehicle = String.Format("{0},   {1},   {2},  {3}",
            //App.GatpUserRecord.SelectedPersonVehicle.ModelYear, App.GatpUserRecord.SelectedPersonVehicle.Make,
            //App.GatpUserRecord.SelectedPersonVehicle.Make, App.GatpUserRecord.SelectedPersonVehicle.Model);

            //App.APTMainWindow.InitializeAutoLogoffFeature();

            if (App.GatpUserRecord.SelectedPackageList != null && App.GatpUserRecord.SelectedPackageList.Any())
            {
                _selectedPackageList.Clear();
                //_selectedPackageList = App.GatpUserRecord.SelectedPackageList;
                foreach (var pkgitem in App.GatpUserRecord.SelectedPackageList)
                {
                    LstPackages.SelectedItems.Add(pkgitem);
                }
            }

            LstServiceItems.UnselectAll();
            if (App.GatpUserRecord.SelectedServiceTypeList != null && App.GatpUserRecord.SelectedServiceTypeList.Any())
            {

                _selectedServiceTypeList.Clear();
                //  _selectedServiceTypeList = App.GatpUserRecord.SelectedServiceTypeList;

                foreach (var svcitem in App.GatpUserRecord.SelectedServiceTypeList)
                {
                    LstServiceItems.SelectedItems.Add(svcitem);
                }
            }

            var multipoint = DealerServiceList.SingleOrDefault(m => m.ShortName.ToLower().Contains("inspection"));
            if (multipoint != null)
            {
                LstServiceItems.SelectedItems.Add(multipoint);
            }


        }

        private void LstPackagesSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelectedPackage = new uspSelPkgByDealerId_Result();



            if (e.RemovedItems.Count > 0)
            {
                currentSelectedPackage = (uspSelPkgByDealerId_Result)e.RemovedItems[0];
                _selectedPackageList.Add(currentSelectedPackage);

                if (currentSelectedPackage.ShortName.ToLower().Contains("multi point inspection"))
                {
                    var multipoint = DealerPackageList.SingleOrDefault(m => m.ShortName.ToLower().Contains("multi point inspection"));

                    if (multipoint != null)
                    {
                        LstPackages.SelectedItems.Add(multipoint);
                        return;
                    }
                }


                if (LstServiceItems != null)
                {
                    foreach (var svcitem in DealerServiceList)
                    {
                        foreach (var pkgsvcs in DealerPackageServiceList)
                        {
                            if (svcitem.ServiceTypeId == pkgsvcs.ServiceTypeId && pkgsvcs.PackageId == currentSelectedPackage.Id)
                            {
                                DealerServiceList.Where(m => m.ServiceTypeId == pkgsvcs.ServiceTypeId).Update(x => x.OpacityVal = 1);
                                DealerServiceList.Where(m => m.ServiceTypeId == pkgsvcs.ServiceTypeId).Update(x => x.IsEnabledVal = true);
                            }
                        }
                    }
                }

            }
            else if (e.AddedItems.Count > 0)
            {
                currentSelectedPackage = (uspSelPkgByDealerId_Result)e.AddedItems[0];
                _selectedPackageList.Add(currentSelectedPackage);


                if (LstServiceItems != null)
                {
                    foreach (var svcitem in DealerServiceList)
                    {
                        foreach (var pkgsvcs in DealerPackageServiceList)
                        {
                            if (svcitem.ServiceTypeId == pkgsvcs.ServiceTypeId && pkgsvcs.PackageId == currentSelectedPackage.Id)
                            {
                                DealerServiceList.Where(m => m.ServiceTypeId == pkgsvcs.ServiceTypeId).Update(x => x.OpacityVal = 0.5);
                                DealerServiceList.Where(m => m.ServiceTypeId == pkgsvcs.ServiceTypeId).Update(x => x.IsEnabledVal = false);
                            }
                        }
                    }


                }


            }
            if (LstServiceItems != null)
            {
                LstServiceItems.ItemsSource = DealerServiceList;
                LstServiceItems.Items.Refresh();



            }





        }
        private void LstServiceItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var currentSelectedService = new uspSelSvcTypeByDealerId_Result();

            //if (!App.GatpUserRecord.SelectedServiceTypeList.Any())
            //{
            //    LstServiceItems.UnselectAll();
            //}

            if (TxtDescription != null)
            {
                TxtDescription.Document = null;
            }

            if (e.RemovedItems.Count > 0)
            {
                currentSelectedService = (uspSelSvcTypeByDealerId_Result)e.RemovedItems[0];
                _selectedServiceTypeList.Remove(currentSelectedService);

                if (currentSelectedService.ShortName.ToLower().Contains("multi point inspection") || currentSelectedService.ShortName.ToLower().Contains("complimentary 16 point inspection"))
                {
                    var multipoint = DealerServiceList.SingleOrDefault(m => m.ShortName.ToLower().Contains("multi point inspection"));
                    var multipoint1 = DealerServiceList.SingleOrDefault(m => m.ShortName.ToLower().Contains("complimentary 16 point inspection"));

                    if (multipoint != null)
                    {
                        LstServiceItems.SelectedItems.Add(multipoint);
                        return;
                    }
                    if (multipoint1 != null)
                    {
                        LstServiceItems.SelectedItems.Add(multipoint1);
                        return;
                    }
                }

            }

            if (e.AddedItems.Count > 0)
            {
                currentSelectedService = (uspSelSvcTypeByDealerId_Result)e.AddedItems[0];
                _selectedServiceTypeList.Add(currentSelectedService);
            }



        }



        //private void BtnBackClick(object sender, RoutedEventArgs e)
        //{
        //    App.APTMainWindow.CurrentView = "Views/Subscriber/VehicleListView.xaml";
        //}






        private void BtnNextClick(object sender, RoutedEventArgs e)
        {
            // Cursor = Cursors.Wait;
            App.GatpUserRecord.SelectedServiceTypeList = new List<uspSelSvcTypeByDealerId_Result>();
            App.GatpUserRecord.SelectedPackageList = new List<uspSelPkgByDealerId_Result>();
            App.GatpUserRecord.SelectedPersonVehicle.ServiceNotes = TxtNotes.Text;

            var selectedServices = LstServiceItems.SelectedItems.Cast<uspSelSvcTypeByDealerId_Result>();
            var selectedPackages = LstPackages.SelectedItems.Cast<uspSelPkgByDealerId_Result>();
            foreach (var svcitem in selectedServices)
            {
                App.GatpUserRecord.SelectedServiceTypeList.Add(svcitem);
            }

            foreach (var pkg in selectedPackages)
            {
                App.GatpUserRecord.SelectedPackageList.Add(pkg);
            }

            foreach (var pkg in selectedPackages)
            {
                foreach (var pkgsvc in DealerPackageServiceList.Where(m => m.PackageId == pkg.Id))
                {
                    foreach (var svc in selectedServices.Where(n => n.ServiceTypeId == pkgsvc.ServiceTypeId))
                    {
                        App.GatpUserRecord.SelectedServiceTypeList.Remove(svc);
                    }
                }

            }

            //  App.APTMainWindow.CurrentView = "Views/Service/SignaturePageView.xaml";
            Service.SignaturePageView sigPage = new Service.SignaturePageView();
            sigPage.Return += SigPage_Return;
            NavigationService.Navigate(sigPage);

            Cursor = Cursors.Arrow;
        }

        private void SigPage_Return(object sender, ReturnEventArgs<WizardResult> e)
        {
            OnReturn(e);
        }

        private void TxtNotes_GotFocus(object sender, RoutedEventArgs e)
        {
            // Process.Start("osk");
        }
        private void BtnBackClick(object sender, RoutedEventArgs e)
        {
            //  NavigationService.Navigate(new System.Uri("/ATP.KioskExpress15;Component/Views/Accounts/LoginView.xaml", UriKind.Relative));
            //   this.OnReturn(new ReturnEventArgs<string>( "BACKTOVehcileList"));
           
            NavigationService.GoBack();
        }

        //private void BtnBackClick(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
