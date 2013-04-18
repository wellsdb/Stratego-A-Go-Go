using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public abstract class Networker
    {
        public enum Port { Zero = 3000, One, Two, Three, Four };
        public static readonly Port DEFAULT_PORT = Port.Zero;
        protected Port currentPort;
        protected bool isActive;

        public Port GetPort()
        {
            return this.currentPort;
        }

        public void SetPort(Port port)
        {
            currentPort = port;
        }

        public bool IsActive()
        {
            return isActive;
        }

        public abstract void Start();

        public abstract void Stop();
    }   
}
