using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MobileApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileApp
{
    [Activity(Label = "SampleListActivity")]
    public class SampleListActivity : Activity
    {
        
        List<Car> items;
        protected override void OnCreate(Bundle savedInstanceState)
        { 
            base.OnCreate(savedInstanceState);   
            SetContentView(Resource.Layout.simplelist_layout);
            // Create your application here
            
            var listView = FindViewById<ListView>(Resource.Id.carList);
            var returnButton = FindViewById<Button>(Resource.Id.returnButton);

            returnButton.Click += delegate
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            };

            items = new List<Car>
            {
                new Car { Manufacturer = "Volvo", Model = "S40", KW = 65, Image = Resource.Drawable.volvos40, Description = "Old gold" },
                new Car { Manufacturer = "Volvo", Model = "S60", KW = 85, Image = Resource.Drawable.volvos60, Description = "Medium gold" }, 
                new Car { Manufacturer = "Volvo", Model = "S80", KW = 95, Image = Resource.Drawable.volvos80, Description = "Just gold" },
                new Car { Manufacturer = "Volkswagen", Model = "Passat", KW = 45 },
                new Car { Manufacturer = "Ford2", Model = "Focus2", KW = 45 },
                new Car { Manufacturer = "Ford3", Model = "Focus3", KW = 67 },
                new Car { Manufacturer = "Ford4", Model = "Focus4", KW = 6 },
                new Car { Manufacturer = "Ford5", Model = "Focus5", KW = 1050 },
                new Car { Manufacturer = "Ford6", Model = "Focus6", KW = 74 },
                new Car { Manufacturer = "Ford7", Model = "Focus7", KW = 5 },
                new Car { Manufacturer = "Ford8", Model = "Focus8", KW = 86 },
                new Car { Manufacturer = "Ford", Model = "Focus", KW = 100 },
                new Car { Manufacturer = "Volkswagen", Model = "Passat", KW = 45 },
                new Car { Manufacturer = "Ford", Model = "Focus", KW = 100 },
                new Car { Manufacturer = "Volkswagen", Model = "Passat", KW = 45 },
                new Car { Manufacturer = "Ford2", Model = "Focus2", KW = 45 },
                new Car { Manufacturer = "Ford3", Model = "Focus3", KW = 67 },
                new Car { Manufacturer = "Ford4", Model = "Focus4", KW = 6 },
                new Car { Manufacturer = "Ford5", Model = "Focus5", KW = 1050 },
                new Car { Manufacturer = "Ford6", Model = "Focus6", KW = 74 },
                new Car { Manufacturer = "Ford7", Model = "Focus7", KW = 5 },
                new Car { Manufacturer = "Ford8", Model = "Focus8", KW = 86 }
            };

            listView.Adapter = new CarAdapter(this, items);

            listView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                /*var model = items[args.Position].Model;
                Toast.MakeText(this, model, ToastLength.Long).Show();*/
                

                SetContentView(Resource.Layout.car_info_layout);
                FindViewById<TextView>(Resource.Id.carInfoManufacturer).Text = items[args.Position].Manufacturer;
                FindViewById<TextView>(Resource.Id.carInfoModel).Text = items[args.Position].Model;
                FindViewById<TextView>(Resource.Id.carInfoKW).Text = items[args.Position].KW.ToString();
                FindViewById<ImageView>(Resource.Id.carInfoImage).SetImageResource(items[args.Position].Image);
                FindViewById<TextView>(Resource.Id.carInfoDescription).Text = items[args.Position].Description;

                var returnButton = FindViewById<Button>(Resource.Id.returnButton);

                returnButton.Click += delegate
                {
                    Intent intent = new Intent(this, typeof(SampleListActivity));
                    StartActivity(intent);
                };


            };




        }
    }
}