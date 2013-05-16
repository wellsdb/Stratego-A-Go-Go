using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Stratego;
using Network;
using GUI;
using System.Windows.Forms;
using System.Drawing;

namespace Controller
{

    /// <summary>
    ///    Overall controlling class. It contains Main and controls the interactions
    ///    between the three main components: the UI, the Network elements, and the
    ///    game itself
    /// </summary>
    class StrategoController
    {
        /// <summary>
        /// Main method. Creates an instance of StrategoController
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        public static void Main(String[] args)
        {            
            new StrategoController();
        }

        private GUIController gui;
        private GameController game;
        private NetworkController network;
        private Boolean waiting;
        private Boolean toSwitch;
        //private GameController.GameType type;

        /// <summary>
        /// Constructor. Creates the three main componets along with threads to run them.
        /// </summary>
        public StrategoController()
        {
            //PassiveView v = new PassiveView();
            //View v = new View();
            //v.Show();
            
            ///
            ///Switch which line is commented to switch between console and window mode
            ///
            //gui = new GUIController(GUIController.DisplayMode.Console);

            game = new GameController();
            //game.StartHotseatGame();
            gui = new GUIController(GUIController.DisplayMode.Window);
            network = new NetworkController();
            
            //initialize components

            ////create threads
            //Thread StartGUIThread = new Thread(new ThreadStart(StartGUI));
            //StartGUIThread.Start();
            
            Thread GUIThread = new Thread(new ThreadStart(MonitorGUI));
            Thread NetworkThread = new Thread(new ThreadStart(MonitorServer));

            ////Thread.SetApar
            ////GUIThread.SetApartmentState(ApartmentState.STA);
            ////NetworkThread.SetApartmentState(ApartmentState.STA);
            
            //////start threads
            Thread.Sleep(50);
            GUIThread.Start();
            Thread.Sleep(50);
            NetworkThread.Start();
            Thread.Sleep(50);
            //v.GetView().Activate();
            //Console.ReadLine();
            //Console.WriteLine("End of Main.");
        }

        /// <summary>
        /// Starts the GUI
        /// </summary>
        private void StartGUI()
        {
            this.gui.Start();
        }

        

        /// <summary>
        /// Periodically checks the GUI for input, and handles it accordingly.
        /// </summary>
        private void MonitorGUI()
        {            
            //Boolean updated = false;
            while (true)
            {
                Thread.Sleep(50);
                //Console.Write("Checking GUI");
                if (this.gui.HasUpdate())
                {
                    GUI.GUIController.UserInput input = this.gui.GetInput();
                    switch (input)
                    {
                        case GUI.GUIController.UserInput.QuickHotseat:
                            this.QuickHotSeatGame();
                            break;
                        case GUI.GUIController.UserInput.CustomHotseat:
                            this.CustomHotSeatGame();
                            break;
                        case GUI.GUIController.UserInput.CreateQuickNetwork:
                            this.CreateQuickNetworkGame();
                            break;
                        case GUI.GUIController.UserInput.CreateCustomNetwork:
                            this.CreateCustomNetworkGame();
                            break;
                        case GUI.GUIController.UserInput.JoinNetwork:
                            this.JoinNetworkGame();
                            break;
                        case GUI.GUIController.UserInput.Settings:
                            //this.Se
                            throw new Exception("Settings are not yet implemented!");
                        case GUI.GUIController.UserInput.Exit:
                            this.Exit();
                            break;
                        case GUI.GUIController.UserInput.Tile:
                            this.TileSelection();
                            break;
                        case GUI.GUIController.UserInput.Move:
                            if (this.PlayerCheck())
                                this.MoveAttempt(this.gui.GetDoubleCoords());
                            else
                                this.gui.SetAttempt(false);
                            break;
                        case GUI.GUIController.UserInput.Save:
                            this.SaveGame(this.gui.GetSaveLoad());
                            break;
                        case GUI.GUIController.UserInput.Load:
                            this.LoadGame(this.gui.GetSaveLoad());
                            break;
                        case GUI.GUIController.UserInput.RussianMode:
                            this.RussianToggle();
                            break;
                        case GUI.GUIController.UserInput.QuitGame:
                            this.QuitGame();
                            break;
                        default:
                            throw new Exception("A bad input was recieved from the GUI.");
                    }
                    //new Thread(new ThreadStart(this.gui.ResetUpdate)).Start();
                    //Thread.Sleep(100);
                    this.gui.ResetUpdate();
                }
            }
        }

        /// <summary>
        /// Checks if the player attempting to make a move is the player
        /// that is supposed to be moving that turn.
        /// </summary>
        /// <returns>True if valid, false if not</returns>
        private Boolean PlayerCheck()
        {
            return (this.game.GetGameType() == GameController.GameType.Hotseat || this.game.GetCurrentPlayer() == this.game.GetOwnerPlayer());
        }

        /// <summary>
        /// Periodically checks the Network for updates and handles them accordingly.
        /// </summary>
        private void MonitorServer()
        {
            //Boolean updated = false;
            while (true)
            {
                Thread.Sleep(200);
                if (network.HasUpdate())
                {
                    Byte[] data = network.GetData();
                    String message = new ASCIIEncoding().GetString(data);
                    Console.WriteLine("<" + message + ">");
                    if (this.waiting)
                    {
                        message = message.Substring(0, 5);
                        if (message == "quick")
                        {
                            this.game.JoinQuickNetworkGame();
                        }
                        else if (message == "custo")
                        {
                            this.game.JoinCustomNetworkGame();
                        }
                        this.gui.SetBoard(this.game.GetBoard());
                        this.gui.SetCurrentTeam(this.game.GetCurrentTeam());
                        this.gui.SetOwnerTeam(Piece.Team.blue);
                        this.gui.SetGameType(GameController.GameType.Network);
                        this.waiting = false;
                    }
                    //assume move at this point
                    else if (!game.GetGame().getPlacement())
                    {
                        short[] move = NetworkConverter.StringToMove(message);
                        this.MoveAttempt(move);
                    }
                    else
                    {
                        Object[] place = NetworkConverter.StringToPlace(message);
                        this.PlaceAttempt(place);
                        if (this.toSwitch) game.GetGame().setPlacement(false);
                    }
                    this.network.ResetUpdate();
                    new Thread(new ThreadStart(this.gui.Update)).Start();
                }
            }
        }

        /// <summary>
        /// Starts a new preset hotseat game with calls to the game and the GUI
        /// </summary>
        private void QuickHotSeatGame()
        {
            this.gui.ResetGameInformation();
            this.game.StartHotseatGame();
            this.gui.SetBoard(this.game.GetBoard());
            this.gui.SetCurrentTeam(this.game.GetCurrentTeam());
            this.gui.SetOwnerTeam(Piece.Team.red);
            this.gui.SetGameType(GameController.GameType.Hotseat);
            this.gui.Update();
            //this.gui.SetToBeUpdated(true);
        }

        /// <summary>
        /// Starts a new hotseat game where you place your pieces.
        /// </summary>
        private void CustomHotSeatGame()
        {
            this.gui.ResetGameInformation();
            this.game.StartCustomHotseatGame();
            this.gui.SetBoard(this.game.GetBoard());
            this.gui.SetCurrentTeam(this.game.GetCurrentTeam());
            this.gui.SetOwnerTeam(Piece.Team.red);
            this.gui.SetGameType(GameController.GameType.Hotseat);
            this.gui.Update();
        }

        /// <summary>
        /// Creates a new network game with calls to the game, network, and gui
        /// </summary>
        private void CreateQuickNetworkGame()
        {
            this.gui.ResetGameInformation();
            this.network.SetSendPort(NetworkController.Port.One);
            this.network.SetRecievePort(NetworkController.Port.Two);

            String ip = this.gui.GetIP();
            if (ip == "")
                this.network.SetIP(NetworkController.LOCALHOST_IP);
            else
                this.network.SetIP(ip);

            this.network.StartServer();
            this.game.CreateQuickNetworkGame();
            this.network.SendString("quick");
            this.gui.SetBoard(this.game.GetBoard());
            this.gui.SetCurrentTeam(this.game.GetCurrentTeam());
            this.gui.SetOwnerTeam(Piece.Team.red);
            this.gui.SetGameType(GameController.GameType.Network);
            this.gui.Update();
        }

        private void CreateCustomNetworkGame()
        {
            this.gui.ResetGameInformation();
            this.network.SetSendPort(NetworkController.Port.One);
            this.network.SetRecievePort(NetworkController.Port.Two);

            String ip = this.gui.GetIP();
            if (ip == "")
                this.network.SetIP(NetworkController.LOCALHOST_IP);
            else
                this.network.SetIP(ip);

            this.network.StartServer();
            this.game.CreateCustomNetworkGame();
            this.network.SendString("custo");
            this.gui.SetBoard(this.game.GetBoard());
            this.gui.SetCurrentTeam(this.game.GetCurrentTeam());
            this.gui.SetOwnerTeam(Piece.Team.red);
            this.gui.SetGameType(GameController.GameType.Network);
            this.gui.Update();
        }

        /// <summary>
        /// Joins an existing network game with calls to the game, network, and gui
        /// </summary>
        private void JoinNetworkGame()
        {
            this.gui.ResetGameInformation();
            this.network.SetSendPort(NetworkController.Port.Two);
            this.network.SetRecievePort(NetworkController.Port.One);

            String ip = this.gui.GetIP();
            if (ip == "")
                this.network.SetIP(NetworkController.LOCALHOST_IP);
            else
                this.network.SetIP(ip);

            //this.network.StartServer();
            //CHANGE FOR DIFFERENT IP's

            //this.gui.SetToBeUpdated(true);
            this.network.StartServer();
            this.waiting = true;
        }

        private void QuitGame()
        {
            this.network.Stop();            
        }

        private void SaveGame(String file)
        {
            this.game.GetGame().saveFile(file);
        }

        private void LoadGame(String file)
        {
            this.gui.ResetGameInformation();
            this.game.StartHotseatGame();
            this.game.GetGame().loadFile(file);
            this.gui.SetBoard(this.game.GetBoard());
            this.gui.SetGameType(GameController.GameType.Hotseat);
            this.gui.Update();

        }

        private void TileSelection()
        {
            //if (!this.game.GetGameOver())
            if (true)
            {
                //if owner's turn
                if (this.game.GetGameType() == GameController.GameType.Hotseat || this.game.GetOwnerTeam() == this.game.GetCurrentTeam())
                {
                    short[] clicked = this.gui.GetSingleCoords();
                    short v = clicked[0];
                    short h = clicked[1];


                    if (this.game.GetGame().getPlacement())
                    {
                        
                        Stratego.Piece.Team team = this.game.GetGame().getCurrentTurn();
                        short count1 = this.game.GetGame().getBoard().getRedCount();
                        short count2 = this.game.GetGame().getBoard().getBlueCount();



                        if (count1 < 40 | count2 < 40)
                        {
                            Cell.Terrain terrain = this.game.GetBoard().getCell(v, h).getTerrain();
                            Piece piece = this.game.GetGame().getBoard().getCell(v, h).getPiece();


                            if (terrain == Cell.Terrain.Land && piece == null)
                            {
                                if (count1 > count2)
                                {
                                    if (v > 5)
                                    {
                                        this.PlaceAttempt(new Object[] { v, h, this.game.GetGame().getCurrentTurn(), count2 });
                                        count2++;
                                    }

                                }
                                else
                                {
                                    if (v < 4)
                                    {
                                        this.PlaceAttempt( new Object[] {v, h, this.game.GetGame().getCurrentTurn(), count1 });
                                        count1++;
                                    }
                                }

                            }
                            if (count1 == 40 | count2 == 40)
                            {
                                this.game.GetGame().swapTurn();
                                this.gui.SetCurrentTeam(this.game.GetCurrentTeam());
                                this.gui.SetBoard(this.game.GetBoard());
                                this.gui.Update();
                                if (team == Piece.Team.blue)
                                {
                                    this.game.GetGame().setPlacement(false);
                                }
                                else
                                {
                                    this.toSwitch = true;
                                }

                                this.game.GetGame().swapTurn();
                                this.gui.SetBoard(this.game.GetBoard());
                                this.gui.SetCurrentTeam(this.game.GetCurrentTeam());
                                this.gui.Update();

                                Console.WriteLine("Switched");
                            }

                        }

                    }
                    else
                    {
                        short[] currentSelection = this.game.getCurrentSelection();

                        Board board = this.game.GetBoard();

                        Piece piece = board.getCell(v, h).getPiece();

                        if (currentSelection == null)
                        {
                            if (piece != null)
                            {
                                Piece.Team activeTeam = this.game.GetCurrentTeam();
                                Piece.Team pieceTeam = piece.getTeam();
                                if (activeTeam == pieceTeam)
                                {
                                    //this.currentSelection = selected;
                                    this.game.setCurrentSelection(v, h);
                                    this.gui.SetSelection(new short[] { v, h });
                                    this.gui.SetAvailableMoves(this.game.GetAvailableMoves(new Point(h, v)));
                                    this.gui.Update();
                                }
                                // Console.WriteLine(this.controller.GetGame().getBoard().getCell(v, h).getPiece().getRank());
                            }
                        }
                        else
                        {
                            short currentV = currentSelection[0];
                            short currentH = currentSelection[1];
                            this.game.clearCurrentSelection();
                            this.gui.SetSelection(null);

                            if (currentV != v || currentH != h)
                            {
                                this.gui.SetSelection(null);
                                this.MoveAttempt(new short[] { v, h, currentV, currentH });
                            }
                            else
                            {
                                this.game.clearCurrentSelection();
                                this.gui.SetSelection(null);
                                this.gui.Update();
                            }
                        }
                    }
                }
            }
        }

        //Helper method to place pieces at the start of the game.
        private Boolean placement(short v, short h, Stratego.Piece.Team team, short pieceCount)
        {
            Boolean valid = false;
            Piece place;
            if (pieceCount < 8)
            {
                place = new Piece(team, Piece.Rank.scout);
                this.game.GetGame().getBoard().placementPiece(place, v, h);
                valid = true;
            }
            else if (pieceCount < 13)
            {
                place = new Piece(team, Piece.Rank.miner);
                this.game.GetGame().getBoard().placementPiece(place, v, h);
                valid = true;
            }
            else if (pieceCount < 17)
            {
                place = new Piece(team, Piece.Rank.sergeant);
                this.game.GetGame().getBoard().placementPiece(place, v, h);
                valid = true;
            }
            else if (pieceCount < 21)
            {
                place = new Piece(team, Piece.Rank.lieutenant);
                this.game.GetGame().getBoard().placementPiece(place, v, h);
                valid =  true;

            }
            else if (pieceCount < 25)
            {
                place = new Piece(team, Piece.Rank.captain);
                this.game.GetGame().getBoard().placementPiece(place, v, h);
                valid = true;

            }
            else if (pieceCount < 28)
            {
                place = new Piece(team, Piece.Rank.major);
                this.game.GetGame().getBoard().placementPiece(place, v, h);
                valid = true;

            }
            else if (pieceCount < 30)
            {
                place = new Piece(team, Piece.Rank.colonel);
                this.game.GetGame().getBoard().placementPiece(place, v, h);
                valid = true;

            }
            else if (pieceCount < 31)
            {
                place = new Piece(team, Piece.Rank.general);
                this.game.GetGame().getBoard().placementPiece(place, v, h);
                valid = true;

            }
            else if (pieceCount < 32)
            {
                place = new Piece(team, Piece.Rank.marshal);
                this.game.GetGame().getBoard().placementPiece(place, v, h);
                valid = true;

            }
            else if (pieceCount < 33)
            {
                place = new Piece(team, Piece.Rank.spy);
                this.game.GetGame().getBoard().placementPiece(place, v, h);
                valid = true;

            }
            else if (pieceCount < 39)
            {
                place = new Piece(team, Piece.Rank.bomb);
                this.game.GetGame().getBoard().placementPiece(place, v, h);
                valid = true;

            }
            else if (pieceCount < 40)
            {
                place = new Piece(team, Piece.Rank.flag);
                this.game.GetGame().getBoard().placementPiece(place, v, h);
                valid = true;

            }

            if (pieceCount == 40)
            {
                this.game.GetGame().swapTurn();
                this.gui.SetCurrentTeam(this.game.GetCurrentTeam());
                this.gui.SetBoard(this.game.GetBoard());
                this.gui.Update();
                this.game.GetGame().setPlacement(false);
                valid = true;
            }

            if (valid)
            {
                this.game.GetGame().swapTurn();
                this.gui.SetBoard(this.game.GetBoard());
                this.gui.SetCurrentTeam(this.game.GetCurrentTeam());
                this.gui.Update();
            }

            return valid;
        }

        /// <summary>
        /// Attempts to perform a move and updates according to its success or failure. Game checks validity
        /// and performs the move, and the GUI is updated accordingly. If it is a network game, the move is
        /// sent to the other player.
        /// </summary>
        /// <param name="coords">The coordinates of the starting and ending cells</param>
        private void MoveAttempt(short[] coords)
        {
            Piece.Team movingTeam = game.GetCurrentTeam();
            bool[] attempt = this.game.AttemptMove(coords[0], coords[1], coords[2], coords[3]);

            //backwards console version
            //bool[] attempt = this.game.AttemptMove(coords[2], coords[3], coords[0], coords[1]);
            if (attempt[0])
            {
                this.gui.SetBoard(this.game.GetBoard());
                //this.gui.SetPlayer(this.game.GetCurrentPlayer());
                this.gui.SetCurrentTeam(this.game.GetCurrentTeam());

                if (this.game.GetGameType() == GameController.GameType.Network)
                {
                    Boolean sent = false;
                    if (this.game.GetOwnerTeam() == movingTeam)
                    {
                        //Console.WriteLine("Sending: " + NetworkConverter.MoveToString(coords[0], coords[1], coords[2], coords[3]));
                        sent = this.network.SendString(NetworkConverter.MoveToString(coords[0], coords[1], coords[2], coords[3]));
                    }
                    //Console.WriteLine("Sending was successful: " + sent);
                }
            }            
            this.gui.SetAttempt(attempt[0]);
            this.gui.SetGameOver(attempt[1]);
            this.gui.SetRevealedPiece(this.game.GetRevealedPiece());
            //this.gui.SetToBeUpdated(true);
            this.gui.Update();
        }

        private void PlaceAttempt(Object[] place)
        {
            Piece.Team movingTeam = game.GetCurrentTeam();

            Boolean attempt = this.placement((short) place[0], (short) place[1], movingTeam, (short) place[3]);
            if (attempt)
            {
                this.gui.SetBoard(this.game.GetBoard());
                this.gui.SetCurrentTeam(this.game.GetCurrentTeam());
                if (this.game.GetGameType() == GameController.GameType.Network)
                {
                    Boolean sent = false;
                    if (this.game.GetOwnerTeam() == movingTeam)
                    {
                        Console.WriteLine("Sending..." + NetworkConverter.PlaceToString((short)place[0], (short)place[1], place[2].ToString(), (short)place[3]));
                        sent = this.network.SendString(NetworkConverter.PlaceToString((short)place[0], (short)place[1], place[2].ToString(), (short)place[3]));
                    }
                }
            }
                    this.gui.SetAttempt(attempt);
                    this.gui.Update();
                


        }
        
        /// <summary>
        /// Exits the program
        /// </summary>
        private void Exit()
        {
            Environment.Exit(0);
        }

        private void RussianToggle()
        {
            Board.BattleMode mode = this.game.GetBattleMode();
            if (mode == Board.BattleMode.Normal)
                this.game.SetBattleMode(Board.BattleMode.Reverse);
            else
                this.game.SetBattleMode(Board.BattleMode.Normal);
        }

        private void GameRecieved()
        {

        }

        private void BoardRecieved()
        {

        }

        private void MoveRecieved()
        {

        }

        private void PlayerNameRecieved()
        {

        }
    }
}
