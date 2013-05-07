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
            gui = new GUIController(GUIController.DisplayMode.Window);

            game = new GameController();
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
                Thread.Sleep(100);
                //Console.Write("Checking GUI");
                if (this.gui.HasUpdate())
                {
                    GUI.GUIController.UserInput input = this.gui.GetInput();
                    switch (input)
                    {
                        case GUI.GUIController.UserInput.Hotseat:
                            this.NewHotSeatGame();
                            break;
                        case GUI.GUIController.UserInput.CreateNetwork:
                            this.CreateNetworkGame();
                            break;
                        case GUI.GUIController.UserInput.JoinNetwork:
                            this.JoinNetworkGame();
                            break;
                        case GUI.GUIController.UserInput.Settings:
                            //this.Se
                            throw new Exception("Settings are not yet implemented!");
                            break;
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
                            this.SaveGame();
                            break;
                        case GUI.GUIController.UserInput.Load:
                            this.LoadGame();
                            break;
                        case GUI.GUIController.UserInput.RussianMode:
                            this.RussianToggle();
                            break;
                        default:
                            throw new Exception("A bad input was recieved from the GUI.");
                            break;
                    }
                    new Thread(new ThreadStart(this.gui.ResetUpdate)).Start();
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
                Thread.Sleep(400);
                if (network.HasUpdate())
                {
                    Byte[] data = network.GetData();
                    String message = new ASCIIEncoding().GetString(data);
                    //assume move at this point
                    short[] move = NetworkConverter.StringToMove(message);
                    //Console.WriteLine(message);
                    this.MoveAttempt(move);
                    this.network.ResetUpdate();
                    new Thread(new ThreadStart(this.gui.Update)).Start();
                }
            }
        }

        /// <summary>
        /// Starts a new hotseat game with calls to the game and the GUI
        /// </summary>
        private void NewHotSeatGame()
        {
            this.game.StartHotseatGame();
            this.gui.SetBoard(this.game.GetBoard().ToString());
            this.gui.SetPlayer(this.game.GetCurrentPlayer());
            //this.gui.SetToBeUpdated(true);
        }

        /// <summary>
        /// Creates a new network game with calls to the game, network, and gui
        /// </summary>
        private void CreateNetworkGame()
        {
            this.network.SetSendPort(NetworkController.Port.One);
            this.network.SetRecievePort(NetworkController.Port.Two);
            //this.network.StartServer();
            this.game.CreateNetworkGame();
            this.gui.SetBoard(this.game.GetBoard().ToString());
            this.gui.SetPlayer(this.game.GetCurrentPlayer());
            //this.gui.SetToBeUpdated(true);
            this.network.StartServer();
        }

        /// <summary>
        /// Joins an existing network game with calls to the game, network, and gui
        /// </summary>
        private void JoinNetworkGame()
        {
            this.network.SetSendPort(NetworkController.Port.Two);
            this.network.SetRecievePort(NetworkController.Port.One);
            this.network.SetIP(NetworkController.LOCALHOST_IP);
            //this.network.StartServer();
            //CHANGE FOR DIFFERENT IP's
            this.game.JoinNetworkGame();
            this.gui.SetBoard(this.game.GetBoard().ToString());
            this.gui.SetPlayer(this.game.GetCurrentPlayer());
            //this.gui.SetToBeUpdated(true);
            this.network.StartServer();
        }

        private void QuitGame()
        {

        }

        private void SaveGame()
        {

        }

        private void LoadGame()
        {

        }

        private void TileSelection()
        {

        }

        /// <summary>
        /// Attempts to perform a move and updates according to its success or failure. Game checks validity
        /// and performs the move, and the GUI is updated accordingly. If it is a network game, the move is
        /// sent to the other player.
        /// </summary>
        /// <param name="coords">The coordinates of the starting and ending cells</param>
        private void MoveAttempt(short[] coords)
        {
            String movingPC = game.GetCurrentPlayer();
            bool[] attempt = this.game.AttemptMove(coords[2], coords[3], coords[0], coords[1]);
            if (attempt[0])
            {
                this.gui.SetBoard(this.game.GetBoard().ToString());
                this.gui.SetPlayer(this.game.GetCurrentPlayer());

                if (this.game.GetGameType() == GameController.GameType.Network)
                {
                    Boolean sent = false;
                    if (this.game.GetOwnerPlayer() == movingPC)
                    {
                        //Console.WriteLine("Sending: " + NetworkConverter.MoveToString(coords[0], coords[1], coords[2], coords[3]));
                        sent = this.network.SendString(NetworkConverter.MoveToString(coords[0], coords[1], coords[2], coords[3]));
                    }
                    //Console.WriteLine("Sending was successful: " + sent);
                }
            }            
            this.gui.SetAttempt(attempt[0]);
            this.gui.SetGameOver(attempt[1]);
            //this.gui.SetToBeUpdated(true);
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
            //toggle russian mode
            //this.gui.setRussianMode(true/false)
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
