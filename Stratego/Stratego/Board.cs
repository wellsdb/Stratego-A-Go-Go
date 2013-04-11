using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego
{
    public class Board
    {
        public enum dir { N, E, S, W };

        Piece[,] b = new Piece[10, 10];

        public Board()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int k = 0; k < 10; k++)
                {
                    b[i, k] = null;
                }
            }
        }
        public Piece getSpace(int v, int h)
        {
            return b[h, v];
        }
        public void placePiece(Piece p, int v, int h)
        {
            b[h, v] = p;
        }
        public bool isMoveValid(int v, int h, int dir, int dist)
        {
            return true;
        }
    }
}
