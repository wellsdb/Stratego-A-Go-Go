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

            Assert.AreEqual(0, target.getTurnCount());
            Assert.AreEqual(Piece.Team.none, target.getCurrentTurn());
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
            Game target = new Game();

            target.startGame();

            Assert.AreEqual(1, target.getTurnCount());
            Assert.AreEqual(Piece.Team.red, target.getCurrentTurn());

        }

        [Test()]
        public void TestThatBoardIsMockedProperly()
        {
            //Board mockBoard = mocks.CreateMock<Board>();

            //Expect.Call( mockBoard.getSpace ).Return(new Piece());
            //mocks.ReplayAll();

            //Board mockBoard = mocks.Stub<Board>();
            
            //using (mocks.Record())
            //{
            //    mockBoard.isMoveValid(3, 3, Board.Direction.N, 1);
            //    LastCall.Return(true);
            //}
            
            //Expect.Call(mockBoard.isMoveValid(3, 3, Board.Direction.N, 1)).Return(true);
           // mocks.ReplayAll();

           // Game target = new Game(mockBoard);

           // Boolean[] hi = { true, false };
            //hi[1] = false;

           // Assert.IsTrue(target.movePiece(Piece.Team.red, 3, 3, Board.Direction.N, 1)[0]);

        }


        [Test()]
        public void TestThatMovePieceFunctionsCorrectlyForSuccessfulMove()
        {
            Board testBoard = new Board();
            Game target = new Game(testBoard);

            Int16 startVertOne = 3;
            Int16 startHorizOne = 2;
            Int16 startVertTwo = 6;
            Int16 startHorizTwo = 3;
            Int16 startVertThree = 3;
            Int16 startHorizThree = 7;
            Int16 startVertFour = 6;
            Int16 startHorizFour = 6;
            Int16 distanceOne = 1;
            Int16 distanceTwo = 2;
            Int16 distanceThree = 1;
            Int16 distanceFour = 1;
            Board.Direction directionOne = Board.Direction.W;
            Board.Direction directionTwo = Board.Direction.E;
            Board.Direction directionThree = Board.Direction.S;
            Board.Direction directionFour = Board.Direction.N;
            Int16 endVertOne = 3;
            Int16 endHorizOne = 1;
            Int16 endVertTwo = 6;
            Int16 endHorizTwo = 5;
            Int16 endVertThree = 2;
            Int16 endHorizThree = 7;
            Int16 endVertFour = 9;
            Int16 endHorizFour = 6;

            Piece pieceOne = new Piece(Piece.Team.red, Piece.Rank.marshal);
            Piece pieceTwo = new Piece(Piece.Team.blue, Piece.Rank.scout);
            Piece pieceThree = new Piece(Piece.Team.red, Piece.Rank.miner);
            Piece pieceFour = new Piece(Piece.Team.blue, Piece.Rank.spy);

            testBoard.placePiece(pieceOne, startVertOne, startHorizOne);
            testBoard.placePiece(pieceTwo, startVertTwo, startHorizTwo);
            testBoard.placePiece(pieceThree, startVertThree, startHorizThree);
            testBoard.placePiece(pieceFour, startVertFour, startHorizFour);

            target.startGame();

            Boolean[] moveOne = target.movePiece(startVertOne, startHorizOne, directionOne, distanceOne);
            Boolean[] moveTwo = target.movePiece(startVertTwo, startHorizTwo, directionTwo, distanceTwo);
            Boolean[] moveThree = target.movePiece(startVertThree, startHorizThree, directionThree, distanceThree);
            Boolean[] moveFour = target.movePiece(startVertFour, startHorizFour, directionFour, distanceFour);

            Assert.True(moveOne[0]);
            Assert.False(moveOne[1]);
            Assert.True(moveTwo[0]);
            Assert.False(moveTwo[1]);
            Assert.True(moveThree[0]);
            Assert.False(moveThree[1]);
            Assert.True(moveFour[0]);
            Assert.False(moveFour[1]);

            Assert.AreSame(pieceOne, target.getBoard().getPiece(endVertOne, endHorizOne));
            Assert.AreSame(pieceTwo, target.getBoard().getPiece(endVertTwo, endHorizTwo));
            Assert.AreSame(pieceThree, target.getBoard().getPiece(endVertThree, endHorizThree));
            Assert.AreSame(pieceFour, target.getBoard().getPiece(endVertFour, endHorizFour));
        }

        [Test()]
        public void TestThatMovePieceFunctionsCorrectlyForFailedMove()
        {
            Board testBoard = new Board();
            Game target = new Game(testBoard);

            Int16 startVertOne = 3;
            Int16 startHorizOne = 2;
            Int16 startVertTwo = 6;
            Int16 startHorizTwo = 3;
            Int16 startVertThree = 3;
            Int16 startHorizThree = 7;
            Int16 startVertFour = 6;
            Int16 startHorizFour = 6;
            Int16 distanceOne = 1;
            Int16 distanceTwo = 3;
            Int16 distanceThree = 8;
            Int16 distanceFour = 4;
            Board.Direction directionOne = Board.Direction.N;
            Board.Direction directionTwo = Board.Direction.E;
            Board.Direction directionThree = Board.Direction.W;
            Board.Direction directionFour = Board.Direction.S;

            Piece pieceOne = new Piece(Piece.Team.red, Piece.Rank.marshal);
            Piece pieceTwo = new Piece(Piece.Team.red, Piece.Rank.scout);
            Piece pieceThree = new Piece(Piece.Team.red, Piece.Rank.scout);
            Piece pieceFour = new Piece(Piece.Team.red, Piece.Rank.scout);

            testBoard.placePiece(pieceOne, startVertOne, startHorizOne);
            testBoard.placePiece(pieceTwo, startVertTwo, startHorizTwo);
            testBoard.placePiece(pieceThree, startVertThree, startHorizThree);
            testBoard.placePiece(pieceFour, startVertFour, startHorizFour);

            target.startGame();

            Boolean[] moveOne = target.movePiece(startVertOne, startHorizOne, directionOne, distanceOne);
            Boolean[] moveTwo = target.movePiece(startVertTwo, startHorizTwo, directionTwo, distanceTwo);
            Boolean[] moveThree = target.movePiece(startVertThree, startHorizThree, directionThree, distanceThree);
            Boolean[] moveFour = target.movePiece(startVertFour, startHorizFour, directionFour, distanceFour);

            Assert.False(moveOne[0]);
            Assert.False(moveTwo[0]);
            Assert.False(moveThree[0]);
            Assert.False(moveFour[0]);

            Assert.AreSame(pieceOne, target.getBoard().getPiece(startVertOne, startHorizOne));
            Assert.AreSame(pieceTwo, target.getBoard().getPiece(startVertTwo, startHorizTwo));
            Assert.AreSame(pieceThree, target.getBoard().getPiece(startVertThree, startHorizThree));
            Assert.AreSame(pieceFour, target.getBoard().getPiece(startVertFour, startHorizFour));

        }

        [Test()]
        public void TestThatMovePieceFunctionsCorrectlyForBattleVictory()
        {
            Board testBoard = new Board();
            Game target = new Game(testBoard);

            Int16 startVertOne = 3;
            Int16 startHorizOne = 2;
            Int16 startVertTwo = 6;
            Int16 startHorizTwo = 3;
            Int16 startVertThree = 3;
            Int16 startHorizThree = 7;
            Int16 startVertFour = 6;
            Int16 startHorizFour = 6;
            Int16 distanceOne = 1;
            Int16 distanceTwo = 1;
            Int16 distanceThree = 1;
            Int16 distanceFour = 1;
            Board.Direction directionOne = Board.Direction.W;
            Board.Direction directionTwo = Board.Direction.E;
            Board.Direction directionThree = Board.Direction.S;
            Board.Direction directionFour = Board.Direction.N;
            Int16 endVertOne = 3;
            Int16 endHorizOne = 1;
            Int16 endVertTwo = 6;
            Int16 endHorizTwo = 4;
            Int16 endVertThree = 2;
            Int16 endHorizThree = 7;
            Int16 endVertFour = 9;
            Int16 endHorizFour = 6;

            Piece pieceOne = new Piece(Piece.Team.red, Piece.Rank.scout);
            Piece pieceTwo = new Piece(Piece.Team.blue, Piece.Rank.miner);
            Piece pieceThree = new Piece(Piece.Team.red, Piece.Rank.spy);
            Piece pieceFour = new Piece(Piece.Team.blue, Piece.Rank.colonel);
            
            Piece pieceFive = new Piece(Piece.Team.blue, Piece.Rank.spy);
            Piece pieceSix = new Piece(Piece.Team.red, Piece.Rank.bomb);
            Piece pieceSeven = new Piece(Piece.Team.blue, Piece.Rank.marshal);
            Piece pieceEight = new Piece(Piece.Team.red, Piece.Rank.major);

            testBoard.placePiece(pieceOne, startVertOne, startHorizOne);
            testBoard.placePiece(pieceTwo, startVertTwo, startHorizTwo);
            testBoard.placePiece(pieceThree, startVertThree, startHorizThree);
            testBoard.placePiece(pieceFour, startVertFour, startHorizFour);

            testBoard.placePiece(pieceFive, endVertOne, endHorizOne);
            testBoard.placePiece(pieceSix, endVertTwo, endHorizTwo);
            testBoard.placePiece(pieceSeven, endVertThree, endHorizThree);
            testBoard.placePiece(pieceEight, endVertFour, endHorizFour);

            target.startGame();

            Boolean[] moveOne = target.movePiece(startVertOne, startHorizOne, directionOne, distanceOne);
            Boolean[] moveTwo = target.movePiece(startVertTwo, startHorizTwo, directionTwo, distanceTwo);
            Boolean[] moveThree = target.movePiece(startVertThree, startHorizThree, directionThree, distanceThree);
            Boolean[] moveFour = target.movePiece(startVertFour, startHorizFour, directionFour, distanceFour);

            Assert.True(moveOne[0]);
            Assert.False(moveOne[1]);
            Assert.True(moveTwo[0]);
            Assert.False(moveTwo[1]);
            Assert.True(moveThree[0]);
            Assert.False(moveThree[1]);
            Assert.True(moveFour[0]);
            Assert.False(moveFour[1]);

            Assert.AreSame(pieceOne, target.getBoard().getPiece(endVertOne, endHorizOne));
            Assert.AreSame(pieceTwo, target.getBoard().getPiece(endVertTwo, endHorizTwo));
            Assert.AreSame(pieceThree, target.getBoard().getPiece(endVertThree, endHorizThree));
            Assert.AreSame(pieceFour, target.getBoard().getPiece(endVertFour, endHorizFour));
        }


        [Test()]
        public void TestThatMovePieceFunctionsCorrectlyForBattleLoss()
        {
            Board testBoard = new Board();
            Game target = new Game(testBoard);

            Int16 startVertOne = 3;
            Int16 startHorizOne = 2;
            Int16 startVertTwo = 6;
            Int16 startHorizTwo = 3;
            Int16 startVertThree = 3;
            Int16 startHorizThree = 7;
            Int16 startVertFour = 6;
            Int16 startHorizFour = 6;
            Int16 distanceOne = 1;
            Int16 distanceTwo = 1;
            Int16 distanceThree = 1;
            Int16 distanceFour = 1;
            Board.Direction directionOne = Board.Direction.W;
            Board.Direction directionTwo = Board.Direction.E;
            Board.Direction directionThree = Board.Direction.S;
            Board.Direction directionFour = Board.Direction.N;
            Int16 endVertOne = 3;
            Int16 endHorizOne = 1;
            Int16 endVertTwo = 6;
            Int16 endHorizTwo = 4;
            Int16 endVertThree = 2;
            Int16 endHorizThree = 7;
            Int16 endVertFour = 9;
            Int16 endHorizFour = 6;

            Piece pieceOne = new Piece(Piece.Team.red, Piece.Rank.spy);
            Piece pieceTwo = new Piece(Piece.Team.blue, Piece.Rank.scout);
            Piece pieceThree = new Piece(Piece.Team.red, Piece.Rank.marshal);
            Piece pieceFour = new Piece(Piece.Team.blue, Piece.Rank.colonel);

            Piece pieceFive = new Piece(Piece.Team.blue, Piece.Rank.lieutenant);
            Piece pieceSix = new Piece(Piece.Team.red, Piece.Rank.bomb);
            Piece pieceSeven = new Piece(Piece.Team.blue, Piece.Rank.spy);
            Piece pieceEight = new Piece(Piece.Team.red, Piece.Rank.general);

            testBoard.placePiece(pieceOne, startVertOne, startHorizOne);
            testBoard.placePiece(pieceTwo, startVertTwo, startHorizTwo);
            testBoard.placePiece(pieceThree, startVertThree, startHorizThree);
            testBoard.placePiece(pieceFour, startVertFour, startHorizFour);

            testBoard.placePiece(pieceFive, endVertOne, endHorizOne);
            testBoard.placePiece(pieceSix, endVertTwo, endHorizTwo);
            testBoard.placePiece(pieceSeven, endVertThree, endHorizThree);
            testBoard.placePiece(pieceEight, endVertFour, endHorizFour);

            target.startGame();

            Boolean[] moveOne = target.movePiece(startVertOne, startHorizOne, directionOne, distanceOne);
            Boolean[] moveTwo = target.movePiece(startVertTwo, startHorizTwo, directionTwo, distanceTwo);
            Boolean[] moveThree = target.movePiece(startVertThree, startHorizThree, directionThree, distanceThree);
            Boolean[] moveFour = target.movePiece(startVertFour, startHorizFour, directionFour, distanceFour);

            Assert.True(moveOne[0]);
            Assert.False(moveOne[1]);
            Assert.True(moveTwo[0]);
            Assert.False(moveTwo[1]);
            Assert.True(moveThree[0]);
            Assert.False(moveThree[1]);
            Assert.True(moveFour[0]);
            Assert.False(moveFour[1]);

            Assert.AreSame(pieceFive, target.getBoard().getPiece(endVertOne, endHorizOne));
            Assert.AreSame(pieceSix, target.getBoard().getPiece(endVertTwo, endHorizTwo));
            Assert.AreSame(pieceSeven, target.getBoard().getPiece(endVertThree, endHorizThree));
            Assert.AreSame(pieceEight, target.getBoard().getPiece(endVertFour, endHorizFour));
        }


        [Test()]
        public void TestThatMovePieceFunctionsCorrectlyForBattleTie()
        {
            Board testBoard = new Board();
            Game target = new Game(testBoard);

            Int16 startVertOne = 3;
            Int16 startHorizOne = 2;
            Int16 startVertTwo = 6;
            Int16 startHorizTwo = 3;
            Int16 startVertThree = 3;
            Int16 startHorizThree = 7;
            Int16 startVertFour = 6;
            Int16 startHorizFour = 6;
            Int16 distanceOne = 1;
            Int16 distanceTwo = 1;
            Int16 distanceThree = 1;
            Int16 distanceFour = 1;
            Board.Direction directionOne = Board.Direction.W;
            Board.Direction directionTwo = Board.Direction.E;
            Board.Direction directionThree = Board.Direction.S;
            Board.Direction directionFour = Board.Direction.N;
            Int16 endVertOne = 3;
            Int16 endHorizOne = 1;
            Int16 endVertTwo = 6;
            Int16 endHorizTwo = 4;
            Int16 endVertThree = 2;
            Int16 endHorizThree = 7;
            Int16 endVertFour = 9;
            Int16 endHorizFour = 6;

            Piece pieceOne = new Piece(Piece.Team.red, Piece.Rank.spy);
            Piece pieceTwo = new Piece(Piece.Team.blue, Piece.Rank.scout);
            Piece pieceThree = new Piece(Piece.Team.red, Piece.Rank.marshal);
            Piece pieceFour = new Piece(Piece.Team.blue, Piece.Rank.colonel);

            Piece pieceFive = new Piece(Piece.Team.blue, Piece.Rank.spy);
            Piece pieceSix = new Piece(Piece.Team.red, Piece.Rank.scout);
            Piece pieceSeven = new Piece(Piece.Team.blue, Piece.Rank.marshal);
            Piece pieceEight = new Piece(Piece.Team.red, Piece.Rank.colonel);

            testBoard.placePiece(pieceOne, startVertOne, startHorizOne);
            testBoard.placePiece(pieceTwo, startVertTwo, startHorizTwo);
            testBoard.placePiece(pieceThree, startVertThree, startHorizThree);
            testBoard.placePiece(pieceFour, startVertFour, startHorizFour);

            testBoard.placePiece(pieceFive, endVertOne, endHorizOne);
            testBoard.placePiece(pieceSix, endVertTwo, endHorizTwo);
            testBoard.placePiece(pieceSeven, endVertThree, endHorizThree);
            testBoard.placePiece(pieceEight, endVertFour, endHorizFour);

            target.startGame();

            Boolean[] moveOne = target.movePiece(startVertOne, startHorizOne, directionOne, distanceOne);
            Boolean[] moveTwo = target.movePiece(startVertTwo, startHorizTwo, directionTwo, distanceTwo);
            Boolean[] moveThree = target.movePiece(startVertThree, startHorizThree, directionThree, distanceThree);
            Boolean[] moveFour = target.movePiece(startVertFour, startHorizFour, directionFour, distanceFour);

            Assert.True(moveOne[0]);
            Assert.False(moveOne[1]);
            Assert.True(moveTwo[0]);
            Assert.False(moveTwo[1]);
            Assert.True(moveThree[0]);
            Assert.False(moveThree[1]);
            Assert.True(moveFour[0]);
            Assert.False(moveFour[1]);
            
            Assert.Null(target.getBoard().getPiece(startVertOne, startHorizOne));
            Assert.Null(target.getBoard().getPiece(startVertTwo, startHorizTwo));
            Assert.Null(target.getBoard().getPiece(startVertThree, startHorizThree));
            Assert.Null(target.getBoard().getPiece(startVertFour, startHorizFour));

            Assert.Null(target.getBoard().getPiece(endVertOne, endHorizOne));
            Assert.Null(target.getBoard().getPiece(endVertTwo, endHorizTwo));
            Assert.Null(target.getBoard().getPiece(endVertThree, endHorizThree));
            Assert.Null(target.getBoard().getPiece(endVertFour, endHorizFour));
        }

        [Test()]
        public void TestThatMovePieceFunctionsCorrectlyForFlagCapture()
        {
            Board testBoard = new Board();
            Game target = new Game(testBoard);

            Int16 startVertOne = 3;
            Int16 startHorizOne = 2;
            Int16 startVertTwo = 6;
            Int16 startHorizTwo = 3;
            Int16 startVertThree = 3;
            Int16 startHorizThree = 7;
            Int16 startVertFour = 6;
            Int16 startHorizFour = 6;
            Int16 distanceOne = 1;
            Int16 distanceTwo = 1;
            Int16 distanceThree = 1;
            Int16 distanceFour = 1;
            Board.Direction directionOne = Board.Direction.W;
            Board.Direction directionTwo = Board.Direction.E;
            Board.Direction directionThree = Board.Direction.S;
            Board.Direction directionFour = Board.Direction.N;
            Int16 endVertOne = 3;
            Int16 endHorizOne = 1;
            Int16 endVertTwo = 6;
            Int16 endHorizTwo = 4;
            Int16 endVertThree = 2;
            Int16 endHorizThree = 7;
            Int16 endVertFour = 9;
            Int16 endHorizFour = 6;

            Piece pieceOne = new Piece(Piece.Team.red, Piece.Rank.spy);
            Piece pieceTwo = new Piece(Piece.Team.blue, Piece.Rank.scout);
            Piece pieceThree = new Piece(Piece.Team.red, Piece.Rank.marshal);
            Piece pieceFour = new Piece(Piece.Team.blue, Piece.Rank.colonel);

            Piece pieceFive = new Piece(Piece.Team.blue, Piece.Rank.flag);
            Piece pieceSix = new Piece(Piece.Team.red, Piece.Rank.flag);
            Piece pieceSeven = new Piece(Piece.Team.blue, Piece.Rank.flag);
            Piece pieceEight = new Piece(Piece.Team.red, Piece.Rank.flag);

            testBoard.placePiece(pieceOne, startVertOne, startHorizOne);
            testBoard.placePiece(pieceFive, endVertOne, endHorizOne);
            target.startGame();
            Boolean[] moveOne = target.movePiece(startVertOne, startHorizOne, directionOne, distanceOne);
            Assert.True(moveOne[0]);
            Assert.True(moveOne[1]);

            testBoard = new Board();
            target = new Game(testBoard);
            testBoard.placePiece(pieceTwo, startVertTwo, startHorizTwo);
            testBoard.placePiece(pieceSix, endVertTwo, endHorizTwo);
            target.startGame();
            Boolean[] moveTwo = target.movePiece(startVertTwo, startHorizTwo, directionTwo, distanceTwo);
            Assert.True(moveTwo[0]);
            Assert.True(moveTwo[1]);
            
            testBoard = new Board();
            target = new Game(testBoard);
            testBoard.placePiece(pieceThree, startVertThree, startHorizThree);
            testBoard.placePiece(pieceSeven, endVertThree, endHorizThree);
            target.startGame();
            Boolean[] moveThree = target.movePiece(startVertThree, startHorizThree, directionThree, distanceThree);
            Assert.True(moveThree[0]);
            Assert.True(moveThree[1]);

            testBoard = new Board();
            target = new Game(testBoard);
            testBoard.placePiece(pieceFour, startVertFour, startHorizFour);
            testBoard.placePiece(pieceEight, endVertFour, endHorizFour);
            target.startGame();
            Boolean[] moveFour = target.movePiece(startVertFour, startHorizFour, directionFour, distanceFour);
            Assert.True(moveFour[0]);
            Assert.True(moveFour[1]);
        }


        [Test()]
        public void TestThatSwapTurnFunctionsCorrectly()
        {
            Board mockBoard = mocks.Stub<Board>();

            Game target = new Game(mockBoard);

            Int16 startVertOne = 3;
            Int16 startHorizOne = 3;
            Int16 startVertTwo = 4;
            Int16 startHorizTwo = 3;
            Int16 distanceOne = 1;
            Int16 distanceTwo = 2;
            Board.Direction directionOne = Board.Direction.N;
            Board.Direction directionTwo = Board.Direction.E;
            Int16 endVertOne = 4;
            Int16 endHorizOne = 3;
            Int16 endVertTwo = 4;
            Int16 endHorizTwo = 2;

            using (mocks.Record())
            {
                mockBoard.isMoveValid(startVertOne, startHorizOne, directionOne, distanceOne);
                LastCall.Return(true);

                mockBoard.isMoveValid(startVertTwo, startHorizTwo, directionTwo, distanceTwo);
                LastCall.Return(true);

                //mockBoard.movePiece(startVertOne, startHorizOne, directionOne, distanceOne);
                //LastCall.Return( //Successful Move value

                //mockBoard.movePiece(startVertTwo, startHorizTwo, directionTwo, distanceTwo);
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

            target.movePiece(startVertOne, startHorizOne, directionOne, distanceOne);
            Assert.AreEqual(2, target.getCurrentTurn());
            Assert.AreEqual(1, target.getTurnCount());

            target.movePiece(startVertTwo, endHorizTwo, directionTwo, distanceTwo);
            Assert.AreEqual(1, target.getCurrentTurn());
            Assert.AreEqual(1, target.getTurnCount());
        }


    }
}
