using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CheckClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();

            client.Connect("127.0.0.1", 2100);

            NetworkStream stream = client.GetStream();
            
            while (true)
            {
                if (client.Available > 0)
                {
                    byte[] buffer = new byte[client.Available];
                    stream.Read(buffer, 0, client.Available);
                    string text = Encoding.UTF8.GetString(buffer);
                    Console.WriteLine(text);
                }
            }
        }
    }
}
