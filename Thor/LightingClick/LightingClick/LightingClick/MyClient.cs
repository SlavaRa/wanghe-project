using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace LightingClick
{
    class MyClient
    {
        public MyClient()
        {

        }

        public static void SendMessage(string ip,int port,string msg)
        {
            try
            {

                IPEndPoint _ip = new IPEndPoint(IPAddress.Parse(ip), port);
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(_ip);
                byte[] bytes = Encoding.UTF8.GetBytes(msg);
                socket.Send(bytes, bytes.Length, 0);
            }
            catch
            {

            }
        }
    }
}
