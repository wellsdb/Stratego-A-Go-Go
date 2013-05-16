using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace Stratego
{
    //Represents a game of Stratego. Has a Board and a pair of Players. Attempts moves and tracks game state. Also contains loading and saving methods.
    public class Game
    {
        
        private Board board;
        private Player playerOne;
        private Player playerTwo;
        private Int16 turnCount;
        private Piece.Team currentTeam;
        private Boolean active;
        private Boolean gameOver;
        private Point[] revealedPieces;

        //Creates a Game with default values
        public Game()
        {
            this.board = new Board();
            this.playerOne = new Player();
            this.playerTwo = new Player();
            this.turnCount = 0;
            this.currentTeam = Piece.Team.none;
            this.active = false;
        }

        //Creates a Game with a given Board
        public Game(Board board)
        {
            this.board = board;
            this.playerOne = new Player();
            this.playerTwo = new Player();
            this.turnCount = 0;
            this.currentTeam = Piece.Team.none;
            this.active = false;
        }
        
        //Gets this Game's board
        public Board getBoard()
        {
            return this.board;
        }

        //Sets this Game's board
        public void setBoard(Board board)
        {
            this.board = board;
        }

        //Gets the name of the indicated player
        public String getPlayerName(Int16 player)
        {
            if (player == 1)
                return this.playerOne.getName();
            if (player == 2)
                return this.playerTwo.getName();
            throw new ArgumentOutOfRangeException("Player does not exist!");
        }

        //Gets the number of pieces that the indicated player still has in play
        public Int16 getPlayerPieceCount(Int16 player)
        {
            if (player == 1)
                return this.playerOne.getPieceCount();
            if (player == 2)
                return this.playerTwo.getPieceCount();
            throw new ArgumentOutOfRangeException("Player does not exist!");
        }

        //Sets the name of the indicated player to the given value
        public void setPlayerName(Int16 player, String name)
        {
            if (player == 1)
                this.playerOne.setName(name);
            else if (player == 2)
                this.playerTwo.setName(name);
            else throw new ArgumentOutOfRangeException("Player does not exist!");
        }

        //Gets the number of turns that have passed in the given game
        public Int16 getTurnCount()
        {
            return this.turnCount;
        }

        //Sets the number of turns that have passed in the given game
        public void setTurnCount(Int16 count)
        {
            this.turnCount = count;
        }

        //Gets the name of the team who is in control of the current turn
        public Piece.Team getCurrentTurn()
        {
            return this.currentTeam;
        }

        //Sets control of the current turn to the given player
        public void setCurrentTurn(Piece.Team current)
        {
            this.currentTeam = current;
        }

        //Starts the game by setting the turnCount to 1, setting the player in control of the turn to Red, and setting the active field to true.
        public void startGame()
        {
            this.turnCount = 1;
            this.currentTeam = Piece.Team.red;
            this.active = true;
            this.revealedPieces = new Point[] { new Point(-1, -1), new Point(-1, -1) };
        }
        
        //Attempts to perform a move and returns a Boolean array indicating the result.
        //If the move is not valid, then it is not performed and the array contains false.
        //If the move is valid, then it is performed, and the array contains true and another value.
        //If the move is valid and results in the capturing of the enemy flag, then the other value is true. Otherwise, it is false.
        //TODO: assign victory condition checking to another method.
        public Boolean[] movePiece(Int16 v, Int16 h, Board.Direction direction, Int16 distance)
        {
            if (!this.active)
                return new Boolean[2] {false, false};

            Piece movingPiece = this.board.getPiece(v, h);

            // check if a piece exists in the given cell
            if (movingPiece == null)
                return new Boolean[2] {false, false};

            // check if the piece belongs to the current player
            if (movingPiece.getTeam() != this.currentTeam)
                return new Boolean[2] {false, false};

            // check if move is valid
            Boolean valid = this.board.isMoveValid(h, v, direction, distance);

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
                    this.revealedPieces[1] = this.revealedPieces[0];
                    this.revealedPieces[0] = new Point(-1, -1);
                    break;

                case Board.Event.Win:
                    // adjust piece count
                    if (this.currentTeam == Piece.Team.red)
                        this.playerTwo.removePiece();
                    else
                        this.playerOne.removePiece();

                    // place the piece
                    this.board.placePiece(movingPiece, destination[0], destination[1]);
                    
                    //  reveal the piece
                    this.revealedPieces[1] = this.revealedPieces[0];
                    this.revealedPieces[0] = new Point(destination[1], destination[0]);

                    break;

                case Board.Event.Loss:
                    // adjust piece count
                    if (this.currentTeam == Piece.Team.red)
                        this.playerOne.removePiece();
                    else
                        this.playerTwo.removePiece();

                    //reveal the piece//  reveal the piece
                    this.revealedPieces[1] = this.revealedPieces[0];
                    this.revealedPieces[0] = new Point(destination[1], destination[0]);

                    break;

                case Board.Event.Tie:
                    // adjust piece count
                    this.playerOne.removePiece();
                    this.playerTwo.removePiece();

                    // remove both pieces
                    this.board.placePiece(null, destination[0], destination[1]);

                    //  reveal the piece
                    this.revealedPieces[1] = this.revealedPieces[0];
                    this.revealedPieces[0] = new Point(-1, -1);

                    break;

                case Board.Event.Flag:
                    // place the piece
                    this.board.placePiece(movingPiece, destination[0], destination[1]);
                    this.active = false;
                    return new Boolean[2] {true, true};
            }

            this.swapTurn();
            return new Boolean[2] { true, false };
        }
        
        //Sets the current turn to the other player and if appropriate, increments the turncount
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



        public String toString()
        {
            String ret = "";

            ret += this.getTurnCount() + " ";
            ret += this.getCurrentTurn().ToString() + " ";

            //Player One info
            ret += this.getPlayerName(1) + " ";
            //Player Two info
            ret+= this.getPlayerName(2) + " ";
            //Board info
            Board board = this.getBoard();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (board.getPiece(i, j) != null)
                    {
                        ret+= board.getPiece(i, j).getRank().ToString() + board.getPiece(i, j).getTeam().ToString();
                    }
                    else
                    {
                        ret += board.getCell(i, j).getTerrain().ToString();
                    }
                    ret += " ";
                }

            }
            Console.WriteLine(ret);
            return ret;
        }
        //Converts the current game to a string and saves it as a text file.
        //TODO: split method into a ToString method and a Save method
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

        public void fromString(String load)
        {
            short index = 0;
            String[] loaded = load.Split();

            this.setTurnCount(short.Parse(loaded[index]));
            index++;
            String current = loaded[index];
            index++;
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

            this.setPlayerName(1, loaded[index]);
            index++;
            this.setPlayerName(2, loaded[index]);
            index++;

            Board temp = new Board();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    String square = loaded[index];
                    index++;

                    if (square == "Land")
                    {
                        temp.getCell(i, j).setTerrain(Cell.Terrain.Land);
                    }
                    else if (square == "Lake")
                    {
                        temp.getCell(i, j).setTerrain(Cell.Terrain.Lake);
                    }
                    else if (square == "flagred")
                    {
                        temp.placePiece(new Piece(Piece.Team.red, Piece.Rank.flag), i, j);
                    }
                    else if (square == "flagblue")
                    {
                        temp.placePiece(new Piece(Piece.Team.blue, Piece.Rank.flag), i, j);
                    }
                    else if (square == "spyred")
                    {
                        temp.placePiece(new Piece(Piece.Team.red, Piece.Rank.spy), i, j);
                    }
                    else if (square == "spyblue")
                    {
                        temp.placePiece(new Piece(Piece.Team.blue, Piece.Rank.spy), i, j);
                    }
                    else if (square == "scoutred")
                    {
                        temp.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), i, j);
                    }
                    else if (square == "scoutblue")
                    {
                        temp.placePiece(new Piece(Piece.Team.blue, Piece.Rank.scout), i, j);
                    }
                    else if (square == "minerred")
                    {
                        temp.placePiece(new Piece(Piece.Team.red, Piece.Rank.miner), i, j);
                    }
                    else if (square == "minerblue")
                    {
                        temp.placePiece(new Piece(Piece.Team.blue, Piece.Rank.miner), i, j);
                    }
                    else if (square == "sergeantred")
                    {
                        temp.placePiece(new Piece(Piece.Team.red, Piece.Rank.sergeant), i, j);
                    }
                    else if (square == "sergeantblue")
                    {
                        temp.placePiece(new Piece(Piece.Team.blue, Piece.Rank.sergeant), i, j);
                    }
                    else if (square == "lieutenantred")
                    {
                        temp.placePiece(new Piece(Piece.Team.red, Piece.Rank.lieutenant), i, j);
                    }
                    else if (square == "lieutenantblue")
                    {
                        temp.placePiece(new Piece(Piece.Team.blue, Piece.Rank.lieutenant), i, j);
                    }
                    else if (square == "captainred")
                    {
                        temp.placePiece(new Piece(Piece.Team.red, Piece.Rank.captain), i, j);
                    }
                    else if (square == "captainblue")
                    {
                        temp.placePiece(new Piece(Piece.Team.blue, Piece.Rank.captain), i, j);
                    }
                    else if (square == "majorred")
                    {
                        temp.placePiece(new Piece(Piece.Team.red, Piece.Rank.major), i, j);
                    }
                    else if (square == "majorblue")
                    {
                        temp.placePiece(new Piece(Piece.Team.blue, Piece.Rank.major), i, j);
                    }
                    else if (square == "colonelred")
                    {
                        temp.placePiece(new Piece(Piece.Team.red, Piece.Rank.colonel), i, j);
                    }
                    else if (square == "colonelblue")
                    {
                        temp.placePiece(new Piece(Piece.Team.blue, Piece.Rank.colonel), i, j);
                    }
                    else if (square == "generalred")
                    {
                        temp.placePiece(new Piece(Piece.Team.red, Piece.Rank.general), i, j);
                    }
                    else if (square == "generalblue")
                    {
                        temp.placePiece(new Piece(Piece.Team.blue, Piece.Rank.general), i, j);
                    }
                    else if (square == "marshalred")
                    {
                        temp.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), i, j);
                    }
                    else if (square == "marshalblue")
                    {
                        temp.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), i, j);
                    }
                    else if (square == "bombred")
                    {
                        temp.placePiece(new Piece(Piece.Team.red, Piece.Rank.bomb), i, j);
                    }
                    else if (square == "bombblue")
                    {
                        temp.placePiece(new Piece(Piece.Team.blue, Piece.Rank.bomb), i, j);
                    }
                }
            }

            this.setBoard(temp);



        }

        //Reads a text file and implements its information into the current game.
        //TODO: split method into a FromString method and a Load method
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

        public Point[] GetRevealedPieces()
        {
            return this.revealedPieces;
        }

        public void SetRevealedPieces(Point[] coords)
        {
            this.revealedPieces = coords;
        }

        //private void VerifyGameOver()
        //{
        //    //if (!this.playerOne.HasFlag())
        //    //{
        //    //    this.gameOver = true;
        //    //    this.winner = this.playerTwo.GetTeam();
        //    //}
        //    //else if (!this.playerTwo.HasFlag())
        //    //{
        //    //    this.gameOver = true;
        //    //    this.winner = this.playerOne.GetTeam();
        //    //}
        //    //else if (!this.playerOne.HasMoveable())
        //    //{
        //    //    this.gameOver = true;
        //    //    this.winner = this.playerTwo.GetTeam();
        //    //}
        //    //else if (!this.playerTwo.HasMoveable())
        //    //{
        //    //    this.gameOver = true;
        //    //    this.winner = this.playerOne.GetTeam();
        //    //}
        //}
    }
}
