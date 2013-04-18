using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public class Client : Networker
    {
        public Client()
        {
            currentPort = DEFAULT_PORT;
            isActive = false;
        }

        public Client(Port port)
        {
            currentPort = port;
            isActive = false;
        }

        override public void Start()
        {
            if (isActive)
                throw new Exception("You cannot start a client that is already started!");
            isActive = true;
        }

        override public void Stop()
        {
            if (!isActive)
                throw new Exception("You cannot stop a client that is already stopped!");
            isActive = false;
        }

        public bool Send(String msg)
        {
            //send the message
            return false;
        }

    }
}
