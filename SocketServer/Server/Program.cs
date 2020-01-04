using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerSide
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is the ServerSide");

            Socket listenerSockets = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse("127.0.0.1"),8888);
            listenerSockets.Bind(ipEnd);
            listenerSockets.Listen(0);
            Socket clientSocket = listenerSockets.Accept();
            byte[] Buffer = new byte[clientSocket.SendBufferSize];

            int readByte;

            do
            {
                readByte = clientSocket.Receive(Buffer);
                byte[] rData = new byte[readByte];
                Array.Copy(Buffer, rData, readByte);
                Console.WriteLine("We got: " + System.Text.Encoding.UTF8.GetString(rData));
            } while (readByte > 0);
            Console.WriteLine(readByte.ToString());
            Console.ReadKey();
                      

        }
    }
}
