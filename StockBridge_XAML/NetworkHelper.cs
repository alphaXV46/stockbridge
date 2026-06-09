using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Linq;

namespace StockBridge_XAML
{
    public static class NetworkHelper
    {
        // Mendeteksi IP Wi-Fi/LAN asli yang memiliki Gateway
        public static string GetRealLocalIP()
        {
            try
            {
                foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (ni.OperationalStatus == OperationalStatus.Up && ni.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                    {
                        var props = ni.GetIPProperties();
                        if (props.GatewayAddresses.Any())
                        {
                            foreach (var ip in props.UnicastAddresses)
                            {
                                if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                                {
                                    return ip.Address.ToString();
                                }
                            }
                        }
                    }
                }
            }
            catch { }
            return "localhost";
        }
    }
}
