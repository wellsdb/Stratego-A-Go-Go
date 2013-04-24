using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Stratego
{
    public partial class View : Form
    {
        public int h;
        public int v;
        public int mode;
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
                exitbutton.Visible = false;

                returntomenubutton.Visible = true;

                board.Visible = true;
                board.Invalidate();
            }
        }

        private void TuitorialButtonClick(object sender, MouseEventArgs e)
        {
            if (mode == 0)
            {
                mode = 3;
                hotseatbutton.Visible = false;
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
            if (mode == 2 | mode == 3)
            {
                mode = 0;

                hotseatbutton.Visible = true;
                tuitorialbutton.Visible = true;
                exitbutton.Visible = true;

                returntomenubutton.Visible = false;

                board.Visible = false;
                board.Invalidate();
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            h = (int)Math.Floor((decimal)p.X / 40);
            v = (int)Math.Floor((decimal)p.Y / 40);
            System.Console.WriteLine(h);
            System.Console.WriteLine(v);

            if (this.game.getBoard().getCell(v, h).getTerrain().Equals(Cell.Terrain.Land))
                this.game.getBoard().getCell(v, h).setTerrain(Cell.Terrain.Lake);
            else
                this.game.getBoard().getCell(v, h).setTerrain(Cell.Terrain.Land);

            board.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if(mode == 2){
                Graphics g = board.CreateGraphics();
                Pen black = new Pen(Color.Black);

                SolidBrush bempty = new SolidBrush(Color.Green);
                SolidBrush blake = new SolidBrush(Color.Aquamarine);
                SolidBrush bclick = new SolidBrush(Color.BlanchedAlmond);

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (this.game.getBoard().getCell(j, i).getTerrain().Equals(Cell.Terrain.Land))
                        {
                            g.DrawRectangle(black, i * 40, j * 40, 40, 40);
                            g.FillRectangle(bempty, i * 40 + 1, j * 40 + 1, 39, 39);
                        }
                        else if (this.game.getBoard().getCell(j, i).getTerrain().Equals(Cell.Terrain.Lake))
                        {
                            g.DrawRectangle(black, i * 40, j * 40, 40, 40);
                            g.FillRectangle(blake, i * 40 + 1, j * 40 + 1, 39, 39);
                        }
                        else
                        {
                            g.DrawRectangle(black, i * 40, j * 40, 40, 40);
                            g.FillRectangle(bclick, i * 40 + 1, j * 40 + 1, 39, 39);
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
