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
        public enum Event { GoodMove, BadMove, Win, Loss, Tie, Flag };

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

            if (p == null)
                throw new ArgumentOutOfRangeException("The space being moved from must have a piece in it!");

            //edge of the board checks
            if (dir == Direction.N && v + dist > 9) return false;
            if (dir == Direction.E && h + dist > 9) return false;
            if (dir == Direction.S && v - dist < 0) return false;
            if (dir == Direction.W && h - dist < 0) return false;

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
                    for (int i = 1; i < dist; i++)
                       if (cells[v + i, h].getPiece() != null)
                           return false;
                }
                if (dir == Direction.S)
                {
                    for (int i = 1; i < dist; i++)
                       if (cells[v - i, h].getPiece() != null)
                           return false;
                }
                if (dir == Direction.E)
                {
                    for (int i = 1; i < dist; i++)
                       if (cells[v, h + i].getPiece() != null)
                           return false;
                }
                if (dir == Direction.W)
                {
                    for (int i = 1; i < dist; i++)
                       if (cells[v, h - i].getPiece() != null)
                           return false;
                }
            }

            //moving onto an ally checks
            int[] dest = Board.DestinationCalc(v, h, dir, dist);

            Piece destinationP = cells[dest[0], dest[1]].getPiece();
            if (destinationP != null)
                if (destinationP.getTeam() == p.getTeam())
                    return false;

            return true;
        }

        public Event moveEvent(int v, int h, Direction dir, int dist)
        {
            if (!this.isMoveValid(v,h,dir,dist))
                return Event.BadMove;

            int[] dest = Board.DestinationCalc(v, h, dir, dist);
            Piece destPiece = cells[dest[0], dest[1]].getPiece();

            if (destPiece == null)
                return Event.GoodMove;

            if (destPiece.getRank() == Piece.Rank.flag)
                return Event.Flag;

            Piece currentPiece = cells[v, h].getPiece();

            Piece.Combat battleResult = Piece.Battle(currentPiece, destPiece);

            if (battleResult == Piece.Combat.win)
                return Event.Win;
            else if (battleResult == Piece.Combat.loss)
                return Event.Loss;
            else
                return Event.Tie;
        }

        public static int[] DestinationCalc(int v, int h, Direction dir, int dist)
        {
            int destinationH = h;
            int destinationV = v;

            switch (dir)
            {
                case Direction.N:
                    destinationV = v + dist;
                    break;
                case Direction.S:
                    destinationV = v - dist;
                    break;
                case Direction.E:
                    destinationH = h + dist;
                    break;
                case Direction.W:
                    destinationH = h - dist;
                    break;
            }

            int[] coords = {destinationV, destinationH};

            return coords;
        }

    }
}
