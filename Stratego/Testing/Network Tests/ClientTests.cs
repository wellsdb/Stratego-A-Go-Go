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
            Assert.AreEqual(Client.DEFAULT_PORT, target.GetPort());
        }

        [Test()]
        public void TestThatClientChangesPortProperly()
        {
            Client target = new Client();

            target.SetPort(Client.Port.One);
            Assert.AreEqual(Client.Port.One, target.GetPort());
            target.SetPort(Client.Port.Two);
            Assert.AreEqual(Client.Port.Two, target.GetPort());
            target.SetPort(Client.Port.Three);
            Assert.AreEqual(Client.Port.Three, target.GetPort());
            target.SetPort(Client.Port.Four);
            Assert.AreEqual(Client.Port.Four, target.GetPort());
        }

        [Test()]
        public void TestThatClientStarts()
        {
            Client target = new Client();
            Assert.False(target.IsActive());
            target.Start();
            Assert.True(target.IsActive());
        }

        [Test()]
        public void TestThatClientStops()
        {
            Client target = new Client();
            Assert.False(target.IsActive());
            target.Start();
            Assert.True(target.IsActive());
            target.Stop();
            Assert.False(target.IsActive());
        }

        [Test()]
        public void TestThatClientSendsMessage()
        {
            Client target = new Client();
            String msg = "Test";
            bool result = target.Send(msg);
            Assert.True(result);
        }
    }
}
