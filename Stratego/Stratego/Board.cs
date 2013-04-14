using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego
{
    public class Board
    {
        public enum Direction { N, E, S, W };

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
        public Cell getCell(int v, int h)
        {
            return b[v, h];
        }
        public void placePiece(Piece p, int v, int h)
        {
            b[v, h].setPiece(p);
        }
        public bool isMoveValid(int v, int h, Direction dir, int dist)
        {
            Piece p = b[v,h].getPiece();

            if (dir == Direction.N && v + dist > 9) return false;
            if (dir == Direction.E && h + dist > 9) return false;
            if (dir == Direction.S && v - dist < 0) return false;
            if (dir == Direction.W && h - dist < 0) return false;

            if (p.getRank() == Piece.Rank.flag && dist > 0) return false;
            if (p.getRank() == Piece.Rank.bomb && dist > 0) return false;
            if(p.getRank() != Piece.Rank.scout && dist>1) return false;

            for (int i = 0; i <= dist; i++)
            {
                if (dir == Direction.N && b[v + i, h].getTerrain() == Cell.Terrain.Lake) return false;
                if (dir == Direction.S && b[v - i, h].getTerrain() == Cell.Terrain.Lake) return false;
                if (dir == Direction.E && b[v, h + i].getTerrain() == Cell.Terrain.Lake) return false;
                if (dir == Direction.W && b[v, h - i].getTerrain() == Cell.Terrain.Lake) return false;
                
            }

            if (dist > 1)
            {
                for (int i = 1; i <= dist; i++)
                {
                    if (dir == Direction.N && b[v + i, h].getPiece() != null) return false;
                    if (dir == Direction.S && b[v - i, h].getPiece() != null) return false;
                    if (dir == Direction.E && b[v, h + i].getPiece() != null) return false;
                    if (dir == Direction.S && b[v, h - i].getPiece() != null) return false;
                }
            }

            return true;
        }

        public bool isVictory(int v, int h, Direction dir, int dist)
        {
            Piece piece = null;

            if (dir == Direction.N) 
                piece = b[v + 1, h].getPiece();
            if (dir == Direction.S) 
                piece = b[v - 1, h].getPiece();
            if (dir == Direction.E)
                piece = b[v, h + 1].getPiece();
            if (dir == Direction.W) 
                piece = b[v, h - 1].getPiece();

            if (piece == null)
                return false;
            else if (piece.getRank() == 0)
                return isMoveValid(v, h, dir, dist);
            return false;
        }
    }
}
