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
        public delegate void ClientSocketActionEventHandler(ClientSocket client);
        bool isServerRunning;
        List<ClientSocket> clients = new List<ClientSocket>();
        TcpListener listener;
        int port = 2100;
        IPEndPoint point;
        public event ClientSocketActionEventHandler EventHandlersList;

        private void OnSocketAction(ClientSocket client)
        {
            if (EventHandlersList != null) EventHandlersList(client);
        }

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

        public void ClientAccepter()
        {
            Thread TCPClientAccepter = new Thread(delegate()
            {
                while (isServerRunning)
                {

                    try
                    {
                        ClientSocket client = new ClientSocket(listener.AcceptTcpClient());
                        OnSocketAction(client);
                        clients.Add(client);
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
        }
    }
}
