using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;

namespace Network
{
    public class NetworkController
    {
        public enum Port { Zero = 3000, One, Two, Three, Four };
        private Port sendPort;
        private Port recievePort;
        private IPAddress ip;

        public NetworkController(Port sendPort, Port recievePort, String ip)
        {
            this.sendPort = sendPort;
            this.recievePort = recievePort;
            this.ip = IPAddress.Parse(ip);
        }

        public Boolean SendString(String message)
        {
            //encode string
            
            //create client

            //wait for client to send

            //  success

            //  fail

            //  timeout
            
            return false;
        }

        public String RecieveString()
        {
            //create server

            //wait for server to recieve

            //  error

            //  timeout

            //  success

            //decode bytes

            //return string
            
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
