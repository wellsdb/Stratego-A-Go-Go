using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Network;

namespace Testing
{
    [TestFixture()]
    class ClientTests
    {
        [Test()]
        public void TestThatClientInitializesProperly()
        {
            Client target = new Client();
            Assert.IsNotNull(target);
            Assert.IsInstanceOf<Client>(target);
            Assert.AreEqual(Client.DEFAULT_PORT, target.getPort());
        }

        [Test()]
        public void TestThatClientChangesPortProperly()
        {
            Client target = new Client();

            target.setPort(Client.Ports.PortOne);
            Assert.AreEqual(Client.Ports.PortOne, target.getPort());
            target.setPort(Client.Ports.PortTwo);
            Assert.AreEqual(Client.Ports.PortTwo, target.getPort());
            target.setPort(Client.Ports.PortThree);
            Assert.AreEqual(Client.Ports.PortThree, target.getPort());
            target.setPort(Client.Ports.PortFour);
            Assert.AreEqual(Client.Ports.PortFour, target.getPort());
        }

        [Test()]
        public void TestThatClientStarts()
        {
            Client target = new Client();
            Assert.False(target.IsActive());
            target.start();
            Assert.True(target.IsActive());
        }

        [Test()]
        public void TestThatClientStops()
        {
            Client target = new Client();
            Assert.False(target.IsActive());
            target.start();
            Assert.True(target.IsActive());
            target.stop();
            Assert.False(target.IsActive());
        }

        [Test()]
        public void TestThatClientSendsMessage()
        {
            Client target = new Client();
            String msg = "Test";
            target.send(msg);
            Assert.True(target.HasSent());
        }
    }
}
