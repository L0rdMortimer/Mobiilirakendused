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
    [Activity(Label = "EssentialsActivity")]
    public class EssentialsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.essentials_layout);

            // Create your application here

            var accelerometerButton = FindViewById<Button>(Resource.Id.toAccelerometer);
            var flashlightButton = FindViewById<Button>(Resource.Id.flashlightButton);
            var vibrateButton = FindViewById<Button>(Resource.Id.toVibrate);
            var returnButton = FindViewById<Button>(Resource.Id.returnButton);
            bool on = false;


            //Accelerometer essential
            accelerometerButton.Click += delegate
            {
                Intent intent = new Intent(this, typeof(AccelerometerActivity));
                StartActivity(intent);
                Flashlight.TurnOffAsync();
            };


            //Flashlight essential
            
            flashlightButton.Click += async delegate
            {                
                if (!on)
                {                    
                    await Flashlight.TurnOnAsync();
                    on = true;
                } else if(on){                    
                    await Flashlight.TurnOffAsync();
                    on = false;
                }           
            };


            //Vibration essential
            vibrateButton.Click += delegate
            {
                Intent intent = new Intent(this, typeof(VibrateActivity));
                StartActivity(intent);
                Flashlight.TurnOffAsync();
            };


            //Return to previous page
            returnButton.Click += delegate
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
                Flashlight.TurnOffAsync();
            };

        }
    }
}