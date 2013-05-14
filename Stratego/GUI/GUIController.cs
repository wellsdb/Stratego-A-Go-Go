using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace GUI
{
    /// <summary>
    /// Main control for the GUI. Has a specific gui (window or console) that it manipulates.
    /// This class serves to transfer information between the gui and the main control class.
    /// It directs the gui to update, and uses flags to indicate to the main control that there
    /// is user input.
    /// </summary>
    public class GUIController
    {
        public enum UserInput { Hotseat, CreateNetwork, JoinNetwork, Settings, Exit, Tile, Move, Save, Load, RussianMode, Editor, Colorblind, Easy, SpanishLanguage };
        public enum DisplayMode { Console, Window };
        private View view;
        private ConsoleDisplay display;
        private Boolean hasUpdate;
        private UserInput ui;
        private short[] singleCoords;
        private short[] doubleCoords;
        private DisplayMode mode;
        private String player;
        private Boolean attempt;
        private Stratego.Game game;
        private Stratego.Board board;
        private Boolean gameOver;
        //private Boolean toBeUpdated = false;

        /// <summary>
        /// Here because otherwise Visual Studio will complain 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(String[] args)
        {

        }

        /// <summary>
        /// Constructor which creates a gui according to the specificed value (window
        /// or console). Currently only supports console.
        /// </summary>
        /// <param name="mode"></param>
        public GUIController(DisplayMode mode, Stratego.Game game)
        {
            this.mode = mode;
            
            if (mode == DisplayMode.Console)
            {
                this.display = new ConsoleDisplay(this);
            }
            else if (mode == DisplayMode.Window)
            {
                //PassiveView v = new PassiveView();
                //Thread ShowThread = new Thread(new ThreadStart (show));
                //v.Show();
                //v.Visible = true;
                //v.Activate();
                this.game = game;
                this.board = game.getBoard();
                this.view = new View(this);
                Thread ShowViewThread = new Thread(new ThreadStart(ShowView));
                ShowViewThread.Start();

                //throw new Exception("Window display mode not yet covered.");
            }
            else
                throw new Exception("Bad display mode");
        }

        private void ShowView()
        {
            Application.Run(this.view);
        }
        
        /// <summary>
        /// Directs the GUI to update itself by refreshing its display
        /// of the board, current player, and if applicable, game winner.
        /// </summary>
        public void Update()
        {
            if (this.gameOver)
                  this.display.GameOver(this.player);
             else
                 this.display.UpdatePlayer(this.player);            
            this.display.Prompt();
        }

        public Stratego.Game GetGame()
        {
            return this.game;
        }

        public Stratego.Board getBoard()
        {
            return this.board;
        }

        /// <summary>
        /// Starts the display
        /// </summary>
        public void Start()
        {
            this.display.Start();
        }

        /// <summary>
        /// Sets the displayed board to the given value. It will be displayed by
        /// the gui.
        /// </summary>
        /// <param name="board">String representation of board to be displayed</param>
        public void SetBoard(String board)
        {
            this.board = Stratego.Board.FromString(board);
        }
        
        /// <summary>
        /// Sets the displayed current player to the given value. It will be
        /// displayed by the GUI.
        /// </summary>
        /// <param name="player">Player to display for the current turn</param>
        public void SetPlayer(String player)
        {
            this.player = player;
        }

        /// <summary>
        /// Records whether the last move attempt succeeded or failed. The gui
        /// will update appropriately.
        /// </summary>
        /// <param name="attempt">Move succeeded or failed</param>
        public void SetAttempt(Boolean attempt)
        {
            this.attempt = attempt;
        }

        /// <summary>
        /// Records whether the game is over. THe gui will update appropriatly
        /// </summary>
        /// <param name="gameOver">Game over or not</param>
        public void SetGameOver(Boolean gameOver)
        {
            this.gameOver = gameOver;
        }

        /// <summary>
        /// Performs an update operation based on the last user input.
        /// Then resets the update flag, now ready to recieve a new input.
        /// </summary>
        public void ResetUpdate()
        {
            if (this.hasUpdate)
            {
                switch (this.ui)
                {
                    case UserInput.Hotseat:
                        //this.display.UpdateBoard(this.board);
                        this.display.UpdatePlayer(this.player);
                        break;
                    case UserInput.CreateNetwork:
                     //   this.display.UpdateBoard(this.board);
                        this.display.UpdatePlayer(this.player);
                        break;
                    case UserInput.JoinNetwork:
                      //  this.display.UpdateBoard(this.board);
                        this.display.UpdatePlayer(this.player);
                        break;
                    case UserInput.Settings:
                        break;
                    case UserInput.Exit:
                        break;
                    case UserInput.Tile:
                        break;
                    case UserInput.Move:
                        if (this.attempt)
                        {
                    //        this.display.UpdateBoard(this.board);
                            if (this.gameOver)
                                this.display.GameOver(this.player);
                            else
                                this.display.UpdatePlayer(this.player);
                        }
                        else                        
                            this.display.MoveFailed();
                        this.hasUpdate = false;
                        break;
                    case UserInput.Save:
                        break;
                    case UserInput.Load:
                        break;
                    case UserInput.RussianMode:
                        //do something
                        //tell it to repaint
                        break;
                    
                    case UserInput.Editor:

                        break;

                    case UserInput.Colorblind:

                        break;
                    case UserInput.Easy:

                        break;
                    case UserInput.SpanishLanguage:

                        break;
                    default:
                        throw new Exception("GUIController reseting bad input type.");
                }
                this.hasUpdate = false;
                new Thread(new ThreadStart(this.display.Prompt)).Start();
            }
            //this.ui = -1;
        }

        /// <summary>
        /// Returns true if there is user input that needs to be handled
        /// </summary>
        /// <returns>true if has input</returns>
        public bool HasUpdate()
        {
            return this.hasUpdate;
        }

        /// <summary>
        /// Returns the last type of user input used
        /// </summary>
        /// <returns>Type of user input</returns>
        public UserInput GetInput()
        {
            return this.ui;
        }

        /// <summary>
        /// Returns the last pair of coordinates to be entered by the user
        /// </summary>
        /// <returns>Pair of coordinates</returns>
        public short[] GetDoubleCoords()
        {
            return this.doubleCoords;
        }

        /// <summary>
        /// Handles the user calling a hotseat game
        /// </summary>
        public void HotSeatGamePress()
        {
            if (!this.hasUpdate)
            {
                this.ui = UserInput.Hotseat;
                this.hasUpdate = true;
            }
        }

        /// <summary>
        /// Handles the user creating a network game
        /// </summary>
        public void CreateNetworkGamePress()
        {
            if (!this.hasUpdate)
            {
                this.ui = UserInput.CreateNetwork;
                this.hasUpdate = true;
            }
        }

        /// <summary>
        /// Handles the user joining a network game
        /// </summary>
        public void JoinNetworkGamePress()
        {
            if (!this.hasUpdate)
            {
                this.ui = UserInput.JoinNetwork;
                this.hasUpdate = true;
            }
        }

        /// <summary>
        /// Handles the user calling the settings
        /// </summary>
        public void SettingsPress()
        {
            if (!this.hasUpdate)
            {
                this.ui = UserInput.Settings;
                this.hasUpdate = true;
            }
        }

        /// <summary>
        /// Handles the user calling exit
        /// </summary>
        public void ExitPress()
        {
            if (!this.hasUpdate)
            {
                this.ui = UserInput.Exit;
                this.hasUpdate = true;
            }
        }

        /// <summary>
        /// Handles the user selecting a tile from the board
        /// </summary>
        public void TilePress(short v, short h)
        {
            if (!this.hasUpdate)
            {
                this.ui = UserInput.Tile;
                this.singleCoords = new short[2] {v , h};
                this.hasUpdate = true;
            }
        }

        /// <summary>
        /// Handles the user attempting to perform a move
        /// </summary>
        public void MoveAttempt(short[] coords)
        {
            if (!this.hasUpdate)
            {
                this.ui = UserInput.Move;
                this.doubleCoords = coords;
                this.hasUpdate = true;
            }
        }

        /// <summary>
        /// Handles the user saving a game
        /// </summary>
        public void SaveGamePress(String name)
        {
            if (!this.hasUpdate)
            {
                this.ui = UserInput.Save;
                this.hasUpdate = true;
            }
        }

        /// <summary>
        /// Handles the user loading a game
        /// </summary>
        public void LoadGamePress()
        {
            if (!this.hasUpdate)
            {
                this.ui = UserInput.Load;
                this.hasUpdate = true;
            }
        }

        /// <summary>
        /// Toggles RussianRevolutioMod
        /// </summary>
        public void RussianPress()
        {
            if (!this.hasUpdate)
            {
                this.ui = UserInput.RussianMode;
                this.hasUpdate = true;
            }
        }

    }
}
