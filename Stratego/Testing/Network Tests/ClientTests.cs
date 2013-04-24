using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Network;
using System.Net;
using System.Threading;

namespace Testing
{
    [TestFixture()]
    class ClientTests
    {

        private IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), (int)NetworkController.Port.One);

        [Test()]
        public void TestThatClientInitializesProperly()
        {
            Client target = new Client(ip);
            Assert.IsNotNull(target);
            Assert.IsInstanceOf<Client>(target);
        }

        [Test()]
        public void TestClientSendsSuccessfully()
        {
            //create test client
            Client target = new Client(new IPEndPoint(IPAddress.Parse("127.0.0.1"), (int)NetworkController.Port.One));
            
            //create dummy server
            ByteContainer cont = new ByteContainer();
            Server testServer = new Server(NetworkController.Port.One, cont);
            testServer.Start();

            //send message one
            byte[] testByte = new byte[4096];
            testByte[0] = 9;
            testByte[1] = 8;
            testByte[2] = 7;
            testByte[3] = 6;
            bool success = target.Send(testByte);

            //assert sent
            Assert.True(success);
            //assert recieved
            Assert.AreEqual(testByte, cont.ReadData());

            //send message 2
            byte[] testByte2 = new byte[4096];
            for (int i = 0; i<256; i++)
            {
                testByte2[i] = (byte) i;
            }
            target.Send(testByte2);

            //assert recieved
            Assert.AreEqual(testByte2, cont.ReadData());
            testServer.Stop();
        }

        [Test()]
        public void TestThatClientSendsFail()
        {

        }
    }
}
