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

namespace MyShop
{
    [Activity(Label = "MenuActivity", MainLauncher = true)]
    public class MenuActivity : Activity
    {
        private Button pickUpKeysButton;
        private Button dropKeysButton;
        private Button expressCheckInButton;
        private Button addVehicleButton;
       // private Button takePictureButton;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainMenu);

            FindViews();

            HandleEvents();
        }

        private void FindViews()
        {
            pickUpKeysButton = FindViewById<Button>(Resource.Id.pickUpKeyButton);
            dropKeysButton = FindViewById<Button>(Resource.Id.dropkeyButton);
            expressCheckInButton = FindViewById<Button>(Resource.Id.expressCheckInButton);
            addVehicleButton = FindViewById<Button>(Resource.Id.addVehicleButton);
            //takePictureButton = FindViewById<Button>(Resource.Id.takePictureButton);
        }

        private void HandleEvents()
        {
            pickUpKeysButton.Click += PickUpKeysButton_Click;
            dropKeysButton.Click += DropKeysButton_Click;
            expressCheckInButton.Click += ExpressCheckInButton_Click;
            addVehicleButton.Click += AddVehicleButton_Click;
        }

        private void AddVehicleButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DropKeysButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ExpressCheckInButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PickUpKeysButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AboutActivity));
            StartActivity(intent);
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(HotDogMenuActivity));
            StartActivity(intent);
        }
    }
}