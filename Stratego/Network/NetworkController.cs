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
        private IPAddress ip;
        private Server server;
        //private Byte[] data;
        public readonly static String LOCALHOST_IP = "127.0.0.1";

        public NetworkController()
        {
            this.sendPort = Port.Zero;
            this.ip = IPAddress.Parse("127.0.0.1");
            this.server = new Server(Port.One);
        }

        public NetworkController(Port sendPort, Port recievePort, String ip)
        {
            this.sendPort = sendPort;
            this.ip = IPAddress.Parse(ip);
            this.server = new Server(recievePort);
        }

        public Boolean HasUpdate()
        {
            return this.server.GetHasUpdate();
        }

        public Byte[] GetData()
        {
            return this.server.GetData();
        }

        public void ResetUpdate()
        {
            this.server.ResetUpdate();
        }

        public Boolean SendString(String message)
        {
            //Console.WriteLine("Sending " + message);

            //encode string
            Byte[] encoded =  NetworkConverter.StringToByte(message);
            
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

        public void StartServer()
        {
            //create server
            //this.server = new Server((int)recievePort);
            this.server.Start();
        }

        private Byte[] GetDataFromContainer(ByteContainer cont)
        {
            return cont.ReadData();
        }

        public String RecieveString()
        {
            Byte[] data = server.GetData();

            // error
            if (data == null)
                return null;

            //success
            Console.WriteLine("Recieving " + NetworkConverter.ByteToString(data));
            return NetworkConverter.ByteToString(data);
        
            //  timeout
            return null;
        }

        public void SetSendPort(Port port)
        {
            this.sendPort = port;
        }

        public void SetRecievePort(Port port)
        {
            this.server.SetPort(port);
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
            return this.server.GetPort();
        }

        public String GetIPAddress()
        {
            return this.ip.ToString();
        }

    }
}
