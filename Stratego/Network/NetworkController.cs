using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;
using System.Threading;

namespace Network
{
    public class NetworkController
    {
        public enum Port { Zero = 3000, One, Two, Three, Four };
        private Port sendPort;
        private Port recievePort;
        private IPAddress ip;
        private Server server;
        private ByteContainer cont;
        private Byte[] data;

        public NetworkController(Port sendPort, Port recievePort, String ip)
        {
            this.sendPort = sendPort;
            this.recievePort = recievePort;
            this.ip = IPAddress.Parse(ip);
        }

        public Boolean SendString(String message)
        {
            //encode string
            Byte[] encoded = new Converter().StringToByte(message);
            
            //create client
            Client client = new Client(new IPEndPoint(ip, (int)sendPort));

            //wait for client to send
            Boolean sent = client.Send(encoded);

            //  success
            if (sent)
                return true;

            //  fail
            if (!sent)
                return false;

            //  timeout
            
            return false;
        }

        private void StartServer()
        {
            this.server.Start();
        }

        private void StartServer(Server server)
        {
            server.Start();
        }

        private void GetDataFromContainer()
        {
            this.data =  this.cont.ReadData();
        }

        private Byte[] GetDataFromContainer(ByteContainer cont)
        {
            return cont.ReadData();
        }

        public String RecieveString()
        {
            ByteContainer cont = new ByteContainer();
            //create server
           this.server = new Server(recievePort, cont);

            Thread serverThread = new Thread(new ThreadStart(StartServer));
            //Thread readThread = new Thread(new ThreadStart(GetDataFromContainer));

            serverThread.Start();

            while (!serverThread.IsAlive);

            Thread.Sleep(5000);

            serverThread.Abort();
            serverThread.Join();

            Byte[] data = cont.ReadData();

            //try
            //{
            //    serverThread.Start();
            //    readThread.Start();
            //}
            //catch (ThreadStateException e)
            //{
            //    Console.WriteLine(e);  // Display text of exception
            //}
            //catch (ThreadInterruptedException e)
            //{
            //    Console.WriteLine(e);  // This exception means that the thread
            //    // was interrupted during a Wait
            //}

            //server.Stop();
            // error
            if (data == null)
                return null;

            //success
            return new Converter().ByteToString(data);

            //  timeout

            return null;
        }

        public void SetSendPort(Port port)
        {
            this.sendPort = port;
        }

        public void SetRecievePort(Port port)
        {
            this.recievePort = port;
        }

        public void SetIP(String ip)
        {
            this.ip = IPAddress.Parse(ip);
        }

        public Port GetSendPort()
        {
            return this.sendPort;
        }

        public Port GetRecievePort()
        {
            return this.recievePort;
        }

        public String GetIPAddress()
        {
            return this.ip.ToString();
        }

    }
}
