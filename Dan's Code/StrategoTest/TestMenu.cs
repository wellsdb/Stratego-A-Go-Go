using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Stratego;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NUnitTest1
{
    [TestFixture]
    class TestMenu
    {
        [Test]
        public void TestMenuButton2PHotseat()
        //Tests that pressing the button creates a new game and displays an empty board.
        //Since functionality isn't implemented yet I'll just have it draw a default board
        //that you can click on and change the color a bit.
        {
            Board testgame = new Board();
            Stratego.View testview = new Stratego.View(testgame);
            Application.Run(testview);

            //So this time you just click the hotseat button then do whatever you want and
            //close the window after you do it.

            Assert.AreEqual(testview.mode, 2);
        }

        [Test]
        public void TestMenuButtonTuitorial()
        //Tests that the tuitorial menu is shown when you push the tuitorial button.
        {
            Board testgame = new Board();
            Stratego.View testview = new Stratego.View(testgame);
            Application.Run(testview);

            //So this time you just click the tuitorial button then do whatever you want and
            //close the window after you do it.

            Assert.AreEqual(testview.mode, 3);
        }

        [Test]
        public void TestMenuButtonExit()
        //Tests that the window closes when you push the exit button.
        {
            Board testgame = new Board();
            Stratego.View testview = new Stratego.View(testgame);
            Application.Run(testview);

            //So this time you just click the exit button.

            Assert.AreEqual(testview.mode, 9);
        }

        [Test]
        public void TestBackToMenuButton()
        {
            Board testgame = new Board();
            Stratego.View testview = new Stratego.View(testgame);
            Application.Run(testview);

            //So this time you just click the hotseat button then the back to menu button.
            //You can also press the tuitorial button and back to menu button. You can do it
            //as often as you want in any combination.

            Assert.AreEqual(testview.mode, 0);
        }
    }
}
