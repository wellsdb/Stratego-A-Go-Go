using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego
{
    public class Piece
    {
        public enum Team { none, red, blue };
        public enum Rank { flag, spy, scout, miner, sergeant, lieutenant, captain, major, colonel, general, marshal, bomb };
        public enum Combat { win, loss, tie };

        private Team team;
        private Rank rank;

        public Piece(){}

        public Piece(Team team, Rank rank)
        {
            this.team = team;
            this.rank = rank;
        }
        public Team getTeam()
        {
            return this.team;
        }
        public Rank getRank()
        {
            return this.rank;
        }
        public Boolean Equals(Piece p)
        {
            if (team == p.getTeam() && rank == p.getRank()) return true;
            return false;
        }

        public String toString()
        {
            if (this == null)
                return "||";
            
            String team = "None";
            String rank = "-1";

            if (this.team == Team.blue)
                team = "Blue";
            else if (this.team == Team.red)
                team = "Red";

            rank = ((int)this.rank).ToString();

            return team + rank;
        }

        public static Combat Battle(Piece aggressor, Piece defender)
        {
            return Combat.loss;
        }
    }
}