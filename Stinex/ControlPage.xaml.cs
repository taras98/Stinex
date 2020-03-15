using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Stinex
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlPage : ContentPage
    {
        private ObtainData data = new ObtainData();
        private string _devid;
        public ControlPage(string devid)
        {           
            InitializeComponent();
            _devid = devid;
            var d = GETdevid("http://213.174.0.16:12080/is_connect.php", _devid);
            data = JsonConvert.DeserializeObject<ObtainData>(d.Content);
            room.Text = data.temp_room.ToString();
            panel.Text = data.temp_panel.ToString();
            status.Text = data.heat_status.ToString();
        }

        public IRestResponse GETdevid(string url, string devid)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddParameter("dev_id", devid);
            var response = client.Execute(request);
            return response;
        }
        public IRestResponse GETsenddata(string url, string devid, int status, double temproom, double temppanel)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddParameter("dev_id", devid);
            request.AddParameter("heat_control", status);
            request.AddParameter("need_temp_room", temproom);
            request.AddParameter("need_temp_panel", temppanel);
            var response = client.Execute(request);
            return response;
        }

        private void refreshBtn_Clicked(object sender, EventArgs e)
        {
            var d = GETdevid("http://213.174.0.16:12080/is_connect.php", _devid);
            data = JsonConvert.DeserializeObject<ObtainData>(d.Content);
            room.Text = data.temp_room.ToString();
            panel.Text = data.temp_panel.ToString();
            status.Text = data.heat_status.ToString();
        }

        private void sendBtn_Clicked(object sender, EventArgs e)
        {
            var v = GETsenddata("http://213.174.0.16:12080/is_connect.php", _devid, Convert.ToInt32(newstatus.Text), Convert.ToDouble(newroom.Text), Convert.ToDouble(newpanel.Text));

        }
    }
}