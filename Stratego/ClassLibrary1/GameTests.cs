using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;
using Stratego;

namespace StrategoTesting
{
    [TestFixture()]
    class GameTests
    {

        private MockRepository mocks;

        [SetUp()]
        public void SetUp()
        {
            mocks = new MockRepository();
        }

        [Test()]
        public void TestThatGameInitializes()
        {
            Game target = new Game();
            Assert.IsNotNull(target);
        }

        [Test()]
        public void TestThatGameInitializesWithProperValues()
        {
            Game target = new Game();

            Assert.AreEqual(Player.DEFAULT_NAME, target.getPlayerName(1));
            Assert.AreEqual(Player.DEFAULT_NAME, target.getPlayerName(2));
            Assert.AreEqual(Player.DEFAULT_PIECECOUNT, target.getPlayerPieceCount(1));
            Assert.AreEqual(Player.DEFAULT_PIECECOUNT, target.getPlayerPieceCount(2));

            Assert.AreEqual(1, target.getTurnCount());
            Assert.AreEqual(1, target.getCurrentTurn());
        }

        [Test()]
        public void TestThatGameGetsBoardProperly()
        {
            Game targetDefault = new Game();
            Assert.IsInstanceOf<Board>(targetDefault.getBoard());

            Board testBoard = new Board();
            Game targetGiven = new Game(testBoard);
            Assert.AreSame(testBoard, targetGiven.getBoard());
        }

        [Test()]
        public void TestThatGameGetsAndSetsPlayerNamesProperly()
        {
            Game target = new Game();

            target.setPlayerName(1, "Warrior");
            target.setPlayerName(2, "Firion");

            Assert.AreEqual("Warrior", target.getPlayerName(1));
            Assert.AreEqual("Firion", target.getPlayerName(2));
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatPlayerNameThrowsOnBadPlayerNumber()
        {
            Game target = new Game();
            target.setPlayerName(-1, "Knight");
        }

        [Test()]
        public void TestThatGameGetsPlayerPieceCountProperly()
        {
            Game target = new Game();

            Assert.AreEqual(Player.DEFAULT_PIECECOUNT, target.getPlayerPieceCount(1));
            Assert.AreEqual(Player.DEFAULT_PIECECOUNT, target.getPlayerPieceCount(2));
        }

        [Test()]
        public void TestThatGameStartsCorrectly()
        {
        }

        [Test()]
        public void TestThatMovePieceFunctionsCorrectlyForSuccessfulMove()
        {
            mocks = new MockRepository();
            Board mockBoard = mocks.Stub<Board>();
            
            Game target = new Game(mockBoard);

            Int16 startVertOne = 3;
            Int16 startHorizOne = 3;
            Int16 startVertTwo = 4;
            Int16 startHorizTwo = 3;
            Int16 distanceOne = 1;
            Int16 distanceTwo = 2;
            Board.dir directionOne = Board.dir.N;
            Board.dir directionTwo = Board.dir.E;
            Int16 endVertOne = 4;
            Int16 endHorizOne = 3;
            Int16 endVertTwo = 4;
            Int16 endHorizTwo = 2;

            using (mocks.Record())
            {
                mockBoard.isMoveValid(startVertOne, startHorizOne, (int)directionOne, distanceOne);
                LastCall.Return(true);

                mockBoard.isMoveValid(startVertTwo, startHorizTwo, (int)directionTwo, distanceTwo);
                LastCall.Return(true);

                //mockBoard.movePiece(startVertOne, startHorizOne, (int)directionOne, distanceOne);
                //LastCall.Return( //Successful Move value

                //mockBoard.movePiece(startVertTwo, startHorizTwo, (int)directionTwo, distanceTwo);
                //LastCall.Return( //Successful Move value

                //mockBoard.getSpace(startVertOne, startHorizOne);
                //LastCall.Return( //empty, no piece

                //mockBoard.getSpace(endVertOne, endHorizOne);
                //LastCall.Return( //piece

                //mockBoard.getSpace(startVertTwo, startHorizTwo);
                //LastCall.Return( //empty, no piece

                //mockBoard.getSpace(endVertTwo, endHorizTwo);
                //LastCall.Return( //piece
                
            }

            target.movePiece(1, startVertOne, startHorizOne, directionOne, distanceOne);

            target.movePiece(2, startVertTwo, endHorizTwo, directionTwo, distanceTwo);

        }

        [Test()]
        public void TestThatMovePieceFunctionsCorrectlyForBattleVictory()
        {
            mocks = new MockRepository();
            Board mockBoard = mocks.Stub<Board>();

            Game target = new Game(mockBoard);

            Int16 startVertOne = 1;
            Int16 startHorizOne = 8;
            Int16 startVertTwo = 8;
            Int16 startHorizTwo = 1;
            Int16 distanceOne = 1;
            Int16 distanceTwo = 2;
            Board.dir directionOne = Board.dir.S;
            Board.dir directionTwo = Board.dir.W;
            Int16 endVertOne = 0;
            Int16 endHorizOne = 8;
            Int16 endVertTwo = 8;
            Int16 endHorizTwo = 4;

            using (mocks.Record())
            {
                mockBoard.isMoveValid(startVertOne, startHorizOne, (int)directionOne, distanceOne);
                LastCall.Return(true);

                mockBoard.isMoveValid(startVertTwo, startHorizTwo, (int)directionTwo, distanceTwo);
                LastCall.Return(true);

                //mockBoard.movePiece(startVertOne, startHorizOne, (int)directionOne, distanceOne);
                //LastCall.Return( //Battle victory value

                //mockBoard.movePiece(startVertTwo, startHorizTwo, (int)directionTwo, distanceTwo);
                //LastCall.Return( //Battle victory  value

                //mockBoard.getSpace(startVertOne, startHorizOne);
                //LastCall.Return( //empty, no piece

                //mockBoard.getSpace(endVertOne, endHorizOne);
                //LastCall.Return( //piece

                //mockBoard.getSpace(startVertTwo, startHorizTwo);
                //LastCall.Return( //empty, no piece

                //mockBoard.getSpace(endVertTwo, endHorizTwo);
                //LastCall.Return( //piece

            }

            target.movePiece(1, startVertOne, startHorizOne, directionOne, distanceOne);
            Assert.AreEqual(Player.DEFAULT_PIECECOUNT, target.getPlayerPieceCount(1));
            Assert.AreEqual(Player.DEFAULT_PIECECOUNT - 1, target.getPlayerPieceCount(2));

            target.movePiece(2, startVertTwo, endHorizTwo, directionTwo, distanceTwo);
            Assert.AreEqual(Player.DEFAULT_PIECECOUNT, target.getPlayerPieceCount(2));
            Assert.AreEqual(Player.DEFAULT_PIECECOUNT - 1, target.getPlayerPieceCount(1));

        }

        [Test()]
        public void TestThatMovePieceFunctionsCorrectlyForBattleLoss()
        {
            mocks = new MockRepository();
            Board mockBoard = mocks.Stub<Board>();

            Game target = new Game(mockBoard);

            Int16 startVertOne = 1;
            Int16 startHorizOne = 8;
            Int16 startVertTwo = 8;
            Int16 startHorizTwo = 1;
            Int16 distanceOne = 1;
            Int16 distanceTwo = 2;
            Board.dir directionOne = Board.dir.S;
            Board.dir directionTwo = Board.dir.W;
            Int16 endVertOne = 0;
            Int16 endHorizOne = 8;
            Int16 endVertTwo = 8;
            Int16 endHorizTwo = 4;

            using (mocks.Record())
            {
                mockBoard.isMoveValid(startVertOne, startHorizOne, (int)directionOne, distanceOne);
                LastCall.Return(true);

                mockBoard.isMoveValid(startVertTwo, startHorizTwo, (int)directionTwo, distanceTwo);
                LastCall.Return(true);

                //mockBoard.movePiece(startVertOne, startHorizOne, (int)directionOne, distanceOne);
                //LastCall.Return( //Battle defeat value

                //mockBoard.movePiece(startVertTwo, startHorizTwo, (int)directionTwo, distanceTwo);
                //LastCall.Return( //Battle defeat  value

                //mockBoard.getSpace(startVertOne, startHorizOne);
                //LastCall.Return( //empty, no piece

                //mockBoard.getSpace(endVertOne, endHorizOne);
                //LastCall.Return( //piece

                //mockBoard.getSpace(startVertTwo, startHorizTwo);
                //LastCall.Return( //empty, no piece

                //mockBoard.getSpace(endVertTwo, endHorizTwo);
                //LastCall.Return( //piece

            }

            target.movePiece(1, startVertOne, startHorizOne, directionOne, distanceOne);
            Assert.AreEqual(Player.DEFAULT_PIECECOUNT, target.getPlayerPieceCount(2));
            Assert.AreEqual(Player.DEFAULT_PIECECOUNT - 1, target.getPlayerPieceCount(1));

            target.movePiece(2, startVertTwo, endHorizTwo, directionTwo, distanceTwo);
            Assert.AreEqual(Player.DEFAULT_PIECECOUNT, target.getPlayerPieceCount(1));
            Assert.AreEqual(Player.DEFAULT_PIECECOUNT - 1, target.getPlayerPieceCount(2));
        }

        [Test()]
        public void TestThatMovePieceFunctionsCorrectlyForFailedMove()
        {
            mocks = new MockRepository();
            Board mockBoard = mocks.Stub<Board>();

            Game target = new Game(mockBoard);

            Int16 startVertOne = 1;
            Int16 startHorizOne = 8;
            Int16 startVertTwo = 8;
            Int16 startHorizTwo = 1;
            Int16 distanceOne = 1;
            Int16 distanceTwo = 2;
            Board.dir directionOne = Board.dir.S;
            Board.dir directionTwo = Board.dir.W;
            Int16 endVertOne = 0;
            Int16 endHorizOne = 8;
            Int16 endVertTwo = 8;
            Int16 endHorizTwo = 4;

            using (mocks.Record())
            {
                mockBoard.isMoveValid(startVertOne, startHorizOne, (int)directionOne, distanceOne);
                LastCall.Return(true);

                mockBoard.isMoveValid(startVertTwo, startHorizTwo, (int)directionTwo, distanceTwo);
                LastCall.Return(true);

                //mockBoard.movePiece(startVertOne, startHorizOne, (int)directionOne, distanceOne);
                //LastCall.Return( //Battle victory value

                //mockBoard.movePiece(startVertTwo, startHorizTwo, (int)directionTwo, distanceTwo);
                //LastCall.Return( //Battle victory  value

                //mockBoard.getSpace(startVertOne, startHorizOne);
                //LastCall.Return( //empty, no piece

                //mockBoard.getSpace(endVertOne, endHorizOne);
                //LastCall.Return( //piece

                //mockBoard.getSpace(startVertTwo, startHorizTwo);
                //LastCall.Return( //empty, no piece

                //mockBoard.getSpace(endVertTwo, endHorizTwo);
                //LastCall.Return( //piece

            }

            target.movePiece(1, startVertOne, startHorizOne, directionOne, distanceOne);
            Assert.AreEqual(Player.DEFAULT_PIECECOUNT, target.getPlayerPieceCount(1));
            Assert.AreEqual(Player.DEFAULT_PIECECOUNT - 1, target.getPlayerPieceCount(2));

            target.movePiece(2, startVertTwo, endHorizTwo, directionTwo, distanceTwo);
            Assert.AreEqual(Player.DEFAULT_PIECECOUNT, target.getPlayerPieceCount(2));
            Assert.AreEqual(Player.DEFAULT_PIECECOUNT - 1, target.getPlayerPieceCount(1));
        }

        [Test()]
        public void TestThatMovePieceFunctionsCorrectlyForFlagCapture()
        {

            mocks = new MockRepository();
            Board mockBoardOne = mocks.Stub<Board>();
            Board mockBoardTwo = mocks.Stub<Board>();

            Game targetOne = new Game(mockBoardOne);
            Game targetTwo = new Game(mockBoardTwo);

            Int16 startVertOne = 1;
            Int16 startHorizOne = 8;
            Int16 startVertTwo = 8;
            Int16 startHorizTwo = 1;
            Int16 distanceOne = 1;
            Int16 distanceTwo = 2;
            Board.dir directionOne = Board.dir.S;
            Board.dir directionTwo = Board.dir.W;
            Int16 endVertOne = 0;
            Int16 endHorizOne = 8;
            Int16 endVertTwo = 8;
            Int16 endHorizTwo = 4;

            using (mocks.Record())
            {
                mockBoardOne.isMoveValid(startVertOne, startHorizOne, (int)directionOne, distanceOne);
                LastCall.Return(true);

                mockBoardTwo.isMoveValid(startVertTwo, startHorizTwo, (int)directionTwo, distanceTwo);
                LastCall.Return(true);

                //mockBoardOne.movePiece(startVertOne, startHorizOne, (int)directionOne, distanceOne);
                //LastCall.Return( //flag capture value

                //mockBoardTwo.movePiece(startVertTwo, startHorizTwo, (int)directionTwo, distanceTwo);
                //LastCall.Return( //flag capture value

                //mockBoardOne.getSpace(startVertOne, startHorizOne);
                //LastCall.Return( //empty, no piece

                //mockBoardOne.getSpace(endVertOne, endHorizOne);
                //LastCall.Return( //piece

                //mockBoardTwo.getSpace(startVertTwo, startHorizTwo);
                //LastCall.Return( //empty, no piece

                //mockBoardTwo.getSpace(endVertTwo, endHorizTwo);
                //LastCall.Return( //piece

            }

            targetOne.movePiece(1, startVertOne, startHorizOne, directionOne, distanceOne);
            Assert.AreEqual(Player.DEFAULT_PIECECOUNT, targetOne.getPlayerPieceCount(1));
            Assert.AreEqual(Player.DEFAULT_PIECECOUNT - 1, targetOne.getPlayerPieceCount(2));

            targetTwo.movePiece(2, startVertTwo, endHorizTwo, directionTwo, distanceTwo);
            Assert.AreEqual(Player.DEFAULT_PIECECOUNT, targetTwo.getPlayerPieceCount(2));
            Assert.AreEqual(Player.DEFAULT_PIECECOUNT - 1, targetTwo.getPlayerPieceCount(1));

        }

        [Test()]
        public void TestThatSwapTurnFunctionsCorrectly()
        {
            mocks = new MockRepository();
            Board mockBoard = mocks.Stub<Board>();

            Game target = new Game(mockBoard);

            Int16 startVertOne = 3;
            Int16 startHorizOne = 3;
            Int16 startVertTwo = 4;
            Int16 startHorizTwo = 3;
            Int16 distanceOne = 1;
            Int16 distanceTwo = 2;
            Board.dir directionOne = Board.dir.N;
            Board.dir directionTwo = Board.dir.E;
            Int16 endVertOne = 4;
            Int16 endHorizOne = 3;
            Int16 endVertTwo = 4;
            Int16 endHorizTwo = 2;

            using (mocks.Record())
            {
                mockBoard.isMoveValid(startVertOne, startHorizOne, (int)directionOne, distanceOne);
                LastCall.Return(true);

                mockBoard.isMoveValid(startVertTwo, startHorizTwo, (int)directionTwo, distanceTwo);
                LastCall.Return(true);

                //mockBoard.movePiece(startVertOne, startHorizOne, (int)directionOne, distanceOne);
                //LastCall.Return( //Successful Move value

                //mockBoard.movePiece(startVertTwo, startHorizTwo, (int)directionTwo, distanceTwo);
                //LastCall.Return( //Successful Move value

                //mockBoard.getSpace(startVertOne, startHorizOne);
                //LastCall.Return( //empty, no piece

                //mockBoard.getSpace(endVertOne, endHorizOne);
                //LastCall.Return( //piece

                //mockBoard.getSpace(startVertTwo, startHorizTwo);
                //LastCall.Return( //empty, no piece

                //mockBoard.getSpace(endVertTwo, endHorizTwo);
                //LastCall.Return( //piece

            }

            target.startGame();
            Assert.AreEqual(1, target.getCurrentTurn());
            Assert.AreEqual(1, target.getTurnCount());

            target.movePiece(1, startVertOne, startHorizOne, directionOne, distanceOne);
            Assert.AreEqual(2, target.getCurrentTurn());
            Assert.AreEqual(1, target.getTurnCount());

            target.movePiece(2, startVertTwo, endHorizTwo, directionTwo, distanceTwo);
            Assert.AreEqual(1, target.getCurrentTurn());
            Assert.AreEqual(1, target.getTurnCount());
        }


    }
}
