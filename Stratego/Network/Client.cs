using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Network
{
    public class Client
    {
        IPEndPoint recipient;

        public Client(IPEndPoint recipient)
        {
            this.recipient = recipient;
        }

        public bool Send(byte[] buffer)
        {
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(this.recipient);

                NetworkStream clientStream = client.GetStream();
                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();
                clientStream.Close();

                return true;
            }
            catch (System.Net.Sockets.SocketException e)
            {
                return false;
            }
        }
        internal void SetRecipient(IPEndPoint recipient)
        {
            this.recipient = recipient;
        }
    }
}
