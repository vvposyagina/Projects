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
            Server serv = new Server();
            serv.Start();
            serv.CheckReseivers();
        }
    }
}
