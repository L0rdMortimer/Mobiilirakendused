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
    class WeatherAdapter : BaseAdapter<WeatherForecast>
    {
        List<WeatherForecast> _weather;
        Activity _context;

        public WeatherAdapter(Activity context, List<WeatherForecast> weather)
        {
            _context = context;
            _weather = weather;
        }
        public override WeatherForecast this[int position]
        {
            get { return _weather[position]; }
        }


        public override int Count
        {
            get { return _weather[0].list.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            
            RemoteDataService image = new RemoteDataService();

            View view = convertView;
            
               if (view == null)
            {
                    view = _context.LayoutInflater.Inflate(Resource.Layout.weather_forecast_layout, null);
                    //view.FindViewById<TextView>(Resource.Id.nextDay).Text = $"{_weather[position].list[0].main.temp}C";
                    ////view.FindViewById<ImageView>(Resource.Id.nextDayIcon).SetImageResource(_weather[position].weather[3]);
                    //view.FindViewById<TextView>(Resource.Id.nextDayTemp).Text = $"{ _weather[position].list[8].main.temp}C";

                    view.FindViewById<TextView>(Resource.Id.nextDay).Text = $"{_weather[0].list[position].main.temp}C";
                    //var img = image.GetImgFromUrl($"https://openweathermap.org/img/wn/{_weather[position].list[8].weather[0].icon}@2x.png");
                    //view.FindViewById<ImageView>(Resource.Id.nextDayIcon).SetImageBitmap(img);
                    view.FindViewById<TextView>(Resource.Id.nextDayTemp).Text = $"{_weather[0].list[position].weather[0].description}";



            }





            return view;
        }
    }
}