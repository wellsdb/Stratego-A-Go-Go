namespace GUI
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
        protected  void Dispose(bool disposing)
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
            this.networkbutton = new System.Windows.Forms.PictureBox();
            this.createbutton = new System.Windows.Forms.PictureBox();
            this.joinbutton = new System.Windows.Forms.PictureBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.TeamLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.returntomenubutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitbutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuitorialbutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotseatbutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.networkbutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.createbutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.joinbutton)).BeginInit();
            this.SuspendLayout();
            // 
            // board
            // 
            this.board.Location = new System.Drawing.Point(12, 9);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(400, 400);
            this.board.TabIndex = 0;
            this.board.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.board.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // returntomenubutton
            // 
            this.returntomenubutton.Image = global::GUI.Properties.Resources.mainmenubutton;
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
            this.exitbutton.Image = global::GUI.Properties.Resources.exitbutton;
            this.exitbutton.Location = new System.Drawing.Point(127, 415);
            this.exitbutton.Name = "exitbutton";
            this.exitbutton.Size = new System.Drawing.Size(400, 100);
            this.exitbutton.TabIndex = 3;
            this.exitbutton.TabStop = false;
            this.exitbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ExitButtonClick);
            // 
            // tuitorialbutton
            // 
            this.tuitorialbutton.Image = global::GUI.Properties.Resources.tuitorialbutton;
            this.tuitorialbutton.Location = new System.Drawing.Point(127, 309);
            this.tuitorialbutton.Name = "tuitorialbutton";
            this.tuitorialbutton.Size = new System.Drawing.Size(400, 100);
            this.tuitorialbutton.TabIndex = 2;
            this.tuitorialbutton.TabStop = false;
            this.tuitorialbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TuitorialButtonClick);
            // 
            // hotseatbutton
            // 
            this.hotseatbutton.Image = global::GUI.Properties.Resources._2photseatbutton;
            this.hotseatbutton.Location = new System.Drawing.Point(127, 203);
            this.hotseatbutton.Name = "hotseatbutton";
            this.hotseatbutton.Size = new System.Drawing.Size(400, 100);
            this.hotseatbutton.TabIndex = 1;
            this.hotseatbutton.TabStop = false;
            this.hotseatbutton.Click += new System.EventHandler(this.hotseatbutton_Click);
            this.hotseatbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.HotseatButtonClick);
            // 
            // networkbutton
            // 
            this.networkbutton.Image = global::GUI.Properties.Resources._2photseatbutton;
            this.networkbutton.Location = new System.Drawing.Point(127, 97);
            this.networkbutton.Name = "networkbutton";
            this.networkbutton.Size = new System.Drawing.Size(400, 100);
            this.networkbutton.TabIndex = 2;
            this.networkbutton.TabStop = false;
            this.networkbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NetworkButtonClick);
            // 
            // createbutton
            // 
            this.createbutton.Image = global::GUI.Properties.Resources._2photseatbutton;
            this.createbutton.Location = new System.Drawing.Point(432, 233);
            this.createbutton.Name = "createbutton";
            this.createbutton.Size = new System.Drawing.Size(200, 100);
            this.createbutton.TabIndex = 3;
            this.createbutton.TabStop = false;
            this.createbutton.Visible = false;
            this.createbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CreateButtonClick);
            // 
            // joinbutton
            // 
            this.joinbutton.Image = global::GUI.Properties.Resources._2photseatbutton;
            this.joinbutton.Location = new System.Drawing.Point(432, 339);
            this.joinbutton.Name = "joinbutton";
            this.joinbutton.Size = new System.Drawing.Size(200, 100);
            this.joinbutton.TabIndex = 4;
            this.joinbutton.TabStop = false;
            this.joinbutton.Visible = false;
            this.joinbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.JoinButtonClick);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(432, 48);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(200, 20);
            this.textBox.TabIndex = 5;
            this.textBox.Visible = false;
            // 
            // TeamLabel
            // 
            this.TeamLabel.AutoSize = true;
            this.TeamLabel.Location = new System.Drawing.Point(444, 36);
            this.TeamLabel.Name = "TeamLabel";
            this.TeamLabel.Size = new System.Drawing.Size(59, 13);
            this.TeamLabel.TabIndex = 4;
            this.TeamLabel.Text = "Red\'s Turn";
            this.TeamLabel.Visible = false;
            this.TeamLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(564, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "create game";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(578, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "join game";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(418, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Network Game";
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 567);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hotseatbutton);
            this.Controls.Add(this.networkbutton);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.joinbutton);
            this.Controls.Add(this.createbutton);
            this.Controls.Add(this.TeamLabel);
            this.Controls.Add(this.returntomenubutton);
            this.Controls.Add(this.exitbutton);
            this.Controls.Add(this.tuitorialbutton);
            this.Controls.Add(this.board);
            this.Name = "View";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.returntomenubutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitbutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuitorialbutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotseatbutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.networkbutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.createbutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.joinbutton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel board;
        private System.Windows.Forms.PictureBox hotseatbutton;
        private System.Windows.Forms.PictureBox tuitorialbutton;
        private System.Windows.Forms.PictureBox exitbutton;
        private System.Windows.Forms.PictureBox returntomenubutton;
        private System.Windows.Forms.Label TeamLabel;
        private System.Windows.Forms.PictureBox networkbutton;
        private System.Windows.Forms.PictureBox createbutton;
        private System.Windows.Forms.PictureBox joinbutton;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}