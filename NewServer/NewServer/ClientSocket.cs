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

    class ClientSocket
    {
        public delegate void ClientSocketActionEventHandler(ClientSocket Sender);
        private TcpClient tcp;
        byte[] buffer;
        int length = 0;
        public enum status { on, off, error };
        status currentStatus = status.off;
        public event ClientSocketActionEventHandler EventHandlersList;
        private void OnSocketAction()
        {
            if (EventHandlersList != null) EventHandlersList(this);
        }

        public void StartToWaitMessage()
        {
            Thread th = new Thread(MessageReceiver);
            th.Start();
        }
        public ClientSocket(TcpClient client)
        {
            tcp = client;
            buffer = new byte[1000];
            currentStatus = status.on;
            StartToWaitMessage();
        }
        public int Length
        {
            get
            {
                return length;
            }
        }
        public byte[] Buffer
        {
            get
            {
                return buffer;
            }
        }
        public void ClearBuffer()
        {
            Array.Clear(this.buffer, 0, this.buffer.Length);
            length = 0;
        }
        public void MessageReceiver()
        {
            while (true)
            {
                byte[] localBuffer = new byte[1000];
                try
                {
                    NetworkStream stream = tcp.GetStream();
                    stream.Read(localBuffer, 0, 1000);
                    length = localBuffer.Length;                    
                }
                catch (Exception)
                {
                    currentStatus = status.error;                                       
                }

                Thread threadForCopy = new Thread(delegate()
                {
                    CopyInMainBuffer(localBuffer);
                    OnSocketAction();
                });
                lock (this)
                {
                    threadForCopy.Start();
                }
            }
        }

        public string DataFromBuffer()
        {
            return ConvertToString(buffer);
        }

        public status RequestStatus()
        {
            return currentStatus;
        }

        public void CopyInMainBuffer(byte[] localBuffer)
        {
            localBuffer.CopyTo(this.buffer, 0);
        }
        public static byte[] ConvertToArrayOfByte(string str)
        {
            byte[] bytes = new byte[1000];
            for (int i = 0; i < str.Length; i++)
            {
                bytes[i] = Convert.ToByte(str[i]);
            }
            return bytes;
        }
        public static string ConvertToString(byte[] bytes)
        {
            string str = System.Text.Encoding.UTF8.GetString(bytes);
            return str;
        }

        public bool Send(string data)
        {
            if (data.Length != 0)
            {
                try
                {
                    NetworkStream stream = tcp.GetStream();
                    byte[] bytes = new byte[1000];
                    bytes = ConvertToArrayOfByte(data);
                    stream.Write(bytes, 0, bytes.Length);
                    return true;
                }
                catch (SocketException)
                {
                    Disconnect(tcp);                                       
                    return false;
                }                
            }
            return true;
        }
        public void Disconnect(TcpClient client)
        {
            client.Close();
            currentStatus = status.off;
        }
    }
}
