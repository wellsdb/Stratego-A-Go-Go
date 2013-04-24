using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Network
{
    public class ByteContainer
    {

        private Byte[] contents;
        private Boolean readerFlag = false;

        public ByteContainer()
        { }

        public void WriteData(Byte[] data)
        {
            lock (this)
            {
                if (readerFlag)
                { 
                    try
                    {
                        Monitor.Wait(this); 
                    }
                    catch (SynchronizationLockException e)
                    {
                        Console.WriteLine(e);
                    }
                    catch (ThreadInterruptedException e)
                    {
                        Console.WriteLine(e);
                    }
                }
                this.contents = data;
                readerFlag = true; 
                Monitor.Pulse(this);
            }
        }

        public Byte[] ReadData()
        {
            lock (this)
            {
                if (!this.readerFlag)
                {
                    try
                    {
                        Monitor.Wait(this);
                    }
                    catch (SynchronizationLockException e)
                    {
                        Console.WriteLine(e);
                    }
                    catch (ThreadInterruptedException e)
                    {
                        Console.WriteLine(e);
                    }
                }
                readerFlag = false;
                Monitor.Pulse(this);
            }
            return this.contents;
        }
    }
}
