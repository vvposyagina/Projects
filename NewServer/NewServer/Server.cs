using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        List<ClientSocket> clients = new List<ClientSocket>();

        public void SetClientSocketActionSender(ClientSocket client)
        {
            client.EventHandlersList += new ClientSocket.ClientSocketActionEventHandler(Process);
        }
        public void SetClientSocketActionConnected(ServerSocket serverSocket)
        {
            serverSocket.EventHandlersList += new ServerSocket.ClientSocketActionEventHandler(AddClient);
        }


        public void Process(ClientSocket client)
        {
            string str = ClientSocket.ConvertToString(client.Buffer);
            client.Send(str.ToUpper());
        }
        public void AddClient(ClientSocket client)
        {
            clients.Add(client);
            SetClientSocketActionSender(client);
        }
    }
}
