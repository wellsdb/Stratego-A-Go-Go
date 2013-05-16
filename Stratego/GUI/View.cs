using Stratego;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace GUI
{
    public partial class View : Form //, FrontEnd
    {
        public short h;
        public short v;
        //public short mode;
        private GUIController controller;
        private Boolean Russian;
        private Boolean colorBlind;
        private Boolean easy;
        private Boolean spanish;
        private CultureInfo CultureInfo { get; set; }
        private Boolean settingsMenu = false;

        private static readonly Color LAND_COLOR_NORMAL = Color.Green;
        private static readonly Color LAKE_COLOR_NORMAL = Color.Aquamarine;
        private static readonly Color SELECTION_COLOR_NORMAL = Color.BlanchedAlmond;
        private static readonly Color AVAILABLE_COLOR_NORMAL = Color.Purple;
        private static readonly Color RED_TEAM_COLOR_NORMAL = Color.DarkRed;
        private static readonly Color BLUE_TEAM_COLOR_NORMAL = Color.DarkBlue;

        private static readonly Color LAND_COLOR_RUSSIAN = Color.White;
        private static readonly Color LAKE_COLOR_RUSSIAN = Color.LightBlue;
        private static readonly Color SELECTION_COLOR_RUSSIAN = Color.Yellow;
        private static readonly Color AVAILABLE_COLOR_BLIND = Color.LightGray;
        private static readonly Color RED_TEAM_COLOR_BLIND = Color.Black;
        private static readonly Color BLUE_TEAM_COLOR_BLIND = Color.White;

        public View()
        {

        }
        
        public View(GUIController controller)
        {
            this.controller = controller;
            //mode = 0;
            CultureInfo = CultureInfo.CurrentCulture;

            InitializeComponent();
            this.loadLanguages();

            this.board.Visible = false;
        }

        private void loadLanguages()
        {
            hotseatlabel.Text = GUI.Properties.Resources.ResourceManager.GetString("hotseat", CultureInfo);
            hotseatlabel.Refresh();
            networklabel.Text = GUI.Properties.Resources.ResourceManager.GetString("network", CultureInfo);
            networklabel.Refresh();
            settingslabel.Text = GUI.Properties.Resources.ResourceManager.GetString("settings", CultureInfo);
            settingslabel.Refresh();
            exitlabel.Text = GUI.Properties.Resources.ResourceManager.GetString("exit", CultureInfo);
            exitlabel.Refresh();
            menulabel.Text = GUI.Properties.Resources.ResourceManager.GetString("menu", CultureInfo);
            menulabel.Refresh();
            joinlabel.Text = GUI.Properties.Resources.ResourceManager.GetString("join", CultureInfo);
            createlabel.Text = GUI.Properties.Resources.ResourceManager.GetString("create", CultureInfo);
        }


        private void loadSettingsLanguages()
        {
            hotseatlabel.Text = GUI.Properties.Resources.ResourceManager.GetString("colorblind", CultureInfo);
            hotseatlabel.Refresh();
            networklabel.Text = GUI.Properties.Resources.ResourceManager.GetString("russian", CultureInfo);
            networklabel.Refresh();
            settingslabel.Text = GUI.Properties.Resources.ResourceManager.GetString("easy", CultureInfo);
            settingslabel.Refresh();
            exitlabel.Text = GUI.Properties.Resources.ResourceManager.GetString("spanish", CultureInfo);
            exitlabel.Refresh();
            menulabel.Text = GUI.Properties.Resources.ResourceManager.GetString("menu", CultureInfo);
            menulabel.Refresh();
        }

        public void UpdatePlayer(Piece.Team player)
        {
            if (this.colorBlind)
            {
                if (player == Piece.Team.red)
                {
                    //TeamLabel.Text = GUI.Properties.Resources.ResourceManager.GetString("black", CultureInfo);
                    this.SetTeamLabel("black");
                }
                else
                {
                    //TeamLabel.Text = GUI.Properties.Resources.ResourceManager.GetString("white", CultureInfo);
                    this.SetTeamLabel("white");
                }
            }
            else
            {
                if (player == Piece.Team.red)
                {
                    //TeamLabel.Text = GUI.Properties.Resources.ResourceManager.GetString("red", CultureInfo);
                    this.SetTeamLabel("red");
                }
                else
                {
                    //TeamLabel.Text = GUI.Properties.Resources.ResourceManager.GetString("blue", CultureInfo);
                    this.SetTeamLabel("blue");
                }

            }
            
        }

        delegate void SetTeamCallback(String text);

        private void SetTeamLabel(String team)
        {
            if (this.TeamLabel.InvokeRequired)
            {
                SetTeamCallback d = new SetTeamCallback(SetTeamLabel);
                this.Invoke(d, new object[] { team });
            }
            else
            {
                this.TeamLabel.Text = GUI.Properties.Resources.ResourceManager.GetString(team, CultureInfo);
                this.TeamLabel.Refresh();
            }
        }

        private void HotseatButtonClick(object sender, MouseEventArgs e)
        {
            if (!settingsMenu)
            {
                this.controller.HotSeatGamePress();

                //mode = 2;
                networkbutton.Visible = false;
                networklabel.Visible = false;
                hotseatbutton.Visible = false;
                hotseatlabel.Visible = false;
                settingsbutton.Visible = false;
                settingslabel.Visible = false;
                exitbutton.Visible = false;
                exitlabel.Visible = false;

                returntomenubutton.Visible = true;
                menulabel.Visible = true;

                board.Visible = true;
                board.Invalidate();
                TeamLabel.Visible = true;
            }
            else
            {
                if (this.colorBlind)
                {
                    this.colorBlind = false;
                    hotseatbutton.Image = GUI.Properties.Resources.widebutton;
                    this.hotseatbutton.Refresh();
                }
                else
                {
                    this.colorBlind = true;
                    hotseatbutton.Image = GUI.Properties.Resources.activatedwidebutton;
                    this.hotseatbutton.Refresh();
                }
            }
        }

        private void NetworkButtonClick(object sender, MouseEventArgs e)
        {
            if (!settingsMenu)
            {
                networkbutton.Visible = false;
                networklabel.Visible = false;
                hotseatbutton.Visible = false;
                hotseatlabel.Visible = false;
                settingsbutton.Visible = false;
                settingslabel.Visible = false;
                exitbutton.Visible = false;
                exitlabel.Visible = false;

                returntomenubutton.Visible = true;
                menulabel.Visible = true;
                createbutton.Visible = true;
                createlabel.Visible = true;
                joinbutton.Visible = true;
                joinlabel.Visible = true;

                IPBox.Visible = true;

            }
            else
            {
                this.controller.RussianPress();
                if (this.Russian)
                {
                    this.Russian = false;
                    networkbutton.Image = GUI.Properties.Resources.widebutton;
                    this.networkbutton.Refresh();
                }
                else
                {
                    this.Russian = true;
                    networkbutton.Image = GUI.Properties.Resources.activatedwidebutton;
                    this.networkbutton.Refresh();
                }
            }

        }

        private void JoinButtonClick(object sender, MouseEventArgs e)
        {
            //controller.JoinNetworkGame(textBox.Text);
            this.controller.JoinNetworkGamePress();

            board.Visible = true;
            board.Invalidate();
            TeamLabel.Visible = true;
            //UpdatePlayer();
        }

        private void CreateButtonClick(object sender, MouseEventArgs e)
        {
            //get IP
            String ip = IPBox.Text;
            if (ip != "")
                this.controller.CreateNetworkGamePress(ip);
            else 
                this.controller.CreateNetworkGamePress();

            board.Visible = true;
            board.Invalidate();
            TeamLabel.Visible = true;

            //UpdatePlayer();
        }

        private void SettingsButtonClick(object sender, MouseEventArgs e)
        {
            if (!settingsMenu)
            {
                this.settingsMenu = true;
                this.loadSettingsLanguages();
                if (Russian) networkbutton.Image = GUI.Properties.Resources.activatedwidebutton;
                if (colorBlind) hotseatbutton.Image = GUI.Properties.Resources.activatedwidebutton;
                if (easy) settingsbutton.Image = GUI.Properties.Resources.activatedwidebutton;
                if (spanish) exitbutton.Image = GUI.Properties.Resources.activatedwidebutton;
                returntomenubutton.Visible = true;
                menulabel.Visible = true;
            }
            else
            {
                if (this.easy)
                {
                    this.easy = false;
                    settingsbutton.Image = GUI.Properties.Resources.widebutton;
                    this.settingsbutton.Refresh();
                }
                else
                {
                    this.easy = true;
                    settingsbutton.Image = GUI.Properties.Resources.activatedwidebutton;
                    this.settingsbutton.Refresh();
                }
            }
        }

        private void ExitButtonClick(object sender, MouseEventArgs e)
        {
            if (!settingsMenu)
            {
                this.controller.ExitPress();
            }
            else
            {
                if (this.spanish)
                {
                    this.spanish = false;
                    CultureInfo = CultureInfo.CurrentCulture;
                    exitbutton.Image = GUI.Properties.Resources.widebutton;
                }
                else
                {
                    this.spanish = true;
                    CultureInfo = CultureInfo.GetCultureInfo("es-ES");
                    exitbutton.Image = GUI.Properties.Resources.activatedwidebutton;
                }
                this.loadSettingsLanguages();
            }
        }

        private void BackToMenuClick(object sender, MouseEventArgs e)
        {
            if (!settingsMenu)
            {
                hotseatbutton.Visible = true;
                hotseatlabel.Visible = true;
                hotseatlabel.BringToFront();
                networkbutton.Visible = true;
                networklabel.Visible = true;
                settingsbutton.Visible = true;
                settingslabel.Visible = true;
                exitbutton.Visible = true;
                exitlabel.Visible = true;

                createbutton.Visible = false;
                createlabel.Visible = false;
                joinbutton.Visible = false;
                joinlabel.Visible = false;
                IPBox.Visible = false;
                returntomenubutton.Visible = false;
                menulabel.Visible = false;
                TeamLabel.Visible = false;

                board.Visible = false;

                this.controller.QuitGame();
                //this.controller.Stop();

                //this.controller = new GameController();
            }
            else
            {
                this.settingsMenu = false;
                hotseatbutton.Visible = true;
                hotseatlabel.Visible = true;
                hotseatlabel.BringToFront();
                networkbutton.Visible = true;
                networklabel.Visible = true;
                settingsbutton.Visible = true;
                settingslabel.Visible = true;
                exitbutton.Visible = true;
                exitlabel.Visible = true;

                createbutton.Visible = false;
                createlabel.Visible = false;
                joinbutton.Visible = false;
                joinlabel.Visible = false;
                IPBox.Visible = false;
                returntomenubutton.Visible = false;
                menulabel.Visible = false;
                TeamLabel.Visible = false;

                networkbutton.Image = GUI.Properties.Resources.widebutton;
                hotseatbutton.Image = GUI.Properties.Resources.widebutton;
                settingsbutton.Image = GUI.Properties.Resources.widebutton;
                exitbutton.Image = GUI.Properties.Resources.widebutton;
                this.loadLanguages();
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            h = (short)(Math.Floor((decimal)p.X / 40));
            v = (short)(9 - (Math.Floor((decimal)p.Y / 40)));
            //System.Console.WriteLine(h);
            //System.Console.WriteLine(v);
            //short[] selected = new short[2];
            //selected[0] = v;
            //selected[1] = h;

            this.controller.TilePress(v, h);            
        }

        //private void GameOver(Piece.Team t)
        //{
        //    Console.WriteLine(t.ToString() + " has won!");
        //}


        //public void UpdateBoard(Stratego.Board board)
        //{

        //}

        public void UpdateBoard()
        {
            this.panel1_Paint(null, null);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //if (mode == 1 | mode == 2 | mode == 3)
            //{
            Graphics g = board.CreateGraphics();

            Board b = this.controller.GetBoard();
            short[] selection = this.controller.GetSelection();
            List<Point> availableMoves = this.controller.GetAvailableMoves();
            
            Piece.Team teamToPaint = this.controller.GetCurrentTeam();
            if (this.controller.GetGameType() == GameController.GameType.Network)
                teamToPaint = this.controller.GetOwnerTeam();
            
            if (b != null)
            {
                if (b.getCell(0, 0) != null)
                {
                    this.PaintTerrain(g, b, selection);
                    if (!this.controller.GetGameOver())
                        this.PaintAvailable(g, availableMoves);
                    this.PaintPieces(g, b, teamToPaint);
                }
            }
        }

        private void PaintTerrain(Graphics g, Board b, short[] selection)
        {
            Pen pen = new Pen(Color.Black);
            SolidBrush bland = new SolidBrush(LAND_COLOR_NORMAL);
            SolidBrush blake = new SolidBrush(LAKE_COLOR_NORMAL);
            SolidBrush bclick = new SolidBrush(SELECTION_COLOR_NORMAL);
            if (this.Russian)
            {
                bland.Color = LAND_COLOR_RUSSIAN;
                blake.Color = LAKE_COLOR_RUSSIAN;
                bclick.Color = SELECTION_COLOR_RUSSIAN;
            }

            
            for (int v = 9; v > -1; v--)
            {
                for (int h = 0; h < 10; h++)
                {
                    if (selection != null)
                    {
                        if (selection[0] == v && selection[1] == h)
                        {
                            if (this.Russian)
                            {
                                pen.Color = Color.Red;
                            }
                            else
                            {
                                pen.Color = Color.Yellow;
                            }
                        }
                        else
                        {
                            pen.Color = Color.Black;
                        }
                    }
                    if (b.getCell(v, h).getTerrain().Equals(Cell.Terrain.Land))
                    {
                        g.DrawRectangle(pen, h * 40, (9 - v) * 40, 39, 39);
                        g.FillRectangle(bland, h * 40 + 1, (9 - v) * 40 + 1, 38, 38);
                    }
                    else if (b.getCell(v, h).getTerrain().Equals(Cell.Terrain.Lake))
                    {
                        g.DrawRectangle(pen, h * 40, (9 - v) * 40, 39, 39);
                        g.FillRectangle(blake, h * 40 + 1, (9 - v) * 40 + 1, 39, 39);
                    }
                    else
                    {
                        g.DrawRectangle(pen, h * 40, (9 - v) * 40, 39, 39);
                        g.FillRectangle(bclick, h * 40 + 1, (9 - v) * 40 + 1, 39, 39);
                    }
                }
            }
        }

        private void PaintAvailable(Graphics g, List<Point> availableMoves)
        {
            if (availableMoves != null)
            {
                SolidBrush bavailable = new SolidBrush(AVAILABLE_COLOR_NORMAL);
                if (colorBlind)
                    bavailable = new SolidBrush(AVAILABLE_COLOR_BLIND);
                //black.Color = Color.Purple;
                //bempty.Color = Color.Purple;
                foreach (Point move in availableMoves)
                {
                    //g.DrawRectangle(black, move.X * 40, (9 - move.Y) * 40, 39, 39);
                    g.FillRectangle(bavailable, move.X * 40 + 1, (9 - move.Y) * 40 + 1, 38, 38);
                }
            }
        }

        private void PaintPieces(Graphics g, Board b, Piece.Team teamToPaint)
        {
            for (int v = 9; v > -1; v--)
            {
                for (int h = 0; h < 10; h++)
                {
                        Piece currentPiece = b.getCell(v, h).getPiece();                        
                        
                        if (currentPiece != null)
                        {
                            SolidBrush color;
                            Piece.Team team = currentPiece.getTeam();

                            if (team == Piece.Team.blue)
                            {
                                if (colorBlind)
                                {
                                    color = new SolidBrush(BLUE_TEAM_COLOR_BLIND);
                                }
                                else
                                {
                                    color = new SolidBrush(BLUE_TEAM_COLOR_NORMAL);
                                }
                            }
                            else if (team == Piece.Team.red)
                            {
                                if (colorBlind)
                                {
                                    color = new SolidBrush(RED_TEAM_COLOR_BLIND);
                                }
                                else
                                {
                                    color = new SolidBrush(RED_TEAM_COLOR_NORMAL);
                                }
                            }
                            else
                            {
                                color = new SolidBrush(Color.Black);
                            }                            

                            Rectangle piece = new Rectangle(h * 40 + 5, (9 - v) * 40 + 5, 30, 30);
                            g.DrawEllipse(new Pen(Color.Black, 3), piece);
                            g.FillEllipse(color, piece);

                            if (teamToPaint == team || this.easy)
                            {
                                String rank;
                                switch (currentPiece.getRank())
                                {
                                    case Piece.Rank.bomb:
                                        rank = "B";
                                        break;
                                    case Piece.Rank.captain:
                                        rank = "4";
                                        break;
                                    case Piece.Rank.colonel:
                                        rank = "3";
                                        break;
                                    case Piece.Rank.flag:
                                        rank = "F";
                                        break;
                                    case Piece.Rank.general:
                                        rank = "2";
                                        break;
                                    case Piece.Rank.lieutenant:
                                        rank = "5";
                                        break;
                                    case Piece.Rank.major:
                                        rank = "6";
                                        break;
                                    case Piece.Rank.marshal:
                                        rank = "1";
                                        break;
                                    case Piece.Rank.miner:
                                        rank = "8";
                                        break;
                                    case Piece.Rank.scout:
                                        rank = "9";
                                        break;
                                    case Piece.Rank.sergeant:
                                        rank = "7";
                                        break;
                                    case Piece.Rank.spy:
                                        rank = "S";
                                        break;
                                    default:
                                        rank = "?";
                                        break;
                                }
                                SolidBrush pencil;
                                if (team == Piece.Team.blue && this.colorBlind)
                                {
                                    pencil = new SolidBrush(Color.Black);
                                }
                                else
                                {
                                    pencil = new SolidBrush(Color.White);
                                }

                                g.DrawString(rank,
                                    new Font("Times New Roman", 12.0f),
                                    pencil,
                                    new PointF(h * 40 + 14, (9 - v) * 40 + 10));
                            }
                        }                
                }
            }
        }

        //private void hotseatbutton_Click(object sender, EventArgs e)
        //{

        //}

        //private void label1_Click(object sender, EventArgs e)
        //{

        //}


        public void GameOver(Piece.Team team)
        {
             if (this.colorBlind)
             {
                 if (team == Piece.Team.red)
                 {
                     //TeamLabel.Text = GUI.Properties.Resources.ResourceManager.GetString("blackwin", CultureInfo);
                     this.SetTeamLabel("blackwin");
                 }
                 else
                 {
                     //TeamLabel.Text = GUI.Properties.Resources.ResourceManager.GetString("whitewin", CultureInfo);
                     this.SetTeamLabel("whitewin");
                 }
             }
             else
             {
                 if (team == Piece.Team.red)
                 {
                     //TeamLabel.Text = GUI.Properties.Resources.ResourceManager.GetString("redwin", CultureInfo);
                     this.SetTeamLabel("redwin");
                 }
                 else
                 {
                     //TeamLabel.Text = GUI.Properties.Resources.ResourceManager.GetString("bluewin", CultureInfo);
                     this.SetTeamLabel("bluewin");
                 }
             }
        }
    }
}
