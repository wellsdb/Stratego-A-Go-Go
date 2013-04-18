using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Network;
using Stratego;

namespace Testing
{
    [TestFixture()]
    class GameSenderTests
    {
        [Test()]
        public void TestThatGameSenderInitializesProperly()
        {
            GameSender target = new GameSender();
            Assert.NotNull(target);
            Assert.IsInstanceOf<Client>(target.GetClient());
        }

        [Test()]
        public void TestThatGameSenderEncodesGameProperly()
        {
            GameSender target = new GameSender();
            Board testBoard = new Board();

            //TODO finish this test
            var coded = GameSender.Encode(testBoard);
            var expected = null;

            Assert.AreEqual(expected, coded);

        }

        [Test()]
        public void TestThatGameSenderStartsAClient()
        {

        }

        [Test()]
        public void TestThatSendingPortsCanBeChanged()
        {

        }
    }
}
