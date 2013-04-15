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
        public enum Rank { flag = -1, spy, scout, miner, sergeant, lieutenant, captain, major, colonel, general, marshal, bomb };
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
                team = "B";
            else if (this.team == Team.red)
                team = "R";

            if (this.rank == Rank.flag)
                rank = "F";
            else if (this.rank == Rank.spy)
                rank = "S";
            else if (this.rank == Rank.bomb)
                rank = "B";
            else 
                rank = ((int)this.rank).ToString();

            return team + rank;
        }

        public static Combat Battle(Piece aggressor, Piece defender)
        {
            Rank aggRank = aggressor.getRank();
            Rank defRank = defender.getRank();

            if (defRank == Rank.bomb)
                if (aggRank != Rank.miner)
                    return Combat.loss;
                else return Combat.win;

            if (defRank == Rank.spy)
                if (aggRank == Rank.marshal)
                    return Combat.loss;

            if (aggRank == Rank.spy)
                if (defRank == Rank.marshal)
                    return Combat.win;

            int aggVal = (int)aggRank;
            int defVal = (int)defRank;

            if (aggVal > defVal)
                return Combat.win;
            else if (aggVal == defVal)
                return Combat.tie;
            else
                return Combat.loss;
        }
    }
}