using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego
{
    public class Piece
    {
        private int rank;
        private int team;

        public Piece()
        {

        }

        public Piece(int t, int r)
        {
            team = t;
            rank = r;
        }
        public int getTeam()
        {
            return team;
        }
        public int getRank()
        {
            return rank;
        }
        public bool Equals(Piece p)
        {
            if (p.getTeam() == team && p.getRank() == rank) return true;
            return false;
        }
    }
}