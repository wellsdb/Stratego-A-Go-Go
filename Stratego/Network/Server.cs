using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public class Server : Networker
    {
        
        public Server()
        {
            currentPort = DEFAULT_PORT;
            isActive = false;
        }

        public Server(Port port)
        {
            currentPort = port;
            isActive = false;
        }

        override public void Start()
        {
            if (isActive)
                throw new Exception("You cannot start a Server that is already started!");
            isActive = true;
        }

        override public void Stop()
        {
            if (!isActive)
                throw new Exception("You cannot stop a Server that is already stopped!");
            isActive = false;
        }

    }
}
