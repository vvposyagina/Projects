using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    class Client
    {
        private bool client_running;
        private Socket client;
        private IPAddress ip = IPAddress.Parse("127.0.0.1");
        private int port = 1991;
        private List<Thread> threads = new List<Thread>();

        public void Connect()
        {
            try
            {
                client_running = true;
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client.Connect(ip, port);
                Receiver();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Receiver()
        {
            Thread th = new Thread(delegate()
            {
                while (client_running)
                {
                    try
                    {
                        byte[] bytes = new byte[1024];
                        
                        client.Receive(bytes);
                        if (bytes.Length != 0)
                        {
                            string data = Encoding.UTF8.GetString(bytes);                            

                            Console.WriteLine("Ответ: {0}", data);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            });
            th.Start();
            threads.Add(th);
        }

        public void Sender(string msg)
        {
            try
            {
                byte[] bytes = new byte[1024];
                bytes = Encoding.UTF8.GetBytes(msg);
                client.Send(bytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Client cl = new Client();
            cl.Connect();
            cl.Sender("Ranis grubiyan");
            cl.Receiver();
        }
    }
}
