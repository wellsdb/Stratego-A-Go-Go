using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stratego;

namespace SimpleConsoleInterface
{
    class ConsoleInterface
    {

        public static void Main(String[] args)
        {

            Console.WriteLine("Welcome to Stratego!");
            Console.WriteLine("Starting a Two Player Hotseat Game!");

            Game game = new Game();

            
            Int16 redV = 1;
            Int16 redH = 8;
            Int16 blueV = 8;
            Int16 blueH = 1;

            //Set-up
            Piece RedScout = new Piece(1, 2);
            Piece BlueScout = new Piece(2, 2);
            Piece RedFlag = new Piece(1, 0);
            Piece BlueFlag = new Piece(2, 0);

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
                int currentPlayer = game.getCurrentTurn();
                
                Int16 newV;
                Int16 newH;

                if (currentPlayer == 1)
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
                Board.dir dir =  Board.dir.W;

                Console.WriteLine("How far would you like to move?");
                Console.Write(">");
                Int16 distance = Convert.ToInt16(Console.ReadLine());

                switch (direction)
                {
                    case "N":
                        dir = Board.dir.N;
                        newV += distance;
                        break;
                    case "E":
                        dir = Board.dir.E;
                        newH += distance;
                        break;
                    case "S":
                        dir = Board.dir.S;
                        newV -= distance;
                        break;
                    case "W":
                        dir = Board.dir.W;
                        newH -= distance;
                        break;
                    default:
                        throw new ArgumentException();
                }

                Boolean[] movement;

                if (currentPlayer == 1)
                    movement = game.movePiece(1, redV, redH, dir, distance);
                else
                    movement = game.movePiece(2, blueV, blueH, dir, distance);

                if (movement[1])
                    over = true;

                if (!movement[0])
                    Console.WriteLine("You can't move there!");
                else
                {
                    if (currentPlayer == 1)
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

            if (game.getCurrentTurn() == 1)
                Console.WriteLine("Red Player Wins!");
            else
                Console.WriteLine("Blue Player Wins!");

            Console.WriteLine("the end");
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
                        Piece piece = board.getSpace(v, h);
                        if (piece == null)
                            Console.Write(" -- ");
                        else
                           Console.Write(" " + board.getSpace(v, h).toString() + " ");
                    }
                }
                Console.WriteLine();
            }
        }

    }
}

