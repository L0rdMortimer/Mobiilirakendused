﻿using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace MobileApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var textView = FindViewById<TextView>(Resource.Id.welcomeText);
            var counterButton = FindViewById<Button>(Resource.Id.counterButton);
            var counterView = FindViewById<TextView>(Resource.Id.counterText);           
            int counter = 0;
            var toCalculatorButton = FindViewById<Button>(Resource.Id.toCalculator);
            var toWebButton = FindViewById<Button>(Resource.Id.toWeb);
            var toEssentialsButton = FindViewById<Button>(Resource.Id.toEssentials);
            var toListButton = FindViewById<Button>(Resource.Id.toList);
            var toWeatherButton = FindViewById<Button>(Resource.Id.toWeather);

            counterButton.Click += delegate
            {
                textView.Text = "Hello Worms";
                counter += 1;
                counterView.Text = counter.ToString();                
            };

            toCalculatorButton.Click += delegate
            {
                Intent intent = new Intent(this, typeof(CalculatorActivity));
                StartActivity(intent);
            };

            toWebButton.Click += delegate
            {
                Intent intent = new Intent(this, typeof(WebActivity));
                intent.PutExtra(Constants.AddressKey, Constants.DefaultUrl);
                StartActivity(intent);
            };

            toEssentialsButton.Click += delegate
            {
                Intent intent = new Intent(this, typeof(EssentialsActivity));
                StartActivity(intent);
            };

            toListButton.Click += delegate
            {
                Intent intent = new Intent(this, typeof(SampleListActivity));
                StartActivity(intent);
            };

            toWeatherButton.Click += delegate
            {
                Intent intent = new Intent(this, typeof(WeatherActivity));
                StartActivity(intent);
            };


        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}