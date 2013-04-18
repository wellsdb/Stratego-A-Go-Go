using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

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
            Assert.AreEqual(Server.DEFAULT_PORT, target.getPort());
        }
        [Test()]
        public void TestThatServerRecievesMessage()
        {

        }
        [Test()]
        public void TestThatServerStarts()
        {

        }

        [Test()]
        public void TestThatServerStops()
        {

        }

    }
}
