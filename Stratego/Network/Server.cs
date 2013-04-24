using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Network
{
    public class Server
    {
        private NetworkController.Port currentPort;
        private TcpListener tcpListener;
        private Thread listenThread;
        private ByteContainer container;
        private bool isActive = false;

        public Server(NetworkController.Port port, ByteContainer container)
        {
            this.currentPort = port;
            this.container = container;
        }

        public Boolean IsActive()
        {
            return this.isActive;
        }

        public void Start()
        {
            if (isActive)
                throw new Exception("You cannot start a Server that is already started!");
            this.tcpListener = new TcpListener(IPAddress.Any, (int)this.currentPort);
            this.listenThread = new Thread(new ThreadStart(Listen));
            isActive = true;
            this.listenThread.Start();
        }

        public void Stop()
        {
            if (!isActive)
                throw new Exception("You cannot stop a Server that is already stopped!");
            isActive = false;
            this.listenThread.Abort();
        }

        private void Listen()
        {
            this.tcpListener.Start();
            while (true)
            {
                //blocks until a client has connected to the server
                TcpClient client = this.tcpListener.AcceptTcpClient();
                //create a thread to handle communication
                //with connected client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }

        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            ASCIIEncoding encoder = new ASCIIEncoding();

            while (true)
            {
                bytesRead = 0;

                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    //a socket error has occured
                    break;
                }

                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    break;
                }

                //message has successfully been received
                this.container.WriteData(message);
                break;
            }

            tcpClient.Close();
        }

    }
}
