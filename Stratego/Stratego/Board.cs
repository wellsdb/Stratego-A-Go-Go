using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego
{
    public class Board
    {
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
        public Piece getSpace(int h, int v)
        {
            return b[h, v];
        }
        public void placePiece(Piece p, int h, int v)
        {
            b[h, v] = p;
        }
        public bool isMoveValid(int h, int v, int hn, int vn)
        {
            if ((h - hn != 0) && (v - vn != 0)) //Can't move diagonally
            {
                return false;
            }
            if (b[h, v] == null)
            {
                return false;
            }
            Piece p = b[h, v];
            if (b[hn, vn] != null && b[hn, vn].getTeam() == 2) //Can't land in lake
            {
                return false;
            }
            if ((p.getRank() != 2) && (Math.Max(Math.Abs(h - hn), Math.Abs(v - vn)) > 1)) //No rank other than scouts can move more than one space
            {
                return false;
            }
            return true;
        }
    }
}