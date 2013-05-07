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
        private TcpListener tcpListener;
        private Thread listenThread;
        private NetworkController.Port port;
        private byte[] readData = null;
        private Boolean hasUpdate = false;

        public Server(NetworkController.Port port)
        {
            this.port = port;
            //this.tcpListener = new TcpListener(IPAddress.Any, this.port);
            this.listenThread = new Thread(new ThreadStart(Listen));
        }

        public void SetPort(NetworkController.Port port)
        {
            this.port = port;
        }

        public NetworkController.Port GetPort()
        {
            return this.port;
        }
        
        public void Start()
        {
            this.tcpListener = new TcpListener(IPAddress.Any, (int)this.port);
            this.listenThread.Start();
        }

        public Boolean GetHasUpdate()
        {
            return this.hasUpdate;
        }
        
        public byte[] GetData()
        {
            return this.readData;
        }

        public void ResetUpdate()
        {
            this.hasUpdate = false;
            this.readData = null;
        }
        
        private void Listen()
        {
            this.tcpListener.Start();
            while (true)
            {
                TcpClient client = this.tcpListener.AcceptTcpClient();
                this.HandleClientComm(client);
            }
        }

        public void Stop()
        {
            this.listenThread.Abort();
            this.listenThread.Join();
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
                if (!this.hasUpdate)
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
                        Console.WriteLine("Error in server, socket error");
                        break;
                    }

                    if (bytesRead == 0)
                    {
                        //the client has disconnected from the server
                        Console.WriteLine("In Server, client disconnected.");
                        break;
                    }

                    //message has successfully been received
                    //this.container.WriteData(message);

                    this.readData = message;
                    this.hasUpdate = true;
                    //clientStream.Flush();
                    //clientStream.Close();
                    break;
                }
            }
            tcpClient.Close();
        }
    }
}
