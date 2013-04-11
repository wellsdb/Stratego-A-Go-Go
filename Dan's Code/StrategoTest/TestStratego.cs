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
    //This tests the board and basic mouse event handler. It requires a slight amount of user input, so here are the instructions:
    //  1) Close the first window immediately, clicking nowhere on the board.
    //  2) In the second window, click the square in the 2, 2 position (from top left). Then close the window.
    //  If you wish to mash the keyboard or click around the board but still in the window, feel free. It should not change anything.
    //  Everything should pass then.
    public class TestFixture1
    {
        [Test]
        //Tests the board class. Since it just initializes for now this is the only one.
        public void TestBoardInitializes()
        {
            //Initialize the board.
            Board testgame = new Board();

            //Run through every square.
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if ((i == 2 | i == 3 | i == 6 | i == 7) & (j == 4 | j == 5))
                    {
                        //Tests for lakes.
                        Assert.AreEqual(testgame.board[i, j], 20);
                    }
                    else
                    {
                        //Tests for empty squares.
                        Assert.AreEqual(testgame.board[i, j], 0);
                    }
                }
            }

            //Test that board has correct number of squares.
            Assert.AreEqual(testgame.board.Length, 100);
        }

        [Test]
        //Tests the event handler (just mouse clicks for now).
        public void TestThatClickChangesArray()
        {
            //Initialize everything, including an extra board to make sure nothing else changes.
            Board testgame = new Board();
            Board compare = new Board();
            Stratego.View testview = new Stratego.View(testgame);

            //Run the view. Click the square in the 2,2 position. Couldn't figure out how to simulate mouse clicks but this works.
            //Then close the window.
            Application.Run(testview);


            //Now that the array has been changed, test to make sure that everything that should have happened on the back end did.
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == 1 & j == 1)
                    {
                        //10 is the value that is placed when the square is clicked. It should only be this one.
                        Assert.AreEqual(10, testgame.board[1, 1]);
                    }
                    else
                    {
                        //Tests that none of the other squares were modified by comparing them to a default board.
                        Assert.AreEqual(compare.board[i, j], testgame.board[i, j]);
                    }
                }
            }
        }

        [Test]
        //Tests that nothing changes if nothing is clicked.
        public void TestThatArrayRemainsUnchangedIfNoInput()
        {
            //Initialize everything, including an extra board for reference.
            Board testgame = new Board();
            Board compare = new Board();
            Stratego.View testview = new Stratego.View(testgame);

            //Run the view. Immediately close the window.
            Application.Run(testview);


            //Now that the array has been changed, test to make sure that happened on the back end.
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    //Tests that none of the squares were modified by comparing them to a default board.
                    Assert.AreEqual(compare.board[i, j], testgame.board[i, j]);
                }
            }
        }



    }
}
