﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileApp
{
    [Activity(Label = "SampleListActivity")]
    public class SampleListActivity : ListActivity
    {
        string[] items;
        //List<Car> items;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);   
            //SetContentView(Resource.Layout.simplelist_layout);
            // Create your application here
            
            //var listView = FindViewById<ListView>(Resource.Id.carListView);
            items = new string[] { "Volvo", "Subaru", "Audi" };
            ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleExpandableListItem1, items);
            //listView.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);


            //items = new List<Car>
            /* {
                 new Car { Manufacturer = "Ford", Model = "Focus", KW = 100 },
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

             listView.Adapter = new CarAdapter(this, items);*/




        }
    }
}