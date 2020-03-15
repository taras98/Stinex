using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Android.Net.Wifi;
using System.Net;
using System.IO;
using System.Threading;
using HtmlAgilityPack;
using RestSharp;
using Newtonsoft.Json;

namespace Stinex
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WiFiPage : ContentPage
    {
        ObtainData data = new ObtainData();
        string devid;
        public WiFiPage()
        {
            InitializeComponent();
        }
        void ConnectClicked(object sender, EventArgs e)
        {
            var wifiManager = (WifiManager)Android.App.Application.Context.GetSystemService(Android.Content.Context.WifiService);
            var a = POST("http://10.10.10.1:10893/scan");
            wifilist.Text = a.Content;

            var b = POST("http://10.10.10.1:10893/dev_id");
            devid = b.Content;

        }
        public IRestResponse POST(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            return client.Execute(request);
        }
        public IRestResponse POSTparam(string url, string ssid, string pass)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddParameter("ssid", ssid);
            request.AddParameter("password", pass);
            return client.Execute(request);
        }        

        private async void NextCon_Clicked(object sender, EventArgs e)
        {
            POSTparam("http://10.10.10.1:10893/data", ssid.Text, password.Text);
            await Navigation.PushAsync(new ControlPage(devid));
           
        }
    }
}