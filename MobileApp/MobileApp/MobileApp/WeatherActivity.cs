using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MobileApp.Model;
using MobileApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileApp
{
    [Activity(Label = "WeatherActivity")]
    public class WeatherActivity : Activity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.weather_layout);

            var returnButton = FindViewById<Button>(Resource.Id.returnButton);
            returnButton.Click += delegate
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            };


            // Create your application here
            var dataService = new RemoteDataService();
            var citySearch = FindViewById<EditText>(Resource.Id.citySearch);
            var searchButton = FindViewById<Button>(Resource.Id.goButton);
            var temperature = FindViewById<TextView>(Resource.Id.dayTemp);
            var weatherForecastList = FindViewById<ListView>(Resource.Id.weatherForecastList);



            searchButton.Click += async delegate
            {
                var data = await dataService.CityWeather(citySearch.Text);
                citySearch.Text = "";
                List<WeatherForecast> weather = new List<WeatherForecast> { data };
                weatherForecastList.Adapter = new WeatherAdapter(this, weather);

                temperature.Text = $"{data.list[0].main.temp}C";
                var dayImg = await dataService.GetImgFromUrl($"https://openweathermap.org/img/wn/{data.list[0].weather[0].icon}@2x.png");
                FindViewById<ImageView>(Resource.Id.dayIcon).SetImageBitmap(dayImg);

                FindViewById<TextView>(Resource.Id.nextDay1).Text = $"{data.list[8].main.temp}C";
                var img1 = await dataService.GetImgFromUrl($"https://openweathermap.org/img/wn/{data.list[8].weather[0].icon}@2x.png");
                FindViewById<ImageView>(Resource.Id.nextDayIcon1).SetImageBitmap(img1);
                FindViewById<TextView>(Resource.Id.nextDayTemp1).Text = $"{data.list[8].weather[0].description}";

                FindViewById<TextView>(Resource.Id.nextDay2).Text = $"{data.list[16].main.temp}C";
                var img2 = await dataService.GetImgFromUrl($"https://openweathermap.org/img/wn/{data.list[16].weather[0].icon}@2x.png");
                FindViewById<ImageView>(Resource.Id.nextDayIcon2).SetImageBitmap(img2);
                FindViewById<TextView>(Resource.Id.nextDayTemp2).Text = $"{data.list[16].weather[0].description}";

                FindViewById<TextView>(Resource.Id.nextDay3).Text = $"{data.list[24].main.temp}C";
                var img3 = await dataService.GetImgFromUrl($"https://openweathermap.org/img/wn/{data.list[24].weather[0].icon}@2x.png");
                FindViewById<ImageView>(Resource.Id.nextDayIcon3).SetImageBitmap(img3);
                FindViewById<TextView>(Resource.Id.nextDayTemp3).Text = $"{data.list[24].weather[0].description}";

            };





            //var data = await dataService.CityWeather("tallinn");
            //var w1 = FindViewById<TextView>(Resource.Id.w1);
            //var w2 = FindViewById<TextView>(Resource.Id.w2);
            //var w3 = FindViewById<TextView>(Resource.Id.w3);
            //var w4 = FindViewById<TextView>(Resource.Id.w4);
            //var w5 = FindViewById<TextView>(Resource.Id.w5);
            //var w6 = FindViewById<TextView>(Resource.Id.w6);
            //var w7 = FindViewById<TextView>(Resource.Id.w7);
            //var w8 = FindViewById<TextView>(Resource.Id.w8);
            //var w9 = FindViewById<TextView>(Resource.Id.w9);
            //var w0 = FindViewById<TextView>(Resource.Id.w0);
            //w1.Text = $"{data.list[0].weather[0].description} | {data.list[0].weather[0].id}";
            //w2.Text = $"{data.list[8].weather[0].description} | {data.list[8].weather[0].id}";
            //w3.Text = $"{data.list[16].weather[0].description} | {data.list[16].weather[0].id}";
            //w4.Text = $"{data.list[24].weather[0].description} | {data.list[24].weather[0].id}";





        }
    }
}