using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego
{
    public class Piece
    {
        public enum team { red, blue };
        public enum rank { flag, spy, scout, miner, sergeant, lieutenant, captain, major, colonel, general, marshal, bomb };

        private int t, r;

        public Piece(){}

        public Piece(int team, int rank)
        {
            t = team;
            r = rank;
        }
        public int getTeam()
        {
            return t;
        }
        public int getRank()
        {
            return r;
        }
        public bool Equals(Piece p)
        {
            if (t == p.getTeam() && r == p.getRank()) return true;
            return false;
        }
    }
}