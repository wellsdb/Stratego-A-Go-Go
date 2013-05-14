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
    public partial class View : Form
    {
        public short h;
        public short v;
        public short mode;
        private GUIController controller;
        private Boolean Russian;
        private Boolean colorBlind;
        private Boolean easy;
        private Boolean spanish;
        private CultureInfo CultureInfo { get; set; }

        public View()
        {

        }

        public View(GUIController controller)
        {
            this.controller = controller;
            mode = 0;
            CultureInfo = CultureInfo.CurrentCulture;

            InitializeComponent();
            this.loadLanguages();
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

        private void UpdateTeamLabel()
        {
            if (this.colorBlind)
            {
                if (this.controller.GetGame().getCurrentTurn() == Stratego.Piece.Team.red)
                {
                    TeamLabel.Text = GUI.Properties.Resources.ResourceManager.GetString("black", CultureInfo);
                }
                else
                {
                    TeamLabel.Text = GUI.Properties.Resources.ResourceManager.GetString("white", CultureInfo);
                }
            }
            else
            {
                if (this.controller.GetGame().getCurrentTurn() == Stratego.Piece.Team.red)
                {
                    TeamLabel.Text = GUI.Properties.Resources.ResourceManager.GetString("red", CultureInfo);
                }
                else
                {
                    TeamLabel.Text = GUI.Properties.Resources.ResourceManager.GetString("blue", CultureInfo);
                }

            }
            TeamLabel.Refresh();
            //TeamLabel.Text = this.controller.GetGame().getCurrentTurn().ToString() + "'s turn.";
        }

        private void HotseatButtonClick(object sender, MouseEventArgs e)
        {
            if (mode == 0)
            {
                mode = 2;
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
                UpdateTeamLabel();
            }
            else if (mode == 3)
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
            if (mode == 0)
            {
                mode = 1;
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

                textBox.Visible = true;

            }
            else if (mode == 3)
            {
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

            board.Visible = true;
            board.Invalidate();
            TeamLabel.Visible = true;
            UpdateTeamLabel();
        }

        private void CreateButtonClick(object sender, MouseEventArgs e)
        {
            //controller.CreateNetworkGame();

            board.Visible = true;
            board.Invalidate();
            TeamLabel.Visible = true;
            UpdateTeamLabel();
        }

        private void SettingsButtonClick(object sender, MouseEventArgs e)
        {
            if (mode == 0)
            {
                mode = 3;
                this.loadSettingsLanguages();
                if (Russian) networkbutton.Image = GUI.Properties.Resources.activatedwidebutton;
                if (colorBlind) hotseatbutton.Image = GUI.Properties.Resources.activatedwidebutton;
                if (easy) settingsbutton.Image = GUI.Properties.Resources.activatedwidebutton;
                if (spanish) exitbutton.Image = GUI.Properties.Resources.activatedwidebutton;
                returntomenubutton.Visible = true;
                menulabel.Visible = true;
            }
            else if (mode == 3)
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
            if (mode == 0)
            {
                mode = 9;
                this.Close();
            }
            else if (mode == 3)
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
            if (mode == 1 || mode == 2)
            {
                mode = 0;
                board.Visible = false;

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
                textBox.Visible = false;
                returntomenubutton.Visible = false;
                menulabel.Visible = false;
                TeamLabel.Visible = false;

                board.Visible = false;
                board.Invalidate();

                //this.controller.Stop();

                //this.controller = new GameController();
            }
            else if (mode == 3)
            {
                this.mode = 0;
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
                textBox.Visible = false;
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
            System.Console.WriteLine(h);
            System.Console.WriteLine(v);
            short[] selected = new short[2];
            selected[0] = v;
            selected[1] = h;

            if (this.controller.GetGame().getCurrentSelection() == null)
            {
                if (this.controller.GetGame().getBoard().getCell(v, h).getPiece() != null)
                {
                    if ((this.controller.GetGame().getCurrentTurn() == Piece.Team.blue & this.controller.GetGame().getBoard().getCell(v, h).getPiece().getTeam() == Piece.Team.blue) | (this.controller.GetGame().getCurrentTurn() == Piece.Team.red & this.controller.GetGame().getBoard().getCell(v, h).getPiece().getTeam() == Piece.Team.red))
                        this.controller.GetGame().setCurrentSelection(selected);
                    Console.WriteLine(this.controller.GetGame().getBoard().getCell(v, h).getPiece().getRank());
                }
            }
            else if (this.controller.GetGame().getCurrentSelection()[0] == v & this.controller.GetGame().getCurrentSelection()[1] == h)
                this.controller.GetGame().clearCurrentSelection();
            else
            {
                Stratego.Board.Direction move = Board.Direction.N;
                short distance = 0;
                if (this.controller.GetGame().getCurrentSelection()[0] == v & this.controller.GetGame().getCurrentSelection()[1] > h)
                {
                    move = Board.Direction.W;
                    distance = (short)(this.controller.GetGame().getCurrentSelection()[1] - h);
                }
                else if (this.controller.GetGame().getCurrentSelection()[0] == v & this.controller.GetGame().getCurrentSelection()[1] < h)
                {
                    move = Board.Direction.E;
                    distance = (short)-(this.controller.GetGame().getCurrentSelection()[1] - h);
                }
                else if (this.controller.GetGame().getCurrentSelection()[0] > v & this.controller.GetGame().getCurrentSelection()[1] == h)
                {
                    move = Board.Direction.S;
                    distance = (short)(this.controller.GetGame().getCurrentSelection()[0] - v);
                }
                else if (this.controller.GetGame().getCurrentSelection()[0] < v & this.controller.GetGame().getCurrentSelection()[1] == h)
                {
                    move = Board.Direction.N;
                    distance = (short)-(this.controller.GetGame().getCurrentSelection()[0] - v);
                }
                Console.WriteLine(move);
                Console.WriteLine(distance);


                if (distance != 0)
                {
                    Boolean[] attempt = this.controller.GetGame().movePiece(this.controller.GetGame().getCurrentSelection()[0], this.controller.GetGame().getCurrentSelection()[1], move, distance);
                    if (!attempt[0])
                        Console.WriteLine(GUI.Properties.Resources.ResourceManager.GetString("cantmove", CultureInfo));
                    else
                    {
                        this.controller.GetGame().clearCurrentSelection();
                        UpdateTeamLabel();
                        if (attempt[1])
                        {
                            if (this.colorBlind)
                            {
                                if (this.controller.GetGame().getCurrentTurn() == Piece.Team.red)
                                {
                                    TeamLabel.Text = GUI.Properties.Resources.ResourceManager.GetString("blackwin", CultureInfo);
                                }
                                else
                                {
                                    TeamLabel.Text = GUI.Properties.Resources.ResourceManager.GetString("whitewin", CultureInfo);
                                }
                            }
                            else
                            {
                                if (this.controller.GetGame().getCurrentTurn() == Piece.Team.red)
                                {
                                    TeamLabel.Text = GUI.Properties.Resources.ResourceManager.GetString("redwin", CultureInfo);
                                }
                                else
                                {
                                    TeamLabel.Text = GUI.Properties.Resources.ResourceManager.GetString("bluewin", CultureInfo);
                                }
                            }
                        }
                    }
                }
            }
            this.board.Invalidate();
        }

        //private void GameOver(Piece.Team t)
        //{
        //    Console.WriteLine(t.ToString() + " has won!");
        //}

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (mode == 1 | mode == 2 | mode == 3)
            {
                Graphics g = board.CreateGraphics();
                Pen black = new Pen(Color.Black);

                SolidBrush bempty = new SolidBrush(Color.Green);
                if (this.Russian)
                {
                    bempty.Color = Color.White;
                }
                SolidBrush blake = new SolidBrush(Color.Aquamarine);
                SolidBrush bclick = new SolidBrush(Color.BlanchedAlmond);

                for (int v = 9; v > -1; v--)
                {
                    for (int h = 0; h < 10; h++)
                    {
                        if (this.controller.GetGame().getCurrentSelection() != null)
                        {
                            if (this.controller.GetGame().getCurrentSelection()[0] == v & this.controller.GetGame().getCurrentSelection()[1] == h)
                            {
                                if (this.Russian)
                                {
                                    black.Color = Color.Red;
                                }
                                else
                                {
                                    black.Color = Color.Yellow;
                                }
                            }
                            else
                            {
                                black.Color = Color.Black;
                            }
                        }
                        if (this.controller.getBoard().getCell(v, h).getTerrain().Equals(Cell.Terrain.Land))
                        {
                            g.DrawRectangle(black, h * 40, (9 - v) * 40, 39, 39);
                            g.FillRectangle(bempty, h * 40 + 1, (9 - v) * 40 + 1, 38, 38);
                        }
                        else if (this.controller.getBoard().getCell(v, h).getTerrain().Equals(Cell.Terrain.Lake))
                        {
                            g.DrawRectangle(black, h * 40, (9 - v) * 40, 39, 39);
                            g.FillRectangle(blake, h * 40 + 1, (9 - v) * 40 + 1, 39, 39);
                        }
                        else
                        {
                            g.DrawRectangle(black, h * 40, (9 - v) * 40, 39, 39);
                            g.FillRectangle(bclick, h * 40 + 1, (9 - v) * 40 + 1, 39, 39);
                        }

                        Piece draw = this.controller.getBoard().getCell(v, h).getPiece();







                        if (draw != null)
                        {
                            SolidBrush color;
                            if (draw.getTeam() == Piece.Team.blue)
                            {
                                if (colorBlind)
                                {
                                    color = new SolidBrush(Color.White);
                                }
                                else
                                {
                                    color = new SolidBrush(Color.DarkBlue);
                                }
                            }
                            else if (draw.getTeam() == Piece.Team.red)
                            {
                                if (colorBlind)
                                {
                                    color = new SolidBrush(Color.Black);
                                }
                                else
                                {
                                    color = new SolidBrush(Color.DarkRed);
                                }
                            }
                            else
                            {
                                color = new SolidBrush(Color.Black);
                            }
                            Rectangle piece = new Rectangle(h * 40 + 5, (9 - v) * 40 + 5, 30, 30);
                            g.DrawEllipse(new Pen(Color.Black, 3), piece);
                            g.FillEllipse(color, piece);

                            if (this.controller.GetGame().getCurrentTurn() == draw.getTeam() | this.easy)
                            {
                                String rank;
                                switch (draw.getRank())
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
                                if (draw.getTeam() == Piece.Team.blue & this.colorBlind)
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

        }

        private void hotseatbutton_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
