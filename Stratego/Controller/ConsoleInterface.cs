using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stratego;

namespace Controller
{
    class ConsoleInterface
    {

        public static void NotMain(String[] args)
        {

            Console.WriteLine("Welcome to Stratego!");
            Console.WriteLine("Starting a Two Player Hotseat Game!");

            Game game = new Game();

            
            Int16 redV = 1;
            Int16 redH = 8;
            Int16 blueV = 8;
            Int16 blueH = 1;

            //Set-up
            Piece RedScout = new Piece(Piece.Team.red, Piece.Rank.scout);
            Piece BlueScout = new Piece(Piece.Team.blue, Piece.Rank.scout);
            Piece RedFlag = new Piece(Piece.Team.red, Piece.Rank.flag);
            Piece BlueFlag = new Piece(Piece.Team.blue, Piece.Rank.flag);

            Board board = game.getBoard();

            board.placePiece(RedScout, redV, redH);
            board.placePiece(BlueScout, blueV, blueH);
            board.placePiece(RedFlag, 1, 1);
            board.placePiece(BlueFlag, 8, 8);

            ConsoleInterface.printBoard(game.getBoard());

            game.startGame();
            Boolean over = false;


            while (!over)
            {
                Piece.Team currentPlayer = game.getCurrentTurn();
                
                Int16 newV;
                Int16 newH;

                if (currentPlayer == Piece.Team.red)
                {
                    Console.WriteLine("Red player, it is your turn.\nWhich direction would you like to move?");
                    newV = redV;
                    newH = redH;
                }
                else
                {
                    Console.WriteLine("Blue player, it is your turn.\nWhich direction would you like to move?");
                    newV = blueV;
                    newH = blueH;
                }

                Console.Write(">");
                String direction = Console.ReadLine().ToUpper();
                Board.Direction dir =  Board.Direction.W;

                Console.WriteLine("How far would you like to move?");
                Console.Write(">");
                Int16 distance = Convert.ToInt16(Console.ReadLine());

                switch (direction)
                {
                    case "N":
                        dir = Board.Direction.N;
                        newV += distance;
                        break;
                    case "E":
                        dir = Board.Direction.E;
                        newH += distance;
                        break;
                    case "S":
                        dir = Board.Direction.S;
                        newV -= distance;
                        break;
                    case "W":
                        dir = Board.Direction.W;
                        newH -= distance;
                        break;
                    default:
                        throw new ArgumentException();
                }

                Boolean[] movement;

                if (currentPlayer == Piece.Team.red)
                    movement = game.movePiece(redV, redH, dir, distance);
                else
                    movement = game.movePiece(blueV, blueH, dir, distance);

                if (movement[1])
                    over = true;

                if (!movement[0])
                    Console.WriteLine("You can't move there!");
                else
                {
                    if (currentPlayer == Piece.Team.red)
                    {
                        redH = newH;
                        redV = newV;
                    }
                    else
                    {
                        blueH = newH;
                        blueV = newV;
                    }

                    ConsoleInterface.printBoard(board);

                }

            }
            Console.WriteLine("Game Over!");

            if (game.getCurrentTurn() == Piece.Team.red)
                Console.WriteLine("Red Player Wins!");
            else
                Console.WriteLine("Blue Player Wins!");

            Console.WriteLine("The end.");
            Console.ReadLine();
        }

        private static void printBoard(Board board)
        {
            for (int v = 9; v > -1 ; v--)
            {
                for (int h = 0; h < 10; h++)
                {
                    if(board.getCell(v, h).getTerrain().Equals(Cell.Terrain.Lake))
                        Console.Write(" WW ");
                    else 
                    {
                        Piece piece = board.getPiece(v, h);
                        if (piece == null)
                            Console.Write(" -- ");
                        else
                           Console.Write(" " + board.getPiece(v, h).toString() + " ");
                    }
                }
                Console.WriteLine();
            }
        }

    }
}

