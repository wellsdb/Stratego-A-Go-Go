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
            this.settingslabel = new System.Windows.Forms.Label();
            this.hotseatlabel = new System.Windows.Forms.Label();
            this.networklabel = new System.Windows.Forms.Label();
            this.returntomenubutton = new System.Windows.Forms.PictureBox();
            this.exitbutton = new System.Windows.Forms.PictureBox();
            this.settingsbutton = new System.Windows.Forms.PictureBox();
            this.hotseatbutton = new System.Windows.Forms.PictureBox();
            this.networkbutton = new System.Windows.Forms.PictureBox();
            this.createbutton = new System.Windows.Forms.PictureBox();
            this.joinbutton = new System.Windows.Forms.PictureBox();
            this.IPBox = new System.Windows.Forms.TextBox();
            this.TeamLabel = new System.Windows.Forms.Label();
            this.exitlabel = new System.Windows.Forms.Label();
            this.menulabel = new System.Windows.Forms.Label();
            this.joinlabel = new System.Windows.Forms.Label();
            this.createlabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.returntomenubutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitbutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsbutton)).BeginInit();
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
            // settingslabel
            // 
            this.settingslabel.AutoSize = true;
            this.settingslabel.BackColor = System.Drawing.Color.White;
            this.settingslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingslabel.Location = new System.Drawing.Point(280, 341);
            this.settingslabel.Name = "settingslabel";
            this.settingslabel.Size = new System.Drawing.Size(100, 29);
            this.settingslabel.TabIndex = 10;
            this.settingslabel.Text = "Settings";
            this.settingslabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SettingsButtonClick);
            // 
            // hotseatlabel
            // 
            this.hotseatlabel.AutoSize = true;
            this.hotseatlabel.BackColor = System.Drawing.Color.White;
            this.hotseatlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotseatlabel.Location = new System.Drawing.Point(252, 237);
            this.hotseatlabel.Name = "hotseatlabel";
            this.hotseatlabel.Size = new System.Drawing.Size(166, 29);
            this.hotseatlabel.TabIndex = 9;
            this.hotseatlabel.Text = "Hotseat Game";
            this.hotseatlabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.HotseatButtonClick);
            // 
            // networklabel
            // 
            this.networklabel.AutoSize = true;
            this.networklabel.BackColor = System.Drawing.Color.White;
            this.networklabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.networklabel.Location = new System.Drawing.Point(244, 133);
            this.networklabel.Name = "networklabel";
            this.networklabel.Size = new System.Drawing.Size(174, 29);
            this.networklabel.TabIndex = 8;
            this.networklabel.Text = "Network Game";
            this.networklabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NetworkButtonClick);
            // 
            // returntomenubutton
            // 
            this.returntomenubutton.Image = global::GUI.Properties.Resources.smallbutton;
            this.returntomenubutton.Location = new System.Drawing.Point(562, 129);
            this.returntomenubutton.Name = "returntomenubutton";
            this.returntomenubutton.Size = new System.Drawing.Size(200, 100);
            this.returntomenubutton.TabIndex = 0;
            this.returntomenubutton.TabStop = false;
            this.returntomenubutton.Visible = false;
            this.returntomenubutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BackToMenuClick);
            // 
            // exitbutton
            // 
            this.exitbutton.Image = global::GUI.Properties.Resources.widebutton;
            this.exitbutton.Location = new System.Drawing.Point(127, 415);
            this.exitbutton.Name = "exitbutton";
            this.exitbutton.Size = new System.Drawing.Size(400, 100);
            this.exitbutton.TabIndex = 3;
            this.exitbutton.TabStop = false;
            this.exitbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ExitButtonClick);
            // 
            // settingsbutton
            // 
            this.settingsbutton.Image = global::GUI.Properties.Resources.widebutton;
            this.settingsbutton.Location = new System.Drawing.Point(127, 309);
            this.settingsbutton.Name = "settingsbutton";
            this.settingsbutton.Size = new System.Drawing.Size(400, 100);
            this.settingsbutton.TabIndex = 2;
            this.settingsbutton.TabStop = false;
            this.settingsbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SettingsButtonClick);
            // 
            // hotseatbutton
            // 
            this.hotseatbutton.Image = global::GUI.Properties.Resources.widebutton;
            this.hotseatbutton.Location = new System.Drawing.Point(127, 203);
            this.hotseatbutton.Name = "hotseatbutton";
            this.hotseatbutton.Size = new System.Drawing.Size(400, 100);
            this.hotseatbutton.TabIndex = 1;
            this.hotseatbutton.TabStop = false;
            this.hotseatbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.HotseatButtonClick);
            // 
            // networkbutton
            // 
            this.networkbutton.Image = global::GUI.Properties.Resources.widebutton;
            this.networkbutton.Location = new System.Drawing.Point(127, 97);
            this.networkbutton.Name = "networkbutton";
            this.networkbutton.Size = new System.Drawing.Size(400, 100);
            this.networkbutton.TabIndex = 2;
            this.networkbutton.TabStop = false;
            this.networkbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NetworkButtonClick);
            // 
            // createbutton
            // 
            this.createbutton.Image = global::GUI.Properties.Resources.smallbutton;
            this.createbutton.Location = new System.Drawing.Point(562, 235);
            this.createbutton.Name = "createbutton";
            this.createbutton.Size = new System.Drawing.Size(200, 100);
            this.createbutton.TabIndex = 3;
            this.createbutton.TabStop = false;
            this.createbutton.Visible = false;
            this.createbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CreateButtonClick);
            // 
            // joinbutton
            // 
            this.joinbutton.Image = global::GUI.Properties.Resources.smallbutton;
            this.joinbutton.Location = new System.Drawing.Point(562, 341);
            this.joinbutton.Name = "joinbutton";
            this.joinbutton.Size = new System.Drawing.Size(200, 100);
            this.joinbutton.TabIndex = 4;
            this.joinbutton.TabStop = false;
            this.joinbutton.Visible = false;
            this.joinbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.JoinButtonClick);
            // 
            // IPBox
            // 
            this.IPBox.Location = new System.Drawing.Point(562, 457);
            this.IPBox.Name = "IPBox";
            this.IPBox.Size = new System.Drawing.Size(200, 20);
            this.IPBox.TabIndex = 5;
            this.IPBox.Visible = false;
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
            // 
            // exitlabel
            // 
            this.exitlabel.AutoSize = true;
            this.exitlabel.BackColor = System.Drawing.Color.White;
            this.exitlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitlabel.Location = new System.Drawing.Point(309, 448);
            this.exitlabel.Name = "exitlabel";
            this.exitlabel.Size = new System.Drawing.Size(52, 29);
            this.exitlabel.TabIndex = 11;
            this.exitlabel.Text = "Exit";
            this.exitlabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ExitButtonClick);
            // 
            // menulabel
            // 
            this.menulabel.AutoSize = true;
            this.menulabel.BackColor = System.Drawing.Color.White;
            this.menulabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menulabel.Location = new System.Drawing.Point(599, 161);
            this.menulabel.Name = "menulabel";
            this.menulabel.Size = new System.Drawing.Size(131, 29);
            this.menulabel.TabIndex = 12;
            this.menulabel.Text = "Main Menu";
            this.menulabel.Visible = false;
            this.menulabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BackToMenuClick);
            // 
            // joinlabel
            // 
            this.joinlabel.AutoSize = true;
            this.joinlabel.BackColor = System.Drawing.Color.White;
            this.joinlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.joinlabel.Location = new System.Drawing.Point(591, 375);
            this.joinlabel.Name = "joinlabel";
            this.joinlabel.Size = new System.Drawing.Size(148, 29);
            this.joinlabel.TabIndex = 13;
            this.joinlabel.Text = "Join a Game";
            this.joinlabel.Visible = false;
            this.joinlabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.JoinButtonClick);
            // 
            // createlabel
            // 
            this.createlabel.AutoSize = true;
            this.createlabel.BackColor = System.Drawing.Color.White;
            this.createlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createlabel.Location = new System.Drawing.Point(574, 269);
            this.createlabel.Name = "createlabel";
            this.createlabel.Size = new System.Drawing.Size(175, 29);
            this.createlabel.TabIndex = 14;
            this.createlabel.Text = "Create a Game";
            this.createlabel.Visible = false;
            this.createlabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CreateButtonClick);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 678);
            this.Controls.Add(this.settingslabel);
            this.Controls.Add(this.settingsbutton);
            this.Controls.Add(this.networklabel);
            this.Controls.Add(this.hotseatlabel);
            this.Controls.Add(this.hotseatbutton);
            this.Controls.Add(this.createlabel);
            this.Controls.Add(this.joinlabel);
            this.Controls.Add(this.menulabel);
            this.Controls.Add(this.exitlabel);
            this.Controls.Add(this.IPBox);
            this.Controls.Add(this.joinbutton);
            this.Controls.Add(this.createbutton);
            this.Controls.Add(this.TeamLabel);
            this.Controls.Add(this.returntomenubutton);
            this.Controls.Add(this.exitbutton);
            this.Controls.Add(this.networkbutton);
            this.Controls.Add(this.board);
            this.Name = "View";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.returntomenubutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitbutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsbutton)).EndInit();
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
        private System.Windows.Forms.PictureBox settingsbutton;
        private System.Windows.Forms.PictureBox exitbutton;
        private System.Windows.Forms.PictureBox returntomenubutton;
        private System.Windows.Forms.Label TeamLabel;
        private System.Windows.Forms.PictureBox networkbutton;
        private System.Windows.Forms.PictureBox createbutton;
        private System.Windows.Forms.PictureBox joinbutton;
        private System.Windows.Forms.TextBox IPBox;
        private System.Windows.Forms.Label networklabel;
        private System.Windows.Forms.Label settingslabel;
        private System.Windows.Forms.Label hotseatlabel;
        private System.Windows.Forms.Label exitlabel;
        private System.Windows.Forms.Label menulabel;
        private System.Windows.Forms.Label joinlabel;
        private System.Windows.Forms.Label createlabel;
    }
}