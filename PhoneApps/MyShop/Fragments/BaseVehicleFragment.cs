using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MyShop.Core;

namespace MyShop.Fragments
{
    public class BaseVehicleFragment : Fragment
    {
        protected ListView listView;
        protected VehicleDataService vehicleDataService;
        protected List<CustomerVehicle> customerVehicles;


        public BaseVehicleFragment()
        {
            vehicleDataService = new VehicleDataService();
        }

        protected void HandleEvents()
        {
            listView.ItemClick += ListView_ItemClick;
        }
        protected void FindViews()
        {
            listView = this.View.FindViewById<ListView>(Resource.Id.hotDogListView);
        }

        protected void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var custVeh= customerVehicles[e.Position];

            var intent = new Intent();
            intent.SetClass(this.Activity, typeof(VehiclesActivity));
            intent.PutExtra("selectedHotDogId", custVeh.VehicleId);

            StartActivityForResult(intent, 100);
        }
    }
}