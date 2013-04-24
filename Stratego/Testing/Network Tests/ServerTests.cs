using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Network;
using System.Net;

namespace Testing
{
    [TestFixture()]
    class ServerTests
    {
        private NetworkController.Port port = NetworkController.Port.One;
        private ByteContainer cont = new ByteContainer();

        [SetUp()]
        public void SetUp()
        {
            cont = new ByteContainer();
        }

        [Test()]
        public void TestThatServerInitializesProperly()
        {
            Server target = new Server(port, cont);
            Assert.IsNotNull(target);
            Assert.IsInstanceOf<Server>(target);
        }

        [Test()]
        public void TestThatServerStarts()
        {
            Server target = new Server(port, cont);
            Assert.False(target.IsActive());
            target.Start();
            Assert.True(target.IsActive());
        }

        [Test()]
        public void TestThatServerStops()
        {
            Server target = new Server(port, cont);
            Assert.False(target.IsActive());
            target.Start();
            Assert.True(target.IsActive());
            target.Stop();
            Assert.False(target.IsActive());
        }


        [Test()]
        public void TestThatServerRecievesMessage()
        {
            //set up server
            Server target = new Server(port, cont);
            target.Start();

            //create client and send message
            Client dummyClient = new Client(new IPEndPoint(IPAddress.Parse("127.0.0.1"), (int)NetworkController.Port.One));
            byte[] testByte = new byte[4096];
            testByte[0] = 9;
            testByte[1] = 8;
            testByte[2] = 7;
            testByte[3] = 6;
            bool success = dummyClient.Send(testByte);

            //assert sent
            Assert.True(success);
            //assert recieved
            Assert.AreEqual(testByte, cont.ReadData());

            //send message 2
            byte[] testByte2 = new byte[4096];
            for (int i = 0; i < 256; i++)
            {
                testByte2[i] = (byte)i;
            }
            dummyClient.Send(testByte2);

            //assert recieved
            Assert.AreEqual(testByte2, cont.ReadData());
            target.Stop();
        }

        
    }
}
