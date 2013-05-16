using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stratego;
using NUnit.Framework;
using Network;

namespace Testing.StrategoTests
{
    [TestFixture()]
    class GameControllerTests
    {
        [Test()]
        public void TestThatGameControllerInitializes()
        {
            GameController target = new GameController();
            Assert.NotNull(target);
            Assert.IsInstanceOf<GameController>(target);
        }

        [Test()]
        public void TestStartHotseatGame()
        {
            GameController target = new GameController();
            target.StartHotseatGame();

            Assert.AreEqual(GameController.GameType.Hotseat, target.GetGameType());
        }

        [Test()]
        public void TestStartNetworkGame()
        {
            GameController target = new GameController();
            target.StartNetworkGame();

            Assert.AreEqual(GameController.GameType.Network, target.GetGameType());
        }

        [Test()]
        public void TestGetSetAndClearCurrentSelection()
        {
            GameController target = new GameController();
            Assert.Null(target.getCurrentSelection());

            target.setCurrentSelection(5, 5);
            Assert.AreEqual(new Int16[2] { 5, 5 }, target.getCurrentSelection());

            target.clearCurrentSelection();
            Assert.Null(target.getCurrentSelection());
        }

        [Ignore]
        [Test()]
        public void TestSaveGame()
        {
            Assert.Fail();
        }

        [Ignore]
        [Test()]
        public void TestLoadGame()
        {
            Assert.Fail();
        }

        [Test()]
        public void TestValidateLinearMove()
        {
            Assert.True(GameController.ValidateLinearMove(5, 5, 5, 8));
            Assert.True(GameController.ValidateLinearMove(5, 5, 5, 3));
            Assert.True(GameController.ValidateLinearMove(5, 8, 5, 5));
            Assert.True(GameController.ValidateLinearMove(8, 5, 3, 5));
                
            Assert.False(GameController.ValidateLinearMove(5, 4, 5, 4));
            Assert.False(GameController.ValidateLinearMove(5, 4, 3, 2));
            Assert.False(GameController.ValidateLinearMove(1, 2, 5, 6));
            Assert.False(GameController.ValidateLinearMove(4, 5, 5, 6));
        }

        [Test()]
        public void TestDirectionCalc()
        {
            Assert.AreEqual(Board.Direction.N, GameController.DirectionCalc(5, 5, 3, 5));
            Assert.AreEqual(Board.Direction.N, GameController.DirectionCalc(8, 5, 5, 5));
            Assert.AreEqual(Board.Direction.S, GameController.DirectionCalc(3, 5, 5, 5));
            Assert.AreEqual(Board.Direction.S, GameController.DirectionCalc(5, 5, 8, 5));
            Assert.AreEqual(Board.Direction.E, GameController.DirectionCalc(5, 5, 5, 3));
            Assert.AreEqual(Board.Direction.E, GameController.DirectionCalc(5, 8, 5, 5));
            Assert.AreEqual(Board.Direction.W, GameController.DirectionCalc(5, 3, 5, 5));
            Assert.AreEqual(Board.Direction.W, GameController.DirectionCalc(5, 5, 5, 8));
        }

        [Test()]
        public void TestDistanceCalc()
        {
            Assert.AreEqual(1, GameController.DistanceCalc(6, 5, 5, 5, Board.Direction.N));
            Assert.AreEqual(3, GameController.DistanceCalc(5, 5, 8, 5, Board.Direction.S));
            Assert.AreEqual(5, GameController.DistanceCalc(5, 8, 5, 3, Board.Direction.E));
            Assert.AreEqual(7, GameController.DistanceCalc(5, 2, 5, 9, Board.Direction.W));
        }

        [Ignore]
        [Test()]
        public void TestAttemptMove()
        {
            Assert.Fail();
        }

        [Test()]
        public void TestOwnerPlayerGet()
        {
            GameController c = new GameController();

            c.StartHotseatGame();
            String r = "none";
            Assert.AreEqual(r, c.GetOwnerPlayer());

            c.CreateQuickNetworkGame();    
            r = "red";
            Assert.AreEqual(r, c.GetOwnerPlayer());

            c.JoinQuickNetworkGame();
            r = "blue";
            Assert.AreEqual(r, c.GetOwnerPlayer());
        }

        [Test()]
        public void TestOwnerTeamGet()
        {
            //GameController c = new GameController();

            //c.StartHotseatGame();
            //Piece.Team r = Piece.Team.red;
            //Assert.AreEqual(r, c.GetOwnerPlayer());

            //c.CreateNetworkGame();
            //r = "red";
            //Assert.AreEqual(r, c.GetOwnerPlayer());

            //c.JoinNetworkGame();
            //r = "blue";
            //Assert.AreEqual(r, c.GetOwnerPlayer());
        }

        //[Test()]
        //public void TestSetSendPort()
        //{
        //    GameController target = new GameController();

        //    Assert.AreEqual((int)NetworkController.Port.Zero, target.GetSendPort());

        //    target.SetSendPort(3001);
        //    Assert.AreEqual((int)NetworkController.Port.One, target.GetSendPort());
        //}

        //[Test()]
        //public void TestSetRecievePort()
        //{
        //    GameController target = new GameController();

        //    Assert.AreEqual((int)NetworkController.Port.One, target.GetRecievePort());

        //    target.SetRecievePort(3002);
        //    Assert.AreEqual((int)NetworkController.Port.Two, target.GetRecievePort());
        //}

        //[Test()]
        //public void TestSetSendIP()
        //{
        //    GameController target = new GameController();

        //    Assert.AreEqual("127.0.0.1", target.GetSendIP());

        //    target.SetSendIP("127.0.0.2");
        //    Assert.AreEqual("127.0.0.2", target.GetSendIP());
        //}

        //[Test()]
        //public void TestSendBoard()
        //{

        //}

        //[Test()]
        //public void TestRecieveBoard()
        //{

        //}
    }
}
