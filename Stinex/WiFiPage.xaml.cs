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
        public WiFiPage()
        {
            InitializeComponent();
        }
        void ConnectClicked(object sender, EventArgs e)
        {

            var wifiManager = (WifiManager)Android.App.Application.Context.GetSystemService(Android.Content.Context.WifiService);

            //string ssid = "stinex";
            //string password = "stinex2908";
            //var formattedSsid = $"\"{ssid}\"";
            //var formattedPassword = $"\"{password}\"";

            //var wifiConfig = new WifiConfiguration
            //{
            //    Ssid = formattedSsid,
            //    Bssid = formattedSsid,
            //    PreSharedKey = formattedPassword
            //};
            //var addNetwork = wifiManager.AddNetwork(wifiConfig);
            //var network = wifiManager.ConfiguredNetworks
            //     .FirstOrDefault(n => n.Ssid == formattedSsid);
            //IList<WifiConfiguration> myWifi = wifiManager.ConfiguredNetworks;
            //wifiManager.Disconnect();
            //wifiManager.EnableNetwork(myWifi.FirstOrDefault(x => x.Ssid.Contains(ssid)).NetworkId, true);
            //wifiManager.Reconnect();
            //if (network == null)
            //{
            //    return;
            //}
            //wifiManager.Disconnect();

            //var enableNetwork = wifiManager.EnableNetwork(network.NetworkId, true);

            /*
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
            var a = POST("http://10.10.10.1:10893/scan");
            //  name.Text = "Aviable network: " + a.Content.Replace(",", " ");
            value.Text += a.Content;

            var b = POST("http://10.10.10.1:10893/dev_id");
            string devid = b.Content;
            value.Text += b.Content;

            var c = POSTparam("http://10.10.10.1:10893/data", a.Content.Replace(",", ""), "mel@sk1995");
            var res = c.Content;
            value.Text += c.Content;

           //wifiManager.Disconnect();
            

            //var client = new RestClient(path.Text);
            //// client.Authenticator = new HttpBasicAuthenticator(username, password);
            //var request = new RestRequest("resource/{id}");
            //request.AddParameter(name.Text, value.Text);

            //var response = client.Post(request);
            //var content = response.Content; // raw content as string
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
        public IRestResponse GETdevid(string url, string devid)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddParameter("dev_id", devid);
            var response = client.Execute(request);
            return response;
        }
        public IRestResponse GETsenddata(string url, string devid)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddParameter("dev_id", devid);
            request.AddParameter("heat_control", 1);
            request.AddParameter("need_temp_room", 22);
            request.AddParameter("need_temp_panel", 60);
            var response = client.Execute(request);
            return response;
        }

        private void NextCon_Clicked(object sender, EventArgs e)
        {
            var d = GETdevid("http://213.174.0.16:12080/is_connect.php", "5C:CF:7F:3C:FF:E6");
            data = JsonConvert.DeserializeObject<ObtainData>(d.Content);
            value.Text += data.temp_panel.ToString() + data.temp_room.ToString() + data.heat_status.ToString();
            var v = GETsenddata("http://213.174.0.16:12080/is_connect.php", "5C:CF:7F:3C:FF:E6");
        }
    }
}