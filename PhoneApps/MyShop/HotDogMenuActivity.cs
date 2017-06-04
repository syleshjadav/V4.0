using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyShop.Core;

namespace MyShop
{
    

    [Activity(Label = "HotDogMenuActivity",MainLauncher =true)]
    public class HotDogMenuActivity : Activity
    {


        private HotDogDataService dataservice;
        private List<HotDog> allHotDogs;
        private ListView hotDogListView;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.HotDogMenuView);

            dataservice = new HotDogDataService();

            allHotDogs = dataservice.GetAllHotDogs();


            hotDogListView = FindViewById<ListView>(Resource.Id.hotDogListView);


        }
    }
}