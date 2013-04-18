namespace Stratego
{
    partial class View
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.board = new System.Windows.Forms.Panel();
            this.returntomenubutton = new System.Windows.Forms.PictureBox();
            this.exitbutton = new System.Windows.Forms.PictureBox();
            this.tuitorialbutton = new System.Windows.Forms.PictureBox();
            this.hotseatbutton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.returntomenubutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitbutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuitorialbutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotseatbutton)).BeginInit();
            this.SuspendLayout();
            // 
            // board
            // 
            this.board.Location = new System.Drawing.Point(0, 0);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(400, 400);
            this.board.TabIndex = 0;
            this.board.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.board.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // returntomenubutton
            // 
            this.returntomenubutton.Image = global::Stratego.Properties.Resources.mainmenubutton;
            this.returntomenubutton.Location = new System.Drawing.Point(432, 127);
            this.returntomenubutton.Name = "returntomenubutton";
            this.returntomenubutton.Size = new System.Drawing.Size(200, 100);
            this.returntomenubutton.TabIndex = 0;
            this.returntomenubutton.TabStop = false;
            this.returntomenubutton.Visible = false;
            this.returntomenubutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BackToMenuClick);
            // 
            // exitbutton
            // 
            this.exitbutton.Image = global::Stratego.Properties.Resources.exitbutton;
            this.exitbutton.Location = new System.Drawing.Point(128, 339);
            this.exitbutton.Name = "exitbutton";
            this.exitbutton.Size = new System.Drawing.Size(400, 100);
            this.exitbutton.TabIndex = 3;
            this.exitbutton.TabStop = false;
            this.exitbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ExitButtonClick);
            // 
            // tuitorialbutton
            // 
            this.tuitorialbutton.Image = global::Stratego.Properties.Resources.tuitorialbutton;
            this.tuitorialbutton.Location = new System.Drawing.Point(127, 233);
            this.tuitorialbutton.Name = "tuitorialbutton";
            this.tuitorialbutton.Size = new System.Drawing.Size(400, 100);
            this.tuitorialbutton.TabIndex = 2;
            this.tuitorialbutton.TabStop = false;
            this.tuitorialbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TuitorialButtonClick);
            // 
            // hotseatbutton
            // 
            this.hotseatbutton.Image = global::Stratego.Properties.Resources._2photseatbutton;
            this.hotseatbutton.Location = new System.Drawing.Point(127, 129);
            this.hotseatbutton.Name = "hotseatbutton";
            this.hotseatbutton.Size = new System.Drawing.Size(400, 100);
            this.hotseatbutton.TabIndex = 1;
            this.hotseatbutton.TabStop = false;
            this.hotseatbutton.Click += new System.EventHandler(this.hotseatbutton_Click);
            this.hotseatbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.HotseatButtonClick);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 567);
            this.Controls.Add(this.returntomenubutton);
            this.Controls.Add(this.exitbutton);
            this.Controls.Add(this.tuitorialbutton);
            this.Controls.Add(this.hotseatbutton);
            this.Controls.Add(this.board);
            this.Name = "View";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.returntomenubutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitbutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuitorialbutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotseatbutton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel board;
        private System.Windows.Forms.PictureBox hotseatbutton;
        private System.Windows.Forms.PictureBox tuitorialbutton;
        private System.Windows.Forms.PictureBox exitbutton;
        private System.Windows.Forms.PictureBox returntomenubutton;
    }
}