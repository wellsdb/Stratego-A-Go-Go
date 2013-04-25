using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Stratego
{
    public class Game
    {
        private Board board;
        private Player playerOne;
        private Player playerTwo;
        private Int16 turnCount;
        private Piece.Team currentTeam;

        public Game()
        {
            this.board = new Board();
            this.playerOne = new Player();
            this.playerTwo = new Player();
            this.turnCount = 0;
            this.currentTeam = Piece.Team.none;
        }

        public Game(Board board)
        {
            this.board = board;
            this.playerOne = new Player();
            this.playerTwo = new Player();
            this.turnCount = 0;
            this.currentTeam = Piece.Team.none;
        }

        public Board getBoard()
        {
            return this.board;
        }

        public void setBoard(Board board)
        {
            this.board = board;
        }

        public String getPlayerName(Int16 player)
        {
            if (player == 1)
                return this.playerOne.getName();
            if (player == 2)
                return this.playerTwo.getName();
            throw new ArgumentOutOfRangeException("Player does not exist!");
        }

        public Int16 getPlayerPieceCount(Int16 player)
        {
            if (player == 1)
                return this.playerOne.getPieceCount();
            if (player == 2)
                return this.playerTwo.getPieceCount();
            throw new ArgumentOutOfRangeException("Player does not exist!");
        }

        public void setPlayerName(Int16 player, String name)
        {
            if (player == 1)
                this.playerOne.setName(name);
            else if (player == 2)
                this.playerTwo.setName(name);
            else throw new ArgumentOutOfRangeException("Player does not exist!");
        }

        public Int16 getTurnCount()
        {
            return this.turnCount;
        }

        public void setTurnCount(Int16 count)
        {
            this.turnCount = count;
        }

        public Piece.Team getCurrentTurn()
        {
            return this.currentTeam;
        }

        public void setCurrentTurn(Piece.Team current)
        {
            this.currentTeam = current;
        }

        public void startGame()
        {
            this.turnCount = 1;
            this.currentTeam = Piece.Team.red;
        }

        //returns true if the move is allowed and performed
        //returns false if the move is not allowed and not performed
        public Boolean[] movePiece(Int16 v, Int16 h, Board.Direction direction, Int16 distance)
        {

            Piece movingPiece = this.board.getPiece(v, h);

            // check if a piece exists in the given cell
            if (movingPiece == null)
                return new Boolean[2] {false, false};

            // check if the piece belongs to the current player
            if (movingPiece.getTeam() != this.currentTeam)
                return new Boolean[2] {false, false};

            // check if move is valid
            Boolean valid = this.board.isMoveValid(v, h, direction, distance);

            //if move is invalid, return false
            if (!valid)
                return new Boolean[2] { false, false };

            // move is valid
            // get the effect of the move
            Board.Event moveEvent = this.board.moveEvent(v, h, direction, distance);

            //place an empty piece on the old cell
            this.board.placePiece(null, v, h);

            // get the new space's coordinates
            int[] destination = Board.DestinationCalc(v, h, direction, distance);

            switch (moveEvent)
            {
                case Board.Event.GoodMove:
                    // place the piece
                    this.board.placePiece(movingPiece, destination[0], destination[1]);
                    break;

                case Board.Event.Win:
                    // adjust piece count
                    if (this.currentTeam == Piece.Team.red)
                        this.playerTwo.removePiece();
                    else
                        this.playerOne.removePiece();

                    // place the piece
                    this.board.placePiece(movingPiece, destination[0], destination[1]);
                    break;

                case Board.Event.Loss:
                    // adjust piece count
                    if (this.currentTeam == Piece.Team.red)
                        this.playerOne.removePiece();
                    else
                        this.playerTwo.removePiece();
                    break;

                case Board.Event.Tie:
                    // adjust piece count
                    this.playerOne.removePiece();
                    this.playerTwo.removePiece();

                    // remove both pieces
                    this.board.placePiece(null, destination[0], destination[1]);
                    break;

                case Board.Event.Flag:
                    // place the piece
                    this.board.placePiece(movingPiece, destination[0], destination[1]);
                    return new Boolean[2] {true, true};
            }

            this.swapTurn();
            return new Boolean[2] { true, false };
        }
        
        private void swapTurn()
        {
            if (this.currentTeam == Piece.Team.red)
                this.currentTeam = Piece.Team.blue;
            else
            {
                this.currentTeam = Piece.Team.red;
                this.turnCount++;
            }
        }
        public void saveFile(String fileName)
        {
            StreamWriter file = new StreamWriter(fileName);
            //Basic stuff, turn count etc.
            file.WriteLine(this.getTurnCount());
            file.WriteLine(this.getCurrentTurn().ToString());

            //Player One info
            file.WriteLine(this.getPlayerName(1));
            //Player Two info
            file.WriteLine(this.getPlayerName(2));
            //Board info
            Board board = this.getBoard();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (board.getPiece(i, j) != null)
                    {
                        file.WriteLine(board.getPiece(i, j).getRank().ToString() + board.getPiece(i, j).getTeam().ToString());
                    }
                    else
                    {
                        file.WriteLine(board.getCell(i, j).getTerrain().ToString());
                    }

                }

            }

            file.Close();
        }

        public void loadFile(String fileName)
        {
            StreamReader file = null;
            try
            {
                file = new StreamReader(fileName);
                this.setTurnCount(short.Parse(file.ReadLine()));
                String current = file.ReadLine();
                if (current == "red")
                {
                    this.setCurrentTurn(Piece.Team.red);
                }
                else if (current == "blue")
                {
                    this.setCurrentTurn(Piece.Team.blue);
                }
                else
                {
                    this.setCurrentTurn(Piece.Team.none);
                }

                this.setPlayerName(1, file.ReadLine());
                this.setPlayerName(2, file.ReadLine());

                Board temp = new Board();
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        String square = file.ReadLine();

                        if (square == "Land")
                        {
                            temp.getCell(i, j).setTerrain(Cell.Terrain.Land);
                        }
                        else if (square == "Lake")
                        {
                            temp.getCell(i, j).setTerrain(Cell.Terrain.Land);
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

                this.setBoard(temp);

            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException("Yeah something's up here", e);
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
        }
        
    }
}
