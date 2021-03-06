﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stratego
{
    public class GameController
    {
        public enum GameType { Hotseat, Network };
        private Game game;
        private GameType gameType;
        private Int16[] currentSelection;
        private Piece.Team ownerPlayer;
        private Board.BattleMode battleMode = Board.BattleMode.Normal;
        private Boolean gameOver;

        public GameController()
        {
            this.game = new Game();
        }


        //public void Stop()
        //{
        //    this.networkController.StopServer();
        //}

        public String GetOwnerPlayer()
        {
            return this.ownerPlayer.ToString();
        }

        public Piece.Team GetOwnerTeam()
        {
            return this.ownerPlayer;
        }

        public String GetCurrentPlayer()
        {
            return this.game.getCurrentTurn().ToString();
        }

        public Piece.Team GetCurrentTeam()
        {
            return this.game.getCurrentTurn();
        }

        public void StartHotseatGame()
        {
            //this.game = new Game(Board.GetTestBoard());
            this.game = new Game(Board.GetPrePlacedBoard());
            this.gameType = GameType.Hotseat;            
            this.game.startGame();
            this.game.setPlacement(false);
            this.game.getBoard().setBattleMode(this.battleMode);
        }

        public void StartCustomHotseatGame()
        {
            this.game = new Game(Board.GetDefaultBoard());
            this.gameType = GameType.Hotseat;
            this.game.startGame();
            this.game.getBoard().setBattleMode(this.battleMode);
        }

        public void CreateQuickNetworkGame()
        {
            //this.networkController.SetIP(NetworkController.LOCALHOST_IP);         
            //this.networkController.SetSendPort(NetworkController.Port.One);
            //this.networkController.SetRecievePort(NetworkController.Port.Zero);
            //this.networkController.StartServer();
            //Thread.Sleep(100);
            //String joiner = networkController.RecieveString();
            this.game = new Game(Board.GetPrePlacedBoard());
            this.gameType = GameType.Network;
            this.ownerPlayer = Piece.Team.red;
            this.game.startGame();
            this.game.setPlacement(false);
            this.game.getBoard().setBattleMode(this.battleMode);            
        }

        public void CreateCustomNetworkGame()
        {
            //this.networkController.SetIP(NetworkController.LOCALHOST_IP);         
            //this.networkController.SetSendPort(NetworkController.Port.One);
            //this.networkController.SetRecievePort(NetworkController.Port.Zero);
            //this.networkController.StartServer();
            //Thread.Sleep(100);
            //String joiner = networkController.RecieveString();
            this.game = new Game(Board.GetDefaultBoard());
            this.gameType = GameType.Network;
            this.ownerPlayer = Piece.Team.red;
            this.game.startGame();
            this.game.getBoard().setBattleMode(this.battleMode);
        }

        //public void JoinNetworkGame(String ip)
        public void JoinQuickNetworkGame()
        {
            //this.networkController.SetIP(ip);
            //this.networkController.SetIP(NetworkController.LOCALHOST_IP);
            //this.networkController.SetSendPort(NetworkController.Port.Zero);
            //this.networkController.SetRecievePort(NetworkController.Port.One);
            //this.networkController.StartServer();
            //Thread.Sleep(100);
            //networkController.SendString("Join");
            this.game = new Game(Board.GetPrePlacedBoard());
            this.gameType = GameType.Network;
            this.ownerPlayer = Piece.Team.blue;
            this.game.startGame();
            this.game.setPlacement(false);
            this.game.getBoard().setBattleMode(this.battleMode);
            //this.WaitForTurn();
        }

        public void JoinCustomNetworkGame()
        {
            //this.networkController.SetIP(ip);
            //this.networkController.SetIP(NetworkController.LOCALHOST_IP);
            //this.networkController.SetSendPort(NetworkController.Port.Zero);
            //this.networkController.SetRecievePort(NetworkController.Port.One);
            //this.networkController.StartServer();
            //Thread.Sleep(100);
            //networkController.SendString("Join");
            this.game = new Game(Board.GetDefaultBoard());
            this.gameType = GameType.Network;
            this.ownerPlayer = Piece.Team.blue;
            this.game.startGame();
            this.game.getBoard().setBattleMode(this.battleMode);
            //this.WaitForTurn();
        }

        //public void WaitForTurn()
        //{
        //    String oldMove = this.networkController.RecieveString();
        //    String newMove = oldMove;
        //    while (newMove == oldMove)
        //    {
        //        newMove = this.networkController.RecieveString();
        //    }

        //    this.PerformOtherMove(Game.StringToMove(newMove));
        //}

        public void StartNetworkGame()
        {

            this.game = new Game();
            this.gameType = GameType.Network;
            
        }

        public GameType GetGameType()
        {
            return this.gameType;
        }

        public Int16[] getCurrentSelection()
        {
            return this.currentSelection;
        }

        public void setCurrentSelection(Int16 v, Int16 h)
        {
            //if (this.gameType == GameType.Hotseat | this.game.getCurrentTurn() == this.ownerPlayer)
            //{
                this.currentSelection = new Int16[2];
                currentSelection[0] = v;
                currentSelection[1] = h;
            //}
        }

        public void clearCurrentSelection()
        {
            this.currentSelection = null;
        }

        public Game GetGame()
        {
            return this.game;
        }

        public Board GetBoard()
        {
            return this.game.getBoard();
        }

        public void SaveGame(String fileName)
        {
            this.game.saveFile(fileName);
        }

        public void LoadGame(String fileName)
        {
            this.game.loadFile(fileName);
        }
        
        public static Boolean ValidateLinearMove(Int16 v, Int16 h, Int16 currentV, Int16 currentH)
        {
            if (v == currentV)
            {
                if (h == currentH)
                    return false;
                else
                    return true;
            }
            else if (h == currentH)
            {
                if (v == currentV)
                    return false;
                else
                    return true;
            }
            else
                return false;
        }

        public static Board.Direction DirectionCalc(Int16 v, Int16 h, Int16 currentV, Int16 currentH)
        {
            if (v == currentV)
            {
                if (h > currentH)
                    return Board.Direction.E;
                else
                    return Board.Direction.W;
            }
            else
            {
                if (v > currentV)
                    return Board.Direction.N;
                else
                    return Board.Direction.S;
            }
        }

        public static Int16 DistanceCalc(Int16 v, Int16 h, Int16 currentV, Int16 currentH, Board.Direction dir)
        {
            if (dir == Board.Direction.N)
                return (Int16)(v - currentV);
            if (dir == Board.Direction.S)
                return (Int16)(currentV - v);
            if (dir == Board.Direction.E)
                return (Int16)(h - currentH);
            if (dir == Board.Direction.W)
                return (Int16)(currentH - h);

            return 0;

        }

        public Boolean[] HandleMove(short v, short h)
        {
            //attempt move
            Int16 currentV = this.currentSelection[0];
            Int16 currentH = this.currentSelection[1];
            Boolean[] result = AttemptMove(v, h, currentV, currentH);

            //if move was successful
            if (this.gameType == GameType.Network & result[0])
            {
                //this.networkController.SendString(Game.MoveToString(v, h, currentV, currentH));
                //start listening for other move
                
                //Thread.Sleep(10000);
                //this.WaitForTurn();
            }
            return result;
        }                

        public Boolean[] AttemptMove(Int16 newV, Int16 hewH, short oldV, short oldH)
        {            

            if (!ValidateLinearMove(newV, hewH, oldV, oldH))
            {
                return new Boolean[2] { false, false };
            }

            Board.Direction dir = DirectionCalc(newV, hewH, oldV, oldH);
            Int16 dist = DistanceCalc(newV, hewH, oldV, oldH, dir);

            return this.game.movePiece(oldV, oldH, dir, dist);
        }

        public List<Point> GetAvailableMoves(Point originCoordinate)
        {
            return this.game.getBoard().GetAvailableMoves(originCoordinate);
        }

        public void SetBattleMode(Board.BattleMode mode)
        {
            this.battleMode = mode;
            if (this.game != null)
                this.game.getBoard().setBattleMode(mode);
        }

        public Board.BattleMode GetBattleMode()
        {
            return this.battleMode;
        }

        public Boolean GetGameOver()
        {
            //return this.game.over
            return false;
        }

        public Point[] GetRevealedPieces()
        {
            return this.game.GetRevealedPieces();
        }

    }
}
