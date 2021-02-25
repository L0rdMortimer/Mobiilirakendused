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
    [Activity(Label = "AccelerometerActivity")]
    public class AccelerometerActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.accelerometer_layout);

            // Create your application here
            var accX = FindViewById<TextView>(Resource.Id.accX);
            var accY = FindViewById<TextView>(Resource.Id.accY);
            var accZ = FindViewById<TextView>(Resource.Id.accZ);
            var returnButton = FindViewById<Button>(Resource.Id.returnButton);

            SensorSpeed speed = SensorSpeed.UI;
            Accelerometer.Start(speed);
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
            {
                var data = e.Reading;
                accX.Text = "X: " + data.Acceleration.X;
                accY.Text = "Y: " + data.Acceleration.Y;
                accZ.Text = "Z: " + data.Acceleration.Z;
            }

            returnButton.Click += delegate
            {
                Intent intent = new Intent(this, typeof(EssentialsActivity));
                StartActivity(intent);
                Accelerometer.Stop();
            };
            
        }
    }
}