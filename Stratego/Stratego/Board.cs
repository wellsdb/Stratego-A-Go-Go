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
            return b[v, h].getPiece();
        }
        public void placePiece(Piece p, int v, int h)
        {
            b[v, h].setPiece(p);
        }
        public bool isMoveValid(int v, int h, int dir, int dist)
        {
            Piece p = b[v,h].getPiece();

            if (dir == 0 && v + dist > 9) return false;
            if (dir == 1 && h + dist > 9) return false;
            if (dir == 2 && v - dist < 0) return false;
            if (dir == 3 && h - dist < 0) return false;

            if (p.getRank() == 0 && dist > 0) return false;
            if (p.getRank() == 11 && dist > 0) return false;
            if(p.getRank() != 2 && dist>1) return false;

            for (int i = 0; i <= dist; i++)
            {
                if (dir == 0 && b[v + i, h].getTerrain() == Cell.Terrain.Lake) return false;
                if (dir == 2 && b[v - i, h].getTerrain() == Cell.Terrain.Lake) return false;
                if (dir == 1 && b[v, h + i].getTerrain() == Cell.Terrain.Lake) return false;
                if (dir == 3 && b[v, h - i].getTerrain() == Cell.Terrain.Lake) return false;
                
            }

            if (dist > 1)
            {
                for (int i = 1; i <= dist; i++)
                {
                    if (dir == 0 && b[v + i, h].getPiece() != null) return false;
                    if (dir == 2 && b[v - i, h].getPiece() != null) return false;
                    if (dir == 1 && b[v, h + i].getPiece() != null) return false;
                    if (dir == 3 && b[v, h - i].getPiece() != null) return false;
                }
            }

            return true;
        }

        public bool isVictory(int v, int h, int dir, int dist)
        {
            if (dir == 0) return (b[v + 1, h].getPiece().getRank() == 0);
            if (dir == 2) return (b[v - 1, h].getPiece().getRank() == 0);
            if (dir == 1) return (b[v, h + 1].getPiece().getRank() == 0);
            if (dir == 3) return (b[v, h - 1].getPiece().getRank() == 0);
            return isMoveValid(v, h, dir, dist);
        }
    }
}
