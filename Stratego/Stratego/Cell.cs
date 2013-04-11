using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego
{
    public class Cell
    {
        private Boolean terrain { get; set; }
        private Piece piece { get; set; }

        public void setPiece(Piece piece)
        {
            this.piece = piece;
        }

        public void setTerrain(Boolean terrain)
        {
            this.terrain = terrain;
        }

        public Boolean getTerrain()
        {
            return this.terrain;
        }

        public Piece getPiece()
        {
            return this.piece;
        }


        public Cell()
        {
            this.terrain = false;
            this.piece = null;
        }

        public Cell(Boolean terrain)
        {
            this.terrain = terrain;
            this.piece = null;
        }

        public Cell(Piece piece)
        {
            this.terrain = false;
            this.piece = piece;
        }

        public Cell(Boolean terrain, Piece piece)
        {
            this.terrain = terrain;
            this.piece = piece;
        }

    }
}
