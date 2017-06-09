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
using MyShop.Utility;

namespace MyShop.Adapter
{
    public class VehicleListAdapter : BaseAdapter<CustomerVehicle>
    {
        List<CustomerVehicle> items;
        Activity context;

        public VehicleListAdapter(Activity context, List<CustomerVehicle> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override CustomerVehicle this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            
            //return convertView;


           // var imageBitmap = ImageHelper.GetImageBitmapFromUrl("http://gillcleerenpluralsight.blob.core.windows.net/files/" + item.ImagePath + ".jpg");

            //if (convertView == null)
            //{
            //    convertView = context.LayoutInflater.Inflate(Resource.Layout.HotDogRowView, null);
            //}

            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.HotDogRowView, null);
            }
            //convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Name;

            convertView.FindViewById<TextView>(Resource.Id.hotDogNameTextView).Text = item.VehicleMake;
            convertView.FindViewById<TextView>(Resource.Id.shortDescriptionTextView).Text = item.VehicleModel;
            convertView.FindViewById<TextView>(Resource.Id.priceTextView).Text = "$ " + item.VehicleYear;
           // convertView.FindViewById<ImageView>(Resource.Id.hotDogImageView).SetImageBitmap(imageBitmap);

            return convertView;
        }

    }
}