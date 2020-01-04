using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("This is the Cliente");
            Socket master = new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp);
            IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            master.Connect(ipEnd);
            //master.Send(System.Text.Encoding.UTF8.GetBytes("Hey"));

            string sendData = "";
            do
            {
                Console.Write("Data to Send:");
                sendData = Console.ReadLine();
                master.Send(System.Text.Encoding.UTF8.GetBytes(sendData));
            } while (sendData.Length > 0);
            master.Close();
        }
    }
}
