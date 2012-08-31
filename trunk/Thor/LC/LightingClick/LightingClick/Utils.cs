using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace LightingClick
{
    public class Utils
    {
        public static string GetIP()   //获取本地IP 
        {
            IPHostEntry ipHost = Dns.GetHostEntry("");
            foreach (IPAddress ipAddr in ipHost.AddressList)
            {
                if (ipAddr.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ipAddr.ToString();
                }
            }
            return "";
        }


        public static IPAddress[] GetIPs()   //获取本地IP 
        {
            IPHostEntry ipHost = Dns.GetHostEntry("");
            return ipHost.AddressList;
        }
    }
}
