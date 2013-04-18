using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego
{
    public class Cell
    {
        public enum Terrain { Land, Lake };
        private Piece piece;
        private Terrain terrain;

        public void setPiece(Piece piece)
        {
            this.piece = piece;
        }

        public void setTerrain(Terrain terrain)
        {
            this.terrain = terrain;
        }

        public Terrain getTerrain()
        {
            return this.terrain;
        }

        public Piece getPiece()
        {
            return this.piece;
        }


        public Cell()
        {
            this.terrain = Terrain.Land;
            this.piece = null;
        }

        public Cell(Terrain terrain)
        {
            this.terrain = terrain;
            this.piece = null;
        }

        public Cell(Piece piece)
        {
            this.terrain = Terrain.Land;
            this.piece = piece;
        }

        public Cell(Terrain terrain, Piece piece)
        {
            this.terrain = terrain;
            this.piece = piece;
        }

    }
}
