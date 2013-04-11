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
        private Int16 currentTeam;

        public Game()
        {
            this.board = new Board();
            this.playerOne = new Player();
            this.playerTwo = new Player();
            this.turnCount = 0;
            this.currentTeam = 0;
        }

        public Game(Board board)
        {
            this.board = board;
            this.playerOne = new Player();
            this.playerTwo = new Player();
            this.turnCount = 0;
            this.currentTeam = 0;
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

        public Int16 getCurrentTurn()
        {
            return this.currentTeam;
        }
        
        public void startGame()
        {
            this.turnCount = 1;
            this.currentTeam = 1;
        }

        //returns true if the move is allowed and performed
        //returns false if the move is not allowed and not performed
        public Boolean[] movePiece(Int16 team, Int16 v, Int16 h, Board.dir direction, Int16 distance)
        {
            //check if piece belongs to the current player
            if (this.board.getSpace(v, h).getTeam() != this.currentTeam)
                return new Boolean[2] {false, false};

            //check if move is valid
            Boolean valid = this.board.isMoveValid(v, h, (int)direction, distance);

            //if move is invalid, return false
            if (!valid)
                return new Boolean[2] { false, false };

            //move is valid, so check victory
            Boolean victory = this.board.isVictory(v, h, (int)direction, distance);

            //move is valid, so perform move
            //get the values of the moving piece
            int movingPieceTeam = this.board.getSpace(h, v).getTeam();
            int movingPieceRank = this.board.getSpace(h, v).getRank();

            //place an empty piece on the old cell
            this.board.placePiece(null, v, h);

            //get the new space's coordinates
            int newV = 0;
            int newH = 0;

            switch (direction)
            {
                case Board.dir.N:
                    newV = v + distance;
                    newH = h;
                    break;
                case Board.dir.S:
                    newV = v - distance;
                    newH = h;
                    break;
                case Board.dir.E:
                    newV = v;
                    newH = h - distance;
                    break;
                case Board.dir.W:
                    newV = v;
                    newH = h + distance;
                    break;
            }

            //place the new piece on the new cell
            //(FIXME We're assumming the attacker always wins
            this.board.placePiece(new Piece(movingPieceTeam, movingPieceRank), newV, newH);

            //if victory, do victory things; otherwise let the other player take his turn
            if (victory)
                this.endGame(this.currentTeam);
            else
                this.swapTurn();

            return new Boolean[2] { true, victory };
        }

        private void swapTurn()
        {
            if (this.currentTeam == 1)
                this.currentTeam = 2;
            else
            {
                this.currentTeam = 1;
                this.turnCount++;
            }
        }

        public Boolean checkVictory()
        {
            return false;
        }

        public void endGame(Int16 currentTeam)
        {

        }

        private void removePiece()
        {
        }

    }
}
