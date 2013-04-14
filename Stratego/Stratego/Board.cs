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
        public enum Event { GoodMove, BadMove, Win, Loss, Flag };

        Cell[,] cells = new Cell[10, 10];

        public Board()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int k = 0; k < 10; k++)
                {

                    cells[i, k] = new Cell();
                }
            }
            cells[4, 2].setTerrain(Cell.Terrain.Lake);
            cells[4, 3].setTerrain(Cell.Terrain.Lake);
            cells[5, 2].setTerrain(Cell.Terrain.Lake);
            cells[5, 3].setTerrain(Cell.Terrain.Lake);
            cells[4, 6].setTerrain(Cell.Terrain.Lake);
            cells[4, 7].setTerrain(Cell.Terrain.Lake);
            cells[5, 6].setTerrain(Cell.Terrain.Lake);
            cells[5, 7].setTerrain(Cell.Terrain.Lake);
        }
        public Piece getPiece(int v, int h)
        {
            return cells[v, h].getPiece();
        }
        public Cell getCell(int v, int h)
        {
            return cells[v, h];
        }
        public void placePiece(Piece p, int v, int h)
        {
            cells[v, h].setPiece(p);
        }
        public bool isMoveValid(int v, int h, Direction dir, int dist)
        {
            Piece p = cells[v,h].getPiece();

            //edge of the board checks
            if (dir == Direction.N && v + dist > 9) return false;
            if (dir == Direction.E && h + dist > 9) return false;
            if (dir == Direction.S && v - dist < 0) return false;
            if (dir == Direction.W && h - dist < 0) return false;

            //if (p.getRank() == Piece.Rank.flag && dist > 0) return false;
            //if (p.getRank() == Piece.Rank.bomb && dist > 0) return false;

            //rank checks
            if (p.getRank() == Piece.Rank.flag) return false;
            if (p.getRank() == Piece.Rank.bomb) return false;
            if(p.getRank() != Piece.Rank.scout && dist > 1) return false;

            //lake checks
            for (int i = 0; i <= dist; i++)
            {
                if (dir == Direction.N && cells[v + i, h].getTerrain() == Cell.Terrain.Lake) return false;
                if (dir == Direction.S && cells[v - i, h].getTerrain() == Cell.Terrain.Lake) return false;
                if (dir == Direction.E && cells[v, h + i].getTerrain() == Cell.Terrain.Lake) return false;
                if (dir == Direction.W && cells[v, h - i].getTerrain() == Cell.Terrain.Lake) return false;
            }

            //piece in the middle of the move checks
            if (dist > 1)
            {
                if (dir == Direction.N)
                {
                    for (int i = 1; i <= dist; i++)
                       if (cells[v + i, h].getPiece() != null)
                           return false;
                }
                if (dir == Direction.S)
                {
                    for (int i = 1; i <= dist; i++)
                       if (cells[v - i, h].getPiece() != null)
                           return false;
                }
                if (dir == Direction.E)
                {
                    for (int i = 1; i <= dist; i++)
                       if (cells[v, h + i].getPiece() != null)
                           return false;
                }
                if (dir == Direction.W)
                {
                    for (int i = 1; i <= dist; i++)
                       if (cells[v, h - i].getPiece() != null)
                           return false;
                }
            }

            return true;
        }

        public Event MovePiece(int v, int h, Direction dir, int dist)
        {
            //TODO fill in
            return Event.BadMove;
        }

        public bool isVictory(int v, int h, Direction dir, int dist)
        {
            Piece piece = null;

            if (dir == Direction.N) 
                piece = cells[v + 1, h].getPiece();
            if (dir == Direction.S) 
                piece = cells[v - 1, h].getPiece();
            if (dir == Direction.E)
                piece = cells[v, h + 1].getPiece();
            if (dir == Direction.W) 
                piece = cells[v, h - 1].getPiece();

            if (piece == null)
                return false;
            else if (piece.getRank() == 0)
                return isMoveValid(v, h, dir, dist);
            return false;
        }
    }
}
