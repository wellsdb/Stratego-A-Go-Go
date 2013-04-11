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
        private Int16 currentTurn;

        public Game()
        {

        }

        public Game(Board board)
        {

        }

        public Board getBoard()
        {
            return null;
        }

        public String getPlayerName(Int16 player)
        {
            return null;
        }

        public Int16 getPlayerPieceCount(Int16 player)
        {
            return -1;
        }

        public void setPlayerName(Int16 player, String name)
        {

        }

        public Int16 getTurnCount()
        {
            return -1;
        }

        public Int16 getCurrentTurn()
        {
            return -1;
        }
        
        public void startGame()
        {

        }

        public Boolean movePiece(Int16 team, Int16 v, Int16 h, Board.dir direction, Int16 distance)
        {
            return false;
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
