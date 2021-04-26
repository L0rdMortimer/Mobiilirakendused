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
using System.Net.Http;
using Newtonsoft.Json;
using MobileApp.Model;
using System.Threading.Tasks;
using Android.Graphics;

namespace MobileApp.Services
{
    class RemoteDataService
    {
        const string ApiKey = "8af3caef751593cd857dd8aabd80f6e9";

        public async Task<WeatherForecast> CityWeather(string cityName)
        {
            var CityName = cityName;
            var client = new HttpClient();
            var response = await client.GetStringAsync($"https://api.openweathermap.org/data/2.5/forecast?q={CityName}&appid={ApiKey}&units=metric");

            var data = JsonConvert.DeserializeObject<WeatherForecast>(response);
            return data;
        }


        public async Task<Bitmap> GetImgFromUrl(string url)
        {
            //https://openweathermap.org/img/wn/{_weather[position].list[8].weather[0].icon}@2x.png

            using (var client = new HttpClient())
            {
                var msg = await client.GetAsync(url);
                if(msg.IsSuccessStatusCode)
                {
                    using (var stream = await msg.Content.ReadAsStreamAsync())
                    {
                        var bitmap = await BitmapFactory.DecodeStreamAsync(stream);
                        return bitmap;
                    }
                }
            }
            return null;
        }
    }
}