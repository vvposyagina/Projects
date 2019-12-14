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
    class ServerSocket
    {
        bool isServerRunning;
        List<TcpClient> clients = new List<TcpClient>();
        TcpListener listener;
        int port = 2100;
        IPEndPoint point;
        List<Thread> threads = new List<Thread>();
        Dictionary<ClientSocket, TcpClient> reseivers = new Dictionary<ClientSocket, TcpClient>();
        ClientEvent clientConnected;

        public void Start()
        {
            try
            {
                isServerRunning = true;
                point = new IPEndPoint(IPAddress.Any, port);
                listener = new TcpListener(point);
                listener.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
            ClientAccepter();
        }

        private void ClientDataHandler(ClientSocket cl)
        {

        }

        public void ClientAccepter()
        {
            Thread TCPClientAccepter = new Thread(delegate()
            {
                while (isServerRunning)
                {
                    TcpClient client = null;
                    try
                    {
                        client = listener.AcceptTcpClient();
                        ClientSocket receiver = new ClientSocket(client);
                        receiver.AddDataHandler(new ClientEvent(ClientDataHandler));
                        //receiver.MessageReceiver();
                        //Thread thh = new Thread(delegate()
                        //{
                        //    receiver.MessageReceiver();
                        //});
                        //thh.Start();
                        reseivers.Add(receiver, client);
                        clients.Add(client);
                    }
                    catch (SocketException)
                    {
                        Disconnect(client);
                        Console.WriteLine("Клиент отключен");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        Console.ReadLine();
                    }
                }
            }
                );
            TCPClientAccepter.Start();
            threads.Add(TCPClientAccepter);
        }

        public void CheckReseivers()
        {
            Thread th = new Thread(delegate()
            {

                while (isServerRunning)
                {
                    for (int i = 0; i < reseivers.Count; i++)
                    //foreach (KeyValuePair<Receiver, TcpClient> i in reseivers)
                    {
                        ClientSocket receiver = null;
                        TcpClient client = null;
                        try
                        {
                            receiver = reseivers.Keys.ElementAt(i);
                            client = reseivers.Values.ElementAt(i);

                            receiver.MessageReceiver();
                            if (!receiver.IsEmptyBuffer())
                            {
                                byte[] bytes = new byte[receiver.Length];

                                for (int j = 0; j < receiver.Length; j++)
                                {
                                    bytes[j] = Convert.ToByte(Char.ToUpper(Convert.ToChar(receiver.Buffer[j])));
                                }

                                MessageSender(client, bytes);
                                receiver.ClearBuffer();
                            }
                        }
                        catch (SocketException)
                        {
                            Disconnect(client);
                            Console.WriteLine("Клиент отключен");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            Console.ReadLine();
                        }
                    }
                }
            }
                );
            th.Start();
        }

        public void MessageSender(TcpClient c_client, byte[] bytes)
        {
            try
            {
                NetworkStream stream = c_client.GetStream();
                stream.Write(bytes, 0, bytes.Length);
            }
            catch (SocketException)
            {
                Disconnect(c_client);
                Console.WriteLine("Клиент отключен");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }
        

    }
}
