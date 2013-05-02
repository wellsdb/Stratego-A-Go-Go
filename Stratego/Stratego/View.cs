using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace Stratego
{
    public partial class View : Form
    {
        public int h;
        public int v;
        public int mode;
        private IPAddress clientIP;
        private Game game;

        public View(Game game)
        {
            this.game = game;
            mode = 0;
            InitializeComponent();
        }

        private void HotseatButtonClick(object sender, MouseEventArgs e)
        {
            if (mode == 0)
            {
                mode = 2;
                hotseatbutton.Visible = false;
                tuitorialbutton.Visible = false;
                networkbutton.Visible = false;
                exitbutton.Visible = false;

                returntomenubutton.Visible = true;

                board.Visible = true;
                board.Invalidate();
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

                board.Visible = true;
                board.Invalidate();
            }
        }

        private void JoinButtonClick(object sender, MouseEventArgs e)
        {
            this.clientIP = IPAddress.Parse(textBox.Text);
        }

        private void CreateButtonClick(object sender, MouseEventArgs e)
        {
            
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


            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            h = (int) Math.Floor((decimal)p.X / 40);
            v = (int) Math.Floor((decimal)p.Y / 40);
            System.Console.WriteLine(h);
            System.Console.WriteLine(v);

            if (this.game.getCurrentSelection() == null)
            {
                if (this.game.getBoard().getCell(v, h).getPiece() != null)
                {
                    if ((this.game.getCurrentTurn() == Piece.Team.blue & this.game.getBoard().getCell(v, h).getPiece().getTeam() == Piece.Team.blue) | (this.game.getCurrentTurn() == Piece.Team.red & this.game.getBoard().getCell(v, h).getPiece().getTeam() == Piece.Team.red))
                        this.game.setCurrentSelection((Int16)v, (Int16)h);
                }
            }
            else
            {
                this.game.clearCurrentSelection();
            }

            //if (this.game.getBoard().getCell(v, h).getTerrain().Equals(Cell.Terrain.Land))
            //    this.game.getBoard().getCell(v, h).setTerrain(Cell.Terrain.Lake);
            //else
            //    this.game.getBoard().getCell(v, h).setTerrain(Cell.Terrain.Land);

            board.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if(mode == 1 | mode == 2){
                Graphics g = board.CreateGraphics();
                Pen black = new Pen(Color.Black);

                SolidBrush bempty = new SolidBrush(Color.Green);
                SolidBrush blake = new SolidBrush(Color.Aquamarine);
                SolidBrush bclick = new SolidBrush(Color.BlanchedAlmond);


                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (this.game.getCurrentSelection() != null)
                        {
                            if (this.game.getCurrentSelection()[0] == j & this.game.getCurrentSelection()[1] == i)
                            {
                                black.Color = Color.Yellow;
                            }
                            else
                            {
                                black.Color = Color.Black;
                            }
                        }
                        if (this.game.getBoard().getCell(j, i).getTerrain().Equals(Cell.Terrain.Land))
                        {
                            g.DrawRectangle(black, i * 40, j * 40, 39, 39);
                            g.FillRectangle(bempty, i * 40 + 1, j * 40 + 1, 38, 38);
                        }
                        else if (this.game.getBoard().getCell(j, i).getTerrain().Equals(Cell.Terrain.Lake))
                        {
                            g.DrawRectangle(black, i * 40, j * 40, 39, 39);
                            g.FillRectangle(blake, i * 40 + 1, j * 40 + 1, 39, 39);
                        }
                        else
                        {
                            g.DrawRectangle(black, i * 40, j * 40, 39, 39);
                            g.FillRectangle(bclick, i * 40 + 1, j * 40 + 1, 39, 39);
                        }

                        Piece draw = this.game.getBoard().getCell(j, i).getPiece();

                        if (draw != null)
                        {
                            SolidBrush color;
                            if(draw.getTeam() == Piece.Team.blue)
                            {
                                color = new SolidBrush(Color.DarkBlue);
                            }else if (draw.getTeam() == Piece.Team.red)
                            {
                                color = new SolidBrush(Color.DarkRed);
                            }else{
                                color = new SolidBrush(Color.Black);
                            }
                            Rectangle piece = new Rectangle(i*40 + 5, j*40 + 5, 30, 30);
                            g.FillEllipse(color, piece);

                            String rank;
                            switch(draw.getRank())
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

                            g.DrawString(rank,
                                new Font("Times New Roman", 12.0f),
                                new SolidBrush(Color.White), 
                                new PointF(i * 40 + 14, j * 40 + 10));



                            

                        }
                    }
                }
            }

        }



        private void hotseatbutton_Click(object sender, EventArgs e)
        {

        }
    }
}
