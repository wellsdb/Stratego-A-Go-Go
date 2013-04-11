using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego
{
    class Game
    {
        private Board board;
        private Player playerOne;
        private Player playerTwo;
        private Int16 turnCount;
        private Boolean currentTurn;

        public Game()
        {

        }

        public void startGame()
        {

        }

        public Boolean movePiece(Boolean team, Int16[,] startingCell, Board.Direction direction, Int16 distance)
        {
            return false;
        }

        public Boolean checkVictory()
        {

        }

        public void endGame()
        {

        }

    }
}
