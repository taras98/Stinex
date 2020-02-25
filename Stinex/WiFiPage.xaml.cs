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
            /*
                        var wifiManager = (WifiManager)Android.App.Application.Context.GetSystemService(Android.Content.Context.WifiService);
                        wifiManager.Disconnect();

                        string ssid = "stinex_v1.0";
                        string password = "12345678";
                        var formattedSsid = $"\"{ssid}\"";
                        var formattedPassword = $"\"{password}\"";

                        var wifiConfig = new WifiConfiguration
                        {
                            Ssid = formattedSsid,
                            PreSharedKey = formattedPassword
                        };
                        var addNetwork = wifiManager.AddNetwork(wifiConfig);
                        var network = wifiManager.ConfiguredNetworks
                             .FirstOrDefault(n => n.Ssid == formattedSsid);
                        var enableNetwork = wifiManager.EnableNetwork(network.NetworkId, true);
                        if (network == null)
                        {
                            return;
                        }
                        string site = "http://192.168.1.1";

                        string site2 = "http://192.168.1.1/par?ssid=hello&pas=stinex";
                        var web = new HtmlAgilityPack.HtmlWeb();
                        HtmlDocument doc = web.Load(site);

                        HtmlDocument doc2 = web.Load(site2);
                        var a = doc2.ParsedText;

                        WebRequest request = WebRequest.Create(site);
                        WebResponse response = request.GetResponse();
                        using (Stream stream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                string line = "";
                                while ((line = reader.ReadLine()) != null)
                                {
                                    Console.WriteLine(line);
                                }
                            }
                        }
                        response.Close();
                        */
            var client = new RestClient("http://192.168.7.239/index.php");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);
            var request = new RestRequest("resource/{id}");
            request.AddParameter("id", "Hello");
            
            var response = client.Post(request);
            var content = response.Content; // raw content as string
          }
        
    }
}