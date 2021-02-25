using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace MobileApp
{
    [Activity(Label = "VibrateActivity")]
    public class VibrateActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.vibrate_layout);

            // Create your application here
            var returnButton = FindViewById<Button>(Resource.Id.returnButton);

            var duration = TimeSpan.FromSeconds(10);
            Vibration.Vibrate(duration);

            returnButton.Click += delegate
            {
                Vibration.Cancel();
                Intent intent = new Intent(this, typeof(EssentialsActivity));
                StartActivity(intent);
            };


        }
    }
}