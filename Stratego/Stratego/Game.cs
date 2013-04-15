using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego
{
    public class Game
    {
        private Board board;
        private Player playerOne;
        private Player playerTwo;
        private Int16 turnCount;
        private Piece.Team currentTeam;

        public Game()
        {
            this.board = new Board();
            this.playerOne = new Player();
            this.playerTwo = new Player();
            this.turnCount = 0;
            this.currentTeam = Piece.Team.none;
        }

        public Game(Board board)
        {
            this.board = board;
            this.playerOne = new Player();
            this.playerTwo = new Player();
            this.turnCount = 0;
            this.currentTeam = Piece.Team.none;
        }

        public Board getBoard()
        {
            return this.board;
        }

        public String getPlayerName(Int16 player)
        {
            if (player == 1)
                return this.playerOne.getName();
            if (player == 2)
                return this.playerTwo.getName();
            throw new ArgumentOutOfRangeException("Player does not exist!");
        }

        public Int16 getPlayerPieceCount(Int16 player)
        {
            if (player == 1)
                return this.playerOne.getPieceCount();
            if (player == 2)
                return this.playerTwo.getPieceCount();
            throw new ArgumentOutOfRangeException("Player does not exist!");
        }

        public void setPlayerName(Int16 player, String name)
        {
            if (player == 1)
                this.playerOne.setName(name);
            else if (player == 2)
                this.playerTwo.setName(name);
            else throw new ArgumentOutOfRangeException("Player does not exist!");
        }

        public Int16 getTurnCount()
        {
            return this.turnCount;
        }

        public Piece.Team getCurrentTurn()
        {
            return this.currentTeam;
        }
        
        public void startGame()
        {
            this.turnCount = 1;
            this.currentTeam = Piece.Team.red;
        }

        //returns true if the move is allowed and performed
        //returns false if the move is not allowed and not performed
        public Boolean[] movePiece(Int16 v, Int16 h, Board.Direction direction, Int16 distance)
        {

            Piece movingPiece = this.board.getPiece(v, h);

            // check if a piece exists in the given cell
            if (movingPiece == null)
                return new Boolean[2] {false, false};

            // check if the piece belongs to the current player
            if (movingPiece.getTeam() != this.currentTeam)
                return new Boolean[2] {false, false};

            // check if move is valid
            Boolean valid = this.board.isMoveValid(v, h, direction, distance);

            //if move is invalid, return false
            if (!valid)
                return new Boolean[2] { false, false };

            // move is valid
            // get the effect of the move
            Board.Event moveEvent = this.board.moveEvent(v, h, direction, distance);

            //place an empty piece on the old cell
            this.board.placePiece(null, v, h);

            // get the new space's coordinates
            int[] destination = Board.DestinationCalc(v, h, direction, distance);

            switch (moveEvent)
            {
                case Board.Event.GoodMove:
                    // place the piece
                    this.board.placePiece(movingPiece, destination[0], destination[1]);
                    break;
                case Board.Event.Win:
                    // TODO adjust piece count

                    // place the piece
                    this.board.placePiece(movingPiece, destination[0], destination[1]);
                    break;
                case Board.Event.Loss:
                    // TODO adjust piece count
                    break;
                case Board.Event.Tie:
                    // adjust piece count
                    // remove both pieces
                    this.board.placePiece(null, destination[0], destination[1]);
                    break;
                case Board.Event.Flag:
                    // place the piece
                    this.board.placePiece(movingPiece, destination[0], destination[1]);
                    // end the game
                    this.endGame();
                    return new Boolean[2] {true, true};
            }

            this.swapTurn();

            return new Boolean[2] { true, false };
        }

        private void swapTurn()
        {
            if (this.currentTeam == Piece.Team.red)
                this.currentTeam = Piece.Team.blue;
            else
            {
                this.currentTeam = Piece.Team.red;
                this.turnCount++;
            }
        }

        public Boolean checkVictory()
        {
            return false;
        }

        public void endGame()
        {

        }

        private void removePiece()
        {
        }

    }
}
