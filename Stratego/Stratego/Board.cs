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

        Cell[,] b = new Cell[10, 10];

        public Board()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int k = 0; k < 10; k++)
                {

                    b[i, k] = new Cell();
                }
            }
            b[4, 2].setTerrain(Cell.Terrain.Lake);
            b[4, 3].setTerrain(Cell.Terrain.Lake);
            b[5, 2].setTerrain(Cell.Terrain.Lake);
            b[5, 3].setTerrain(Cell.Terrain.Lake);
            b[4, 6].setTerrain(Cell.Terrain.Lake);
            b[4, 7].setTerrain(Cell.Terrain.Lake);
            b[5, 6].setTerrain(Cell.Terrain.Lake);
            b[5, 7].setTerrain(Cell.Terrain.Lake);
        }
        public Piece getSpace(int v, int h)
        {
            return b[h, v].getPiece();
        }
        public void placePiece(Piece p, int v, int h)
        {
            b[h, v].setPiece(p);
        }
        public bool isMoveValid(int v, int h, int dir, int dist)
        {
            return true;
        }
    }
}
