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

namespace Stinex
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WiFiPage : ContentPage
    {
        public WiFiPage()
        {
            InitializeComponent();
        }
        void ConnectClicked(object sender, EventArgs e)
        {
            var wifiManager = (WifiManager)Android.App.Application.Context.GetSystemService(Android.Content.Context.WifiService);
            var current = Connectivity.NetworkAccess ;

            Con.Text = current.ToString();
            Thread.Sleep(2000);
            wifiManager.DisableNetwork(wifiManager.ConnectionInfo.NetworkId);
            Con.Text = wifiManager.DisableNetwork(wifiManager.ConnectionInfo.NetworkId).ToString();

            /*
            string site = "http://192.168.1.1?SSID=valera&Password=lox";

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(site);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            using (StreamReader stream = new StreamReader(
                 resp.GetResponseStream(), Encoding.UTF8))
            {
            }
            */
        }
    }
}