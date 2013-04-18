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
    class ServerTests
    {
        [Test()]
        public void TestThatServerInitializesProperly()
        {
            Server target = new Server();
            Assert.IsNotNull(target);
            Assert.IsInstanceOf<Server>(target);
            Assert.AreEqual(Server.DEFAULT_PORT, target.GetPort());
        }

        [Test()]
        public void TestThatServerChangesPortProperly()
        {
            Server target = new Server();

            target.SetPort(Server.Port.One);
            Assert.AreEqual(Server.Port.One, target.GetPort());
            target.SetPort(Server.Port.Two);
            Assert.AreEqual(Server.Port.Two, target.GetPort());
            target.SetPort(Server.Port.Three);
            Assert.AreEqual(Server.Port.Three, target.GetPort());
            target.SetPort(Server.Port.Four);
            Assert.AreEqual(Server.Port.Four, target.GetPort());
        }

        [Test()]
        public void TestThatServerStarts()
        {
            Server target = new Server();
            Assert.False(target.IsActive());
            target.Start();
            Assert.True(target.IsActive());
        }

        [Test()]
        public void TestThatServerStops()
        {
            Server target = new Server();
            Assert.False(target.IsActive());
            target.Start();
            Assert.True(target.IsActive());
            target.Stop();
            Assert.False(target.IsActive());
        }


        [Test()]
        public void TestThatServerRecievesMessage()
        {
            Assert.Fail();
        }

    }
}
