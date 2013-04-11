using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Stratego;

namespace StrategoTesting
{
    [TestFixture()]
    class PlayerTests
    {
        [Test()]
        public void TestThatPlayerInitializesWithProperValues()
        {

            Int16 countDefault = 40;
            //Int16 countHigh = 55;
            Int16 countLow = 13;

            String nameDefault = "Napoleon";
            String nameGuy = "Jonathan";
            String nameGirl = "Jane";

            Player targetNoArgs = new Player();
            Player targetOneArg = new Player(nameGuy);
            Player targetTwoArgs = new Player(countLow, nameGirl);

            Assert.AreEqual(countDefault, targetNoArgs.getPieceCount());
            Assert.AreEqual(nameDefault, targetNoArgs.getName());
            Assert.AreEqual(countDefault, targetOneArg.getPieceCount());
            Assert.AreEqual(nameGuy, targetOneArg.getName());
            Assert.AreEqual(countLow, targetTwoArgs.getPieceCount());
            Assert.AreEqual(nameGirl, targetTwoArgs.getName());
        }

        [Test()]
        public void TestThatNameSetsProperly()
        {
            Player target = new Player();

            String nameOne = "Azel";
            String nameTwo = "Ashley";
            String nameThree = "42724";

            target.setName(nameOne);
            Assert.AreEqual(nameOne, target.getName());
            target.setName(nameTwo);
            Assert.AreEqual(nameTwo, target.getName());
            target.setName(nameThree);
            Assert.AreEqual(nameThree, target.getName());
        }

        [Test()]
        public void TestThatPieceAddsAndRemovesProperly()
        {
            Player target = new Player();

            Int16 countDefault = 40;
            Int16 countLow = 20;
            Int16 countHigh = 60;

            Assert.AreEqual(countDefault, target.getPieceCount());

            for (Int16 x = 0; x < 20; x++)
                target.removePiece();
            Assert.AreEqual(countLow, target.getPieceCount());

            for (Int16 x = 0; x < 40; x++)
                target.addPiece();
            Assert.AreEqual(countHigh, target.getPieceCount());
        }
    }
}
