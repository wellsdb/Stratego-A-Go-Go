using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Stratego
{
    public class Board
    {
        public enum Direction { N, E, S, W };
        public enum Event { GoodMove, BadMove, Win, Loss, Tie, Flag };
        public enum BattleMode { Normal, Reverse };
        private short redCount = 0;
        private short blueCount = 0;

        private BattleMode mode = BattleMode.Normal;

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

            this.getCell(4, 2).setTerrain(Cell.Terrain.Lake);
            this.getCell(4, 3).setTerrain(Cell.Terrain.Lake);
            this.getCell(5, 2).setTerrain(Cell.Terrain.Lake);
            this.getCell(5, 3).setTerrain(Cell.Terrain.Lake);
            this.getCell(4, 6).setTerrain(Cell.Terrain.Lake);
            this.getCell(4, 7).setTerrain(Cell.Terrain.Lake);
            this.getCell(5, 6).setTerrain(Cell.Terrain.Lake);
            this.getCell(5, 7).setTerrain(Cell.Terrain.Lake);

        }

        public static Board GetDefaultBoard()
        {
            Board b = new Board();

            b.getCell(4, 2).setTerrain(Cell.Terrain.Lake);
            b.getCell(4, 3).setTerrain(Cell.Terrain.Lake);
            b.getCell(5, 2).setTerrain(Cell.Terrain.Lake);
            b.getCell(5, 3).setTerrain(Cell.Terrain.Lake);
            b.getCell(4, 6).setTerrain(Cell.Terrain.Lake);
            b.getCell(4, 7).setTerrain(Cell.Terrain.Lake);
            b.getCell(5, 6).setTerrain(Cell.Terrain.Lake);
            b.getCell(5, 7).setTerrain(Cell.Terrain.Lake);

            return b;
        }

        public static Board GetTestBoard()
        {
            Board b = Board.GetDefaultBoard();

            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.scout), 7, 4);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.colonel), 7, 5);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.flag), 7, 6);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 2, 5);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.colonel), 2, 4);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.flag), 2, 3);

            return b;
        }

        public static Board GetPrePlacedBoard()
        {
            Board b = Board.GetDefaultBoard();

            //BLUE
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.scout), 6, 0);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.scout), 6, 1);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.scout), 6, 2);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.scout), 6, 3);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.scout), 6, 4);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.scout), 6, 5);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.scout), 6, 6);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.scout), 6, 7);

            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.miner), 6, 8);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.miner), 6, 9);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.miner), 7, 0);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.miner), 7, 1);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.miner), 7, 2);

            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.sergeant), 7, 3);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.sergeant), 7, 4);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.sergeant), 7, 5);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.sergeant), 7, 6);

            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.lieutenant), 7, 7);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.lieutenant), 7, 8);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.lieutenant), 7, 9);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.lieutenant), 8, 0);

            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.captain), 8, 1);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.captain), 8, 2);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.captain), 8, 3);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.captain), 8, 4);

            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.major), 8, 5);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.major), 8, 6);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.major), 8, 7);

            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.colonel), 8, 8);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.colonel), 8, 9);

            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.general), 9, 0);

            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 9, 1);

            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.bomb), 9, 2);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.bomb), 9, 3);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.bomb), 9, 4);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.bomb), 9, 5);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.bomb), 9, 6);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.bomb), 9, 7);

            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.flag), 9, 8);

            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.spy), 9, 9);

            //RED
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 3, 0);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 3, 1);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 3, 2);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 3, 3);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 3, 4);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 3, 5);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 3, 6);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 3, 7);

            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.miner), 3, 8);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.miner), 3, 9);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.miner), 2, 0);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.miner), 2, 1);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.miner), 2, 2);

            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.sergeant), 2, 3);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.sergeant), 2, 4);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.sergeant), 2, 5);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.sergeant), 2, 6);

            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.lieutenant), 2, 7);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.lieutenant), 2, 8);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.lieutenant), 2, 9);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.lieutenant), 1, 0);

            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.captain), 1, 1);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.captain), 1, 2);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.captain), 1, 3);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.captain), 1, 4);

            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.major), 1, 5);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.major), 1, 6);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.major), 1, 7);

            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.colonel), 1, 8);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.colonel), 1, 9);

            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.general), 0, 0);

            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), 0, 1);

            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.bomb), 0, 2);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.bomb), 0, 3);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.bomb), 0, 4);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.bomb), 0, 5);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.bomb), 0, 6);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.bomb), 0, 7);

            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.flag), 0, 8);

            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.spy), 0, 9);

            return b;
        }

        public static Board FromString(String board)
        {
            Board temp = new Board();
            String[] boardArray = board.Split('~');
            int count = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    String square = boardArray[count];
                    count++;

                    if (square == "Land")
                    {
                        temp.getCell(i, j).setTerrain(Cell.Terrain.Land);
                    }
                    else if (square == "Lake")
                    {
                        temp.getCell(i, j).setTerrain(Cell.Terrain.Lake);
                    }
                    else if (square == "flag red")
                    {
                        temp.placePiece(new Piece(Piece.Team.red, Piece.Rank.flag), i, j);
                    }
                    else if (square == "flag blue")
                    {
                        temp.placePiece(new Piece(Piece.Team.blue, Piece.Rank.flag), i, j);
                    }
                    else if (square == "spy red")
                    {
                        temp.placePiece(new Piece(Piece.Team.red, Piece.Rank.spy), i, j);
                    }
                    else if (square == "spy blue")
                    {
                        temp.placePiece(new Piece(Piece.Team.blue, Piece.Rank.spy), i, j);
                    }
                    else if (square == "scout red")
                    {
                        temp.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), i, j);
                    }
                    else if (square == "scout blue")
                    {
                        temp.placePiece(new Piece(Piece.Team.blue, Piece.Rank.scout), i, j);
                    }
                    else if (square == "miner red")
                    {
                        temp.placePiece(new Piece(Piece.Team.red, Piece.Rank.miner), i, j);
                    }
                    else if (square == "miner blue")
                    {
                        temp.placePiece(new Piece(Piece.Team.blue, Piece.Rank.miner), i, j);
                    }
                    else if (square == "sergeant red")
                    {
                        temp.placePiece(new Piece(Piece.Team.red, Piece.Rank.sergeant), i, j);
                    }
                    else if (square == "sergeant blue")
                    {
                        temp.placePiece(new Piece(Piece.Team.blue, Piece.Rank.sergeant), i, j);
                    }
                    else if (square == "lieutenant red")
                    {
                        temp.placePiece(new Piece(Piece.Team.red, Piece.Rank.lieutenant), i, j);
                    }
                    else if (square == "lieutenant blue")
                    {
                        temp.placePiece(new Piece(Piece.Team.blue, Piece.Rank.lieutenant), i, j);
                    }
                    else if (square == "captain red")
                    {
                        temp.placePiece(new Piece(Piece.Team.red, Piece.Rank.captain), i, j);
                    }
                    else if (square == "captain blue")
                    {
                        temp.placePiece(new Piece(Piece.Team.blue, Piece.Rank.captain), i, j);
                    }
                    else if (square == "major red")
                    {
                        temp.placePiece(new Piece(Piece.Team.red, Piece.Rank.major), i, j);
                    }
                    else if (square == "major blue")
                    {
                        temp.placePiece(new Piece(Piece.Team.blue, Piece.Rank.major), i, j);
                    }
                    else if (square == "colonel red")
                    {
                        temp.placePiece(new Piece(Piece.Team.red, Piece.Rank.colonel), i, j);
                    }
                    else if (square == "colonel blue")
                    {
                        temp.placePiece(new Piece(Piece.Team.blue, Piece.Rank.colonel), i, j);
                    }
                    else if (square == "general red")
                    {
                        temp.placePiece(new Piece(Piece.Team.red, Piece.Rank.general), i, j);
                    }
                    else if (square == "general blue")
                    {
                        temp.placePiece(new Piece(Piece.Team.blue, Piece.Rank.general), i, j);
                    }
                    else if (square == "marshal red")
                    {
                        temp.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), i, j);
                    }
                    else if (square == "marshal blue")
                    {
                        temp.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), i, j);
                    }
                    else if (square == "bomb red")
                    {
                        temp.placePiece(new Piece(Piece.Team.red, Piece.Rank.bomb), i, j);
                    }
                    else if (square == "bomb blue")
                    {
                        temp.placePiece(new Piece(Piece.Team.blue, Piece.Rank.bomb), i, j);
                    }
                }
            }

            return temp;
        }

        public override String ToString()
        {
            String board = "";
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (this.getPiece(i, j) != null)
                    {
                        String team = this.getPiece(i, j).getTeam().ToString().Substring(0,1).ToUpper();
                        String rank = ((int)this.getPiece(i,j).getRank()).ToString();

                        if (rank.Equals("-1"))
                            rank = "F";
                        board = board + team + rank + "~";
                    }
                    else
                    {
                        board = board + this.getCell(i, j).getTerrain().ToString() + "~";
                    }
                }
            }
            return board;
        }

        public void setBattleMode(BattleMode mode)
        {
            this.mode = mode;
        }

        public BattleMode GetBattleMode()
        {
            return this.mode;
        }

        public short getRedCount()
        {
            return this.redCount;
        }

        public short getBlueCount()
        {
            return this.blueCount;
        }

        public void placementPiece(Piece p, int v, int h)
        {
            if (this.getCell(v, h).getTerrain() == Cell.Terrain.Land & this.getCell(v, h).getPiece() == null)
                cells[v, h].setPiece(p);
            if (p != null)
            {
                if (p.getTeam() == Piece.Team.blue)
                {
                    this.blueCount++;
                }
                else
                {
                    this.redCount++;
                }
            }
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

        public bool isMoveValid(int x, int y, Direction dir, int dist)
        {
            Piece p = cells[y,x].getPiece();

            if (p == null)
                throw new ArgumentOutOfRangeException("The space being moved from must have a piece in it!");

            //edge of the board checks
            if (dir == Direction.N && y + dist > 9) return false;
            if (dir == Direction.E && x + dist > 9) return false;
            if (dir == Direction.S && y - dist < 0) return false;
            if (dir == Direction.W && x - dist < 0) return false;

            //rank checks
            if (p.getRank() == Piece.Rank.flag) return false;
            if (p.getRank() == Piece.Rank.bomb) return false;
            if(p.getRank() != Piece.Rank.scout && dist > 1) return false;

            //lake checks
            for (int i = 0; i <= dist; i++)
            {
                if (dir == Direction.N && cells[y + i, x].getTerrain() == Cell.Terrain.Lake) return false;
                if (dir == Direction.S && cells[y - i, x].getTerrain() == Cell.Terrain.Lake) return false;
                if (dir == Direction.E && cells[y, x + i].getTerrain() == Cell.Terrain.Lake) return false;
                if (dir == Direction.W && cells[y, x - i].getTerrain() == Cell.Terrain.Lake) return false;
            }

            //piece in the middle of the move checks
            if (dist > 1)
            {
                if (dir == Direction.N)
                {
                    for (int i = 1; i < dist; i++)
                       if (cells[y + i, x].getPiece() != null)
                           return false;
                }
                if (dir == Direction.S)
                {
                    for (int i = 1; i < dist; i++)
                       if (cells[y - i, x].getPiece() != null)
                           return false;
                }
                if (dir == Direction.E)
                {
                    for (int i = 1; i < dist; i++)
                       if (cells[y, x + i].getPiece() != null)
                           return false;
                }
                if (dir == Direction.W)
                {
                    for (int i = 1; i < dist; i++)
                       if (cells[y, x - i].getPiece() != null)
                           return false;
                }
            }

            //moving onto an ally checks
            int[] dest = Board.DestinationCalc(y, x, dir, dist);

            Piece destinationP = cells[dest[0], dest[1]].getPiece();
            if (destinationP != null)
                if (destinationP.getTeam() == p.getTeam())
                    return false;

            if (dist > 1 && destinationP != null)
                return false;

            return true;
        }

        public Event moveEvent(int y, int x, Direction dir, int dist)
        {
            if (!this.isMoveValid(x, y, dir, dist))
                return Event.BadMove;

            int[] dest = Board.DestinationCalc(y, x, dir, dist);
            Piece destPiece = cells[dest[0], dest[1]].getPiece();

            if (destPiece == null)
                return Event.GoodMove;

            if (destPiece.getRank() == Piece.Rank.flag)
                return Event.Flag;

            Piece currentPiece = cells[y, x].getPiece();

            if (dist > 1)
                return Event.BadMove;

            Piece.Combat battleResult = Piece.Battle(currentPiece, destPiece, this.mode);

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


        /// <summary>
        /// Gets a list of squares that the piece on the given square can move to.
        /// </summary>
        /// <param name="originCoordinates">The coordinates of the starting square</param>
        /// <returns>An array of all available moves. If there are none, will contain (-1,-1)</returns>
        public List<Point> GetAvailableMoves(Point originCoordinates)
        {
            List<Point> moves = new List<Point>();
            Point noMoves = new Point(-1, -1);
            
            short v = (short)originCoordinates.Y;
            short h = (short)originCoordinates.X;
            Piece p = this.getCell(v, h).getPiece();

            if (p == null)
                moves.Add(noMoves);
            else
            {
                Piece.Rank r = p.getRank();
                switch (r)
                {
                    case Piece.Rank.flag:
                        moves.Add(noMoves);
                        break;
                    case Piece.Rank.bomb:
                        moves.Add(noMoves);
                        break;
                    case Piece.Rank.scout:
                        //scout check
                        //N
                        int d = 1;
                        Boolean keepChecking = true;
                        while (keepChecking)
                        {
                            keepChecking = this.isMoveValid(h, v, Direction.N, d);
                            if (keepChecking)
                                moves.Add(new Point(h, v + d));
                            d++;
                        }                        
                        //E
                        d = 1;
                        keepChecking = true;
                        while (keepChecking)
                        {
                            keepChecking = this.isMoveValid(h, v, Direction.E, d);
                            if (keepChecking)
                                moves.Add(new Point(h + d, v));
                            d++;
                        }
                        //S
                        d = 1;
                        keepChecking = true;
                        while (keepChecking)
                        {
                            keepChecking = this.isMoveValid(h, v, Direction.S, d);
                            if (keepChecking)
                                moves.Add(new Point(h, v - d));
                            d++;
                        }
                        //W
                        d = 1;
                        keepChecking = true;
                        while (keepChecking)
                        {
                            keepChecking = this.isMoveValid(h, v, Direction.W, d);
                            if (keepChecking)
                                moves.Add(new Point(h - d, v));
                            d++;
                        }
                        break;
                    default:
                        //normal check
                        Boolean anyMoves = false;
                        if (this.isMoveValid(h, v, Direction.N, 1))
                        {
                            moves.Add(new Point(h, v + 1));
                            anyMoves = true;
                        }
                        if (this.isMoveValid(h, v, Direction.E, 1))
                        {
                            moves.Add(new Point(h + 1, v));
                            anyMoves = true;
                        }
                        if (this.isMoveValid(h, v, Direction.S, 1))
                        {
                            moves.Add(new Point(h, v - 1));
                            anyMoves = true;
                        }
                        if (this.isMoveValid(h, v, Direction.W, 1))
                        {
                            moves.Add(new Point(h - 1, v));
                            anyMoves = true;
                        }
                        if (!anyMoves)
                            moves.Add(noMoves);
                        break;
                }
            }
            return moves;
        }

    }
}
