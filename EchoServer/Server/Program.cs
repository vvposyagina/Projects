using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;

namespace Server
{
    class Server
    {
        
        bool isServerRunning;
        Hashtable clients;
        Socket listener;
        int port = 2000;
        IPEndPoint point;
        List<Thread> threads = new List<Thread>();
        //Dictionary<Socket, Thread> thrds = new Dictionary<Socket, Thread>();

        public void Start()
        {
            try
            {
                clients = new Hashtable(2);
                isServerRunning = true;
                listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                point = new IPEndPoint(IPAddress.Any, port);
                listener.Bind(point);
                listener.Listen(2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }

            SocketAccepter();
        }

        public void SocketAccepter()
        {
            Thread th = new Thread(delegate()
                { 
                    while(isServerRunning)
                    {
                        try
                        {
                            Socket client = listener.Accept();
                            clients.Add(client, "");
                            Thread thh = new Thread(delegate()
                                {
                                    MessageReceiver(client);
                                }
                                );
                            thh.Start();
                            //thrds.Add(client,thh);

                            
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            Console.ReadLine();
                        }
                    }
                }
                );
            th.Start();
            threads.Add(th);
        }

        public void MessageReceiver(Socket r_client)        
        {
            Thread th = new Thread(delegate()
                {
                    while (isServerRunning)
                    {
                        try
                        {
                            byte[] bytes = new byte[1024];
                            r_client.Receive(bytes);
                            if (bytes.Length != 0)
                            {
                                MessageSender(r_client, bytes);
                            }
                            
                           
                        }
                        catch(SocketException ex)
                        {
                            Console.WriteLine("Удаляем клиент");
                            //thrds.Remove(r_client);
                            clients.Remove(r_client);
                            break;
                            
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            Console.ReadLine();
                        }
                    }
                });
            th.Start();
            threads.Add(th);
        }

        public void MessageSender(Socket c_client, byte[] bytes)
        {
            try
            {
                c_client.Send(bytes);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Server serv = new Server();
            serv.Start();
        }
    }
}
