using System;
using System.Collections.Generic;
using System.Text;

namespace Stinex
{
    interface IWifiConnector
    {
        void ConnectToWifi(string ssidd, string password);
    }
}
