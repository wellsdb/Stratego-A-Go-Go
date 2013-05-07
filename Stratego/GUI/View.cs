using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class View : Form
    {
        public int h;
        public int v;
        public int mode;
        private GUIController controller;

        public View()
        {
            
        }

        public View(GUIController controller)
        {
            this.controller = controller;
            mode = 0;
            InitializeComponent();
        }

        private void UpdateTeamLabel()
        {
            
            //TeamLabel.Text = this.controller.GetGame().getCurrentTurn().ToString() + "'s turn.";
        }

        private void HotseatButtonClick(object sender, MouseEventArgs e)
        {
            if (mode == 0)
            {
                mode = 2;
                networkbutton.Visible = false;
                hotseatbutton.Visible = false;
                tuitorialbutton.Visible = false;
                exitbutton.Visible = false;

                returntomenubutton.Visible = true;

                //controller.StartHotseatGame();

                board.Visible = true;
                board.Invalidate();
                TeamLabel.Visible = true;
                UpdateTeamLabel();
            }
        }

        private void NetworkButtonClick(object sender, MouseEventArgs e)
       {
            if (mode == 0)
            {
                mode = 1;
                hotseatbutton.Visible = false;
                tuitorialbutton.Visible = false;
                networkbutton.Visible = false;
                exitbutton.Visible = false;

                returntomenubutton.Visible = true;
                createbutton.Visible = true;
                joinbutton.Visible = true;

                textBox.Visible = true;

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

        private void TuitorialButtonClick(object sender, MouseEventArgs e)
        {
            if (mode == 0)
            {
                mode = 3;
                hotseatbutton.Visible = false;
                networkbutton.Visible = false;
                tuitorialbutton.Visible = false;
                exitbutton.Visible = false;

                returntomenubutton.Visible = true;

                board.Invalidate();
            }
        }

        private void ExitButtonClick(object sender, MouseEventArgs e)
        {
            if (mode == 0)
            {
                mode = 9;
                this.Close();
            }
        }

        private void BackToMenuClick(object sender, MouseEventArgs e)
        {
            if (mode != 0)
            {
                mode = 0;
                board.Visible = false;

                hotseatbutton.Visible = true;
                networkbutton.Visible = true;
                tuitorialbutton.Visible = true;
                exitbutton.Visible = true;

                createbutton.Visible = false;
                joinbutton.Visible = false;
                textBox.Visible = false;
                returntomenubutton.Visible = false;

                board.Visible = false;
                board.Invalidate();

                //this.controller.Stop();

                //this.controller = new GameController();
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            h = (Int16)(Math.Floor((decimal)p.X / 40));
            v = (Int16)(9-(Math.Floor((decimal)p.Y / 40)));
            //System.Console.WriteLine(h);
            //System.Console.WriteLine(v);


            //if (this.controller.getCurrentSelection() == null)
            //{
            //    if (this.controller.GetBoard().getCell(v, h).getPiece() != null)
            //    {
            //        if ((this.controller.GetGame().getCurrentTurn() == Piece.Team.blue & this.controller.GetBoard().getCell(v, h).getPiece().getTeam() == Piece.Team.blue) | (this.controller.GetGame().getCurrentTurn() == Piece.Team.red & this.controller.GetBoard().getCell(v, h).getPiece().getTeam() == Piece.Team.red))
            //            this.controller.setCurrentSelection((Int16)v, (Int16)h);
            //    }
            //}
            //else if (this.controller.getCurrentSelection()[0] ==(Int16)v & this.controller.getCurrentSelection()[1]== (Int16)h)
            //    this.controller.clearCurrentSelection();
            //else
            //{
            //    Boolean[] attempt = this.controller.HandleMove((Int16)v, (Int16)h);
            //    if (!attempt[0])
            //        Console.WriteLine("You cannot move there!");
            //    else
            //    {
            //        this.controller.clearCurrentSelection();
            //        UpdateTeamLabel();
            //        if (attempt[1])
            //        {
            //            TeamLabel.Text = this.controller.GetGame().getCurrentTurn().ToString() + " player wins!";
            //            this.GameOver(this.controller.GetGame().getCurrentTurn());

            //        }
            //    }
            //}
            this.board.Invalidate();
        }

        //private void GameOver(Piece.Team t)
        //{
        //    Console.WriteLine(t.ToString() + " has won!");
        //}

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //if (mode == 1 | mode == 2 | mode == 3)
            //{
            //    Graphics g = board.CreateGraphics();
            //    Pen black = new Pen(Color.Black);

            //    SolidBrush bempty = new SolidBrush(Color.Green);
            //    SolidBrush blake = new SolidBrush(Color.Aquamarine);
            //    SolidBrush bclick = new SolidBrush(Color.BlanchedAlmond);


            //    for (int v = 9; v > -1; v--)
            //    {
            //        for (int h = 0; h < 10; h++)
            //        {
            //            if (this.controller.getCurrentSelection() != null)
            //            {
            //                if (this.controller.getCurrentSelection()[0] == v & this.controller.getCurrentSelection()[1] == h)
            //                {
            //                    black.Color = Color.Yellow;
            //                }
            //                else
            //                {
            //                    black.Color = Color.Black;
            //                }
            //            }
            //            if (this.controller.GetBoard().getCell(v, h).getTerrain().Equals(Cell.Terrain.Land))
            //            {
            //                g.DrawRectangle(black, h * 40, (9-v) * 40, 39, 39);
            //                g.FillRectangle(bempty, h * 40 + 1, (9 - v) * 40 + 1, 38, 38);
            //            }
            //            else if (this.controller.GetBoard().getCell(v, h).getTerrain().Equals(Cell.Terrain.Lake))
            //            {
            //                g.DrawRectangle(black, h * 40, (9 - v) * 40, 39, 39);
            //                g.FillRectangle(blake, h * 40 + 1, (9 - v) * 40 + 1, 39, 39);
            //            }
            //            else
            //            {
            //                g.DrawRectangle(black, h * 40, (9 - v) * 40, 39, 39);
            //                g.FillRectangle(bclick, h * 40 + 1, (9 - v) * 40 + 1, 39, 39);
            //            }

            //            Piece draw = this.controller.GetBoard().getCell(v, h).getPiece();

            //            if (draw != null)
            //            {
            //                SolidBrush color;
            //                if (draw.getTeam() == Piece.Team.blue)
            //                {
            //                    color = new SolidBrush(Color.DarkBlue);
            //                }
            //                else if (draw.getTeam() == Piece.Team.red)
            //                {
            //                    color = new SolidBrush(Color.DarkRed);
            //                }
            //                else
            //                {
            //                    color = new SolidBrush(Color.Black);
            //                }
            //                Rectangle piece = new Rectangle(h * 40 + 5, (9 - v) * 40 + 5, 30, 30);
            //                g.FillEllipse(color, piece);

            //                String rank;
            //                switch (draw.getRank())
            //                {
            //                    case Piece.Rank.bomb:
            //                        rank = "B";
            //                        break;
            //                    case Piece.Rank.captain:
            //                        rank = "4";
            //                        break;
            //                    case Piece.Rank.colonel:
            //                        rank = "3";
            //                        break;
            //                    case Piece.Rank.flag:
            //                        rank = "F";
            //                        break;
            //                    case Piece.Rank.general:
            //                        rank = "2";
            //                        break;
            //                    case Piece.Rank.lieutenant:
            //                        rank = "5";
            //                        break;
            //                    case Piece.Rank.major:
            //                        rank = "6";
            //                        break;
            //                    case Piece.Rank.marshal:
            //                        rank = "1";
            //                        break;
            //                    case Piece.Rank.miner:
            //                        rank = "8";
            //                        break;
            //                    case Piece.Rank.scout:
            //                        rank = "9";
            //                        break;
            //                    case Piece.Rank.sergeant:
            //                        rank = "7";
            //                        break;
            //                    case Piece.Rank.spy:
            //                        rank = "S";
            //                        break;
            //                    default:
            //                        rank = "?";
            //                        break;
            //                }
            //                g.DrawString(rank,
            //                    new Font("Times New Roman", 12.0f),
            //                    new SolidBrush(Color.White),
            //                    new PointF(h * 40 + 14, (9 - v) * 40 + 10));
            //            }
            //        }
            //    }
            //}

        }

        private void hotseatbutton_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
