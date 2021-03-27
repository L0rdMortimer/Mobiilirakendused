using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileApp
{
    [Activity(Label = "WebActivity")]
    public class WebActivity : Activity
    {
        WebView _webView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.web_layout);
            // Create your application here

            var aadress = Intent.GetStringExtra(Constants.AddressKey);
            _webView = FindViewById<WebView>(Resource.Id.web);
            _webView.Settings.JavaScriptEnabled = true;
            _webView.SetWebViewClient(new SimpleWebViewClient());
            _webView.LoadUrl(aadress);
            var goButton = FindViewById<Button>(Resource.Id.goButton);
            var goAddress = FindViewById<EditText>(Resource.Id.goA);
            /*goAddress.Text = "Sisesta aadress";
            goAddress.Click += delegate
            {
                goAddress.Text = "";
            };*/

            var returnButton = FindViewById<Button>(Resource.Id.returnButton);

            returnButton.Click += delegate
            {                
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            };

            goButton.Click += delegate
            {   
                //Check for address containing https and adding it if necessary.
                string newAdress = goAddress.Text;
                if (!newAdress.Contains("https://"))
                {
                    newAdress = "https://" + newAdress;
                }
                Intent intent = new Intent(this, typeof(WebActivity));
                intent.PutExtra(Constants.AddressKey, newAdress);
                StartActivity(intent);
            };
        }


        public override bool OnKeyDown([GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            if (keyCode == Keycode.Back && _webView.CanGoBack())
            {
                _webView.GoBack();
                return true;
            }

            return base.OnKeyDown(keyCode, e);
        }
    }
}