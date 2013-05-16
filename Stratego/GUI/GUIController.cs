using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Stratego;
using System.Drawing;

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
        public enum UserInput { QuickHotseat, CustomHotseat, CreateQuickNetwork, CreateCustomNetwork, JoinNetwork, Settings, Exit, Tile, Move, Save, Load, RussianMode, Editor, Colorblind, Easy, SpanishLanguage, QuitGame };
        public enum DisplayMode { Console, Window };
        private View view;
        private ConsoleDisplay display;
        private FrontEnd frontend;
        private Boolean hasUpdate;
        private UserInput ui;
        private short[] singleCoords;
        private short[] doubleCoords;
        private short[] selection;
        private DisplayMode mode;
        private String playerName;
        private Piece.Team playerTeam;
        private Piece.Team ownerTeam;
        private GameController.GameType gameType;
        private Boolean attempt;
        //private Stratego.Game game;
        private Stratego.Board board;
        private String boardString;
        private Boolean gameOver;
        private List<Point> availableMoves;
        private String ip;
        private Point revealedPiece;
        private String saveLoad;
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
        public GUIController(DisplayMode mode)
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
                this.view = new View(this);
                Thread ShowViewThread = new Thread(new ThreadStart(ShowView));
                ShowViewThread.Start();
            }
            else
                throw new Exception("Bad display mode");
        }

        private void ShowView()
        {
            Application.Run(this.view);
        }

        public void SetSelection(short[] selection)
        {
            if (selection == null)
                this.availableMoves = null;
            this.selection = selection;
        }

        public short[] GetSelection()
        {
            return this.selection;
        }

        /// <summary>
        /// Directs the GUI to update itself by refreshing its display
        /// of the board, current player, and if applicable, game winner.
        /// </summary>
        public void Update()
        {
            if (this.mode == DisplayMode.Window)
            {
                this.view.UpdateBoard();
                if (this.gameOver)
                    this.view.GameOver(this.playerTeam);
                else
                    this.view.UpdatePlayer(this.playerTeam);
            }
            if (this.mode == DisplayMode.Console)
            {
                if (this.gameOver)
                    this.display.GameOver(this.playerName);
                else
                    this.display.UpdatePlayer(this.playerName);
                this.display.Prompt();
            }
        }

        //public Stratego.Game GetGame()
        //{
        //    return this.game;
        //}

        public String GetBoardString()
        {
            return this.boardString;
        }

        public Stratego.Board GetBoard()
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
        public void SetBoardString(String board)
        {
            this.boardString = board;
        }

        public void SetBoard(Stratego.Board board)
        {
            this.board = board;
        }
        
        /// <summary>
        /// Sets the displayed current player to the given value. It will be
        /// displayed by the GUI.
        /// </summary>
        /// <param name="player">Player to display for the current turn</param>
        public void SetPlayer(String player)
        {
            this.playerName = player;
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
            if (this.mode == DisplayMode.Window)
            {
                if (this.hasUpdate)
                {
                    switch (this.ui)
                    {
                        case UserInput.QuickHotseat:
                            this.view.Invalidate();
                            this.view.UpdateBoard();
                            this.view.UpdatePlayer(this.playerTeam);
                            break;
                        case UserInput.CustomHotseat:
                            this.view.Invalidate();
                            this.view.UpdateBoard();
                            this.view.UpdatePlayer(this.playerTeam);
                            break;
                        case UserInput.CreateQuickNetwork:
                            this.view.UpdateBoard();
                            this.view.UpdatePlayer(this.playerTeam);
                            break;
                        case UserInput.CreateCustomNetwork:
                            this.view.UpdateBoard();
                            this.view.UpdatePlayer(this.playerTeam);
                            break;
                        case UserInput.JoinNetwork:
                            //this.view.Wait();
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
                                this.view.UpdateBoard();
                                if (this.gameOver)
                                    this.view.GameOver(this.playerTeam);
                                else
                                    this.view.UpdatePlayer(this.playerTeam);
                            }
                            //else
                            //    this.view.MoveFailed();
                            //this.hasUpdate = false;
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
                    //new Thread(new ThreadStart(this.display.Prompt)).Start();
                }
            }


            if (this.mode == DisplayMode.Console)
            {
                if (this.hasUpdate)
                {
                    switch (this.ui)
                    {
                        case UserInput.QuickHotseat:
                            //this.display.UpdateBoard(this.board);
                            this.display.UpdatePlayer(this.playerName);
                            break;
                        case UserInput.CustomHotseat:
                            break;
                        case UserInput.CreateQuickNetwork:
                         //   this.display.UpdateBoard(this.board);
                            this.display.UpdatePlayer(this.playerName);
                            break;
                        case UserInput.CreateCustomNetwork:
                            //   this.display.UpdateBoard(this.board);
                            this.display.UpdatePlayer(this.playerName);
                            break;
                        case UserInput.JoinNetwork:
                          //  this.display.UpdateBoard(this.board);
                            this.display.UpdatePlayer(this.playerName);
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
                                    this.display.GameOver(this.playerName);
                                else
                                    this.display.UpdatePlayer(this.playerName);
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
        public void QuickHotseatPress()
        {
            if (!this.hasUpdate)
            {
                this.ui = UserInput.QuickHotseat;
                this.hasUpdate = true;
            }
        }

        internal void CustomHotseatPress()
        {
            this.ui = UserInput.CustomHotseat;
            this.hasUpdate = true;
        }

        /// <summary>
        /// Handles the user creating a network game
        /// </summary>
        public void CreateQuickNetworkGamePress()
        {
            if (!this.hasUpdate)
            {
                this.ui = UserInput.CreateQuickNetwork;
                this.ip = "";
                this.hasUpdate = true;
            }
        }

        public void CreateCustomNetworkGamePress()
        {
            if (!this.hasUpdate)
            {
                this.ui = UserInput.CreateCustomNetwork;
                this.ip = "";
                this.hasUpdate = true;
            }
        }

        public void CreateQuickNetworkGamePress(String ip)
        {
            if (!this.hasUpdate)
            {
                this.ui = UserInput.CreateQuickNetwork;
                this.ip = ip;
                this.hasUpdate = true;
            }
        }

        public void CreateCustomNetworkGamePress(String ip)
        {
            if (!this.hasUpdate)
            {
                this.ui = UserInput.CreateCustomNetwork;
                this.ip = ip;
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
                this.ip = "";
                this.hasUpdate = true;
            }
        }

        public void JoinNetworkGamePress(String ip)
        {
            if (!this.hasUpdate)
            {
                this.ui = UserInput.JoinNetwork;
                this.ip = ip;
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
                this.saveLoad = name;
                this.hasUpdate = true;
            }
        }

        /// <summary>
        /// Handles the user loading a game
        /// </summary>
        public void LoadGamePress(String name)
        {
            if (!this.hasUpdate)
            {
                this.ui = UserInput.Load;
                this.saveLoad = name;
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

        public void QuitGame()
        {
            //right now, becomes stuck once StrategoController tells the server to stop

            //if (!this.hasUpdate)
            //{
            //    this.ui = UserInput.QuitGame;
            //    this.hasUpdate = true;
            //}
        }

        public short[] GetSingleCoords()
        {
            return this.singleCoords;
        }

        public Piece.Team GetCurrentTeam()
        {
            return this.playerTeam;
        }

        public void SetCurrentTeam(Piece.Team team)
        {
            this.playerTeam = team;
        }

        public void SetAvailableMoves(List<Point> coords)
        {
            this.availableMoves = coords;
        }

        public List<Point> GetAvailableMoves()
        {
            return this.availableMoves;
        }

        public Boolean GetGameOver()
        {
            return this.gameOver;
        }

        public String GetSaveLoad()
        {
            return this.saveLoad;
        }

        public void ResetGameInformation()
        {
            this.hasUpdate = false;
            this.singleCoords = null;
            this.doubleCoords = null;
            this.selection = null;
            this.playerName = null;
            this.playerTeam = Piece.Team.red;
            this.attempt = false;
            this.board = null;
            this.boardString = null;
            this.gameOver = false;
            this.availableMoves = null;
            this.revealedPiece = new Point(-1, -1);
        }

        public GameController.GameType GetGameType()
        {
            return this.gameType;
        }

        public void SetGameType(GameController.GameType gameType)
        {
            this.gameType = gameType;
        }

        public Piece.Team GetOwnerTeam()
        {
            return this.ownerTeam;
        }

        public void SetOwnerTeam(Piece.Team ownerTeam)
        {
            this.ownerTeam = ownerTeam;
        }

        public String GetIP()
        {
            return this.ip;
        }

        public void SetRevealedPiece(Point coords)
        {
            this.revealedPiece = coords;
        }

        public Point GetRevealedPiece()
        {
            return this.revealedPiece;
        }
    }
}
