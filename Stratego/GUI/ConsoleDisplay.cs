using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    /// <summary>
    /// The console version of the GUI. Handles input and output to/from the user.
    /// Controlled by GUIController.
    /// </summary>
    public class ConsoleDisplay
    {

        private static readonly String USER_PROMPT = "> ";
        private GUIController g;

        /// <summary>
        /// Constructor that takes a GUIController and writes a welcome message.
        /// </summary>
        /// <param name="g"></param>
        public ConsoleDisplay(GUIController g)
        {
            this.g = g;
            this.Welcome();
            //this.Prompt();
        }

        /// <summary>
        /// Starts the GUI by calling the User input method
        /// </summary>
        public void Start()
        {
            this.Prompt();
        }

        /// <summary>
        /// Outputs a welcome message and the help text
        /// </summary>
        private void Welcome()
        {
            String w = "Welcome to Stratego!";
            Console.WriteLine(w);
            this.Help();
        }

        /// <summary>
        /// Indicates the commands available
        /// </summary>
        private void Help()
        {
            String h = "Available commands are Hotseat, CreateNetwork, JoinNetwork, Settings, Exit, Move, Save, and Load.";
            Console.WriteLine(h);
        }

        /// <summary>
        /// The sole method of user input. Reads input and passes to a handler
        /// </summary>
        public void Prompt()
        {            
            Console.Write(USER_PROMPT);
            String input = Console.ReadLine();
            this.HandleInput(input);
        }

        /// <summary>
        /// Handles user input appropriately. In most cases, will call GUIcontroller, which
        /// will set its flags to indicate the occurence of user input.
        /// </summary>
        /// <param name="input">User input</param>
        private void HandleInput(String input)
        {
            if (this.g.HasUpdate())
            {
                String waitString = "Hold on, I'm still busy.";
                Console.WriteLine(waitString);
            }
            else
            {
                
                int space = input.IndexOf(" ");
                String command = input.ToUpper();
                String args = "";
                if (space > 0)
                {
                    command = command.Substring(0, space);
                    args = input.Substring(space+ 1);
                }
                switch (command)
                {
                    case "HOTSEAT":
                        this.g.HotSeatGamePress();
                        break;
                    case "CREATENETWORK":
                        this.g.CreateNetworkGamePress();
                        break;
                    case "JOINNETWORK":
                        this.g.JoinNetworkGamePress();
                        break;
                    case "SETTINGS":
                        this.g.SettingsPress();
                        break;
                    case "EXIT":
                        this.g.ExitPress();
                        break;
                    case "MOVE":
                        //get coords
                        //this.g.TilePress();
                        short[] coords = HandleMove(args);
                        if (coords == null)
                        {
                            String e = "Not enough args to move supplied (4 numbers with spaces in between).";
                            Console.WriteLine(e);
                            this.Prompt();
                            break;
                        }
                        Console.WriteLine("Trying to move from " + coords[1] + ", " + coords[0] + " to " + coords[3] + ", " + coords[2] + "...");
                        this.g.MoveAttempt(coords);
                        //throw new Exception("Move command not implemented.");
                        break;
                    case "SAVE":
                        //get filename
                        throw new Exception("Save command not implemented.");
                        break;
                    case "LOAD":
                        //get filename
                        throw new Exception("Load command not implemented.");
                        break;
                    case "HELP":
                        this.Help();
                        this.Prompt();
                        break;
                    default:
                        Console.WriteLine("That is not a recognized command!");
                        this.Prompt();
                        break;
                }
            }
        }

        /// <summary>
        /// Splits the user input from the move command to get the
        /// coordinates from it
        /// </summary>
        /// <param name="args">User-input coordinates</param>
        /// <returns>Coordinates in array form</returns>
        private short[] HandleMove(String args)
        {
            String[] splitArgs = args.Split(' ');
            if (splitArgs.Length != 4)
                return null;
            return new short[4] { Convert.ToInt16(splitArgs[1]), Convert.ToInt16(splitArgs[0]), Convert.ToInt16(splitArgs[3]), Convert.ToInt16(splitArgs[2]) };
        }

        /// <summary>
        /// Displays the given board
        /// </summary>
        /// <param name="board">board to display</param>
        public void UpdateBoard(String board)
        {
            String[] displayBoard = board.Split('~');

            int boardWidth = 42;

            for (int i = 0; i < boardWidth; i++)
                Console.Write("*");

            Console.WriteLine();

            for (int v = 9; v > -1; v--)
            {
                Console.Write(v + ": ");
                for (int h = 0; h < 10; h++)
                {
                    String actual = displayBoard[(v * 10) + h];
                    String tile = "??";
                    if (actual.Equals("Land"))
                        tile = "--";
                    else if (actual.Equals("Lake"))
                        tile = "WW";
                    //else if (actual.Substring(0, 1).Equals("b"))
                    //    tile = "B" + actual.Substring(0, ;
                    //else if (actual.Substring(0, 1).Equals("r"))
                    //    tile = "RR";
                    else
                        tile = actual;
                    Console.Write(tile + "  ");
                }
                Console.WriteLine();
            }

            Console.Write("    ");

            for (int h = 0; h < 10; h++)
                Console.Write(h + "   ");

            Console.WriteLine();


            for (int i = 0; i < boardWidth; i++)
                Console.Write("*");

            Console.WriteLine();

            //Console.WriteLine(board);
        }

        /// <summary>
        /// Displays that the current turn belongs to the given player
        /// </summary>
        /// <param name="player">Player whose turn it is</param>
        public void UpdatePlayer(String player)
        {
            String t = "It is " + player + " player's turn.";
            Console.WriteLine(t);
        }

        /// <summary>
        /// Indicates to the user that the given move is invalid
        /// </summary>
        public void MoveFailed()
        {
            String f = "That is not a valid move!";
            Console.WriteLine(f);
        }

        /// <summary>
        /// Indicates to the user that the given player has won the game.
        /// </summary>
        /// <param name="player">Player who won</param>
        public void GameOver(String player)
        {
            String o = "The game is over! " + player + " player has won!";
            Console.WriteLine(o);
        }
    }
}
