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
    class Program
    {
        static void Main(string[] args)
        {
            ServerSocket serv = new ServerSocket();
            serv.Start();
            Server server = new Server();
            server.SetClientSocketActionConnected(serv);
            //serv.CheckReseivers();
        }
    }
}
