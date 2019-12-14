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
    delegate void ClientEventHandler(ClientSocket cl);
    class ClientSocket
    {
        TcpClient client;
        byte[] buffer;
        bool cleanBuffer = true;
        int length = 0;
        ClientEvent dataReceived;
        public void AddDataHandler(ClientEvent dataHandler)
        {
            dataReceived += dataHandler;
        }
        public void StartToWaitMessage()
        {
            Thread th = new Thread(MessageReceiver);
            th.Start();
        }
        public byte[] Buffer
        {
            get
            {
                return buffer;
            }
        }

        public int Length
        {
            get
            {
                return length;
            }
        }

        public ClientSocket(TcpClient client)
        {
            this.client = client;
            buffer = new byte[1000];
        }
        public void ClearBuffer()
        {
            Array.Clear(this.buffer, 0, this.buffer.Length);
            cleanBuffer = true;
            length = 0;
        }
        public void MessageReceiver()
        {
            while (true)
            {
                try
                {
                    NetworkStream stream = client.GetStream();
                    int i;
                    int j = 0;
                    while (stream.DataAvailable)
                    //while (i != -1)
                    {
                        i = stream.ReadByte();
                        buffer[j] = Convert.ToByte(i);
                        j++;
                    }
                    length = j;
                    if (j > 0)
                    {
                        cleanBuffer = false;
                    }
                    dataReceived(this);

                }

                catch (Exception ex)
                {
                    throw new SocketException();
                }
            }

        }

        public bool IsEmptyBuffer()
        {
            return cleanBuffer;
        }

        public void Disconnect(TcpClient client)
        {
            client.Close();
        }

    }
}
