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
        public int x;
        public int y;
        public int mode;
        private Board game;

        public View(Board board)
        {
            game = board;
            InitializeComponent();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            x = (int)Math.Floor((decimal)p.X / 40);
            y = (int)Math.Floor((decimal)p.Y / 40);
            System.Console.WriteLine(x);
            System.Console.WriteLine(y);

            this.game.board[x, y] = 10;


            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = panel1.CreateGraphics();
            Pen black = new Pen(Color.Black);

            SolidBrush bempty = new SolidBrush(Color.Green);
            SolidBrush blake = new SolidBrush(Color.Aquamarine);
            SolidBrush bclick = new SolidBrush(Color.BlanchedAlmond);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (this.game.board[i, j].Equals(0))
                    {
                        g.DrawRectangle(black, i * 40, j * 40, 40, 40);
                        g.FillRectangle(bempty, i * 40 + 1, j * 40 + 1, 39, 39);
                    }
                    else if (this.game.board[i, j].Equals(20))
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
}
