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
    class NetworkControllerTests
    {
        private NetworkController.Port p1 = NetworkController.Port.One;
        private NetworkController.Port p2 = NetworkController.Port.Two;
        private NetworkController.Port p3 = NetworkController.Port.Three;
        private NetworkController.Port p4 = NetworkController.Port.Four;

        private String ip1 = "127.0.0.1";
        private String ip2 = "128.1.1.0";
        private String ip3 = "721.5.5.9";

        [SetUp()]
        public void SetUp()
        {
            
        }

        [Test()]
        public void TestThatNetworkInitializesCorrectly()
        {
            NetworkController target1 = new NetworkController(p1, p2, ip1);
            NetworkController target2 = new NetworkController(p3, p4, ip2);

            Assert.NotNull(target1);
            Assert.NotNull(target2);

            Assert.AreEqual(p1, target1.GetSendPort());
            Assert.AreEqual(p2, target1.GetRecievePort());
            Assert.AreEqual(ip1, target1.GetIPAddress());
            Assert.AreEqual(p3, target2.GetSendPort());
            Assert.AreEqual(p4, target2.GetRecievePort());
            Assert.AreEqual(ip2, target2.GetIPAddress());

        }
        [Test()]
        public void TestThatNetworkControllerGetsAndSetsIPAddress()
        {
            NetworkController target = new NetworkController(p1, p2, ip1);
            
            Assert.AreEqual(ip1, target.GetIPAddress());

            target.SetIP(ip2);

            Assert.AreEqual(ip2, target.GetIPAddress());
        }

        [Test()]
        public void TestThatNetworkControllerGetsAndSetsSendPort()
        {
            NetworkController target = new NetworkController(p1, p2, ip1);

            Assert.AreEqual(p1, target.GetSendPort());

            target.SetSendPort(p3);

            Assert.AreEqual(p3, target.GetSendPort());
        }

        [Test()]
        public void TestThatNetworkControllerGetsAndSetsRecievePort()
        {
            NetworkController target = new NetworkController(p2, p3, ip1);

            Assert.AreEqual(p3, target.GetRecievePort());

            target.SetRecievePort(p4);

            Assert.AreEqual(p4, target.GetRecievePort());
        }

        [Test()]
        public void TestSendStringForFail()
        {
            NetworkController target = new NetworkController(p1, p2, ip1);

            Boolean success = target.SendString("testString");

            Assert.False(success);
            
        }

        [Test()]
        public void TestSendStringForTimeout()
        {
            Assert.Fail();
        }

        [Test()]
        public void TestSendStringForSuccess()
        {
            NetworkController target = new NetworkController(p1, p2, ip1);

            //create dummy server
            ByteContainer cont = new ByteContainer();
            Server testServer = new Server(NetworkController.Port.One, cont);
            testServer.Start();

            Boolean success = target.SendString("testString");

            Assert.True(success);

        }

        [Test()]
        public void TestRecieveStringForFail()
        {
            NetworkController target = new NetworkController(p1, p2, ip1);

            String recieved = target.RecieveString();

            Assert.AreEqual("-1", recieved);

        }

        [Test()]
        public void TestReceiveStringForTimeout()
        {
            Assert.Fail();

        }

        [Test()]
        public void TestReceiveStringForSucess()
        {
            NetworkController target = new NetworkController(p1, p2, ip1);
            Client dummyClient = new Client(new IPEndPoint(IPAddress.Parse("127.0.0.1"), (int)NetworkController.Port.Two));

            String testString = "testStringForRecieveSuccess";

            String result = target.RecieveString();
            dummyClient.Send(new ASCIIEncoding().GetBytes(testString));

            Assert.AreEqual(testString, result);


        }
    }
}
