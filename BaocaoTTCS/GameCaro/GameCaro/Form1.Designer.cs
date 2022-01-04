using System;

namespace GameCaro
{
    partial class GameCaro
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameCaro));
            this.panelBanco = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.textIP = new System.Windows.Forms.TextBox();
            this.proDemgio = new System.Windows.Forms.ProgressBar();
            this.textName = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBanco
            // 
            this.panelBanco.BackColor = System.Drawing.SystemColors.Control;
            this.panelBanco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panelBanco.Location = new System.Drawing.Point(254, 32);
            this.panelBanco.Name = "panelBanco";
            this.panelBanco.Size = new System.Drawing.Size(450, 450);
            this.panelBanco.TabIndex = 0;
            //this.panelBanco.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBanco_Paint);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel4.Controls.Add(this.picBox);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.btnConnect);
            this.panel4.Controls.Add(this.textIP);
            this.panel4.Controls.Add(this.proDemgio);
            this.panel4.Controls.Add(this.textName);
            this.panel4.Location = new System.Drawing.Point(0, 285);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(255, 200);
            this.panel4.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(128, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "5 to Win";
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.Aqua;
            this.btnConnect.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(3, 18);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(100, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // textIP
            // 
            this.textIP.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textIP.Location = new System.Drawing.Point(132, 18);
            this.textIP.Name = "textIP";
            this.textIP.ReadOnly = true;
            this.textIP.Size = new System.Drawing.Size(100, 24);
            this.textIP.TabIndex = 3;
            this.textIP.Text = "127.0.0.1";
            this.textIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // proDemgio
            // 
            this.proDemgio.BackColor = System.Drawing.SystemColors.Control;
            this.proDemgio.ForeColor = System.Drawing.SystemColors.Control;
            this.proDemgio.Location = new System.Drawing.Point(132, 58);
            this.proDemgio.Name = "proDemgio";
            this.proDemgio.Size = new System.Drawing.Size(100, 23);
            this.proDemgio.TabIndex = 1;
            // 
            // textName
            // 
            this.textName.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textName.Location = new System.Drawing.Point(3, 58);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(100, 22);
            this.textName.TabIndex = 0;
            this.textName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //this.textName.TextChanged += new System.EventHandler(this.textName_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(711, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.quitGameToolStripMenuItem,
            this.undoToolStripMenuItem});
            this.menuToolStripMenuItem.ForeColor = System.Drawing.Color.DarkRed;
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.ForeColor = System.Drawing.Color.DarkRed;
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // quitGameToolStripMenuItem
            // 
            this.quitGameToolStripMenuItem.ForeColor = System.Drawing.Color.DarkRed;
            this.quitGameToolStripMenuItem.Name = "quitGameToolStripMenuItem";
            this.quitGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Q)));
            this.quitGameToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.quitGameToolStripMenuItem.Text = "Quit Game";
            this.quitGameToolStripMenuItem.Click += new System.EventHandler(this.quitGameToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.ForeColor = System.Drawing.Color.DarkRed;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.U)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_tick);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.textBox1.Location = new System.Drawing.Point(254, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(450, 24);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "OOP_Application _GameCaroWinFormC#_61-CNTT1";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.DarkRed;
            this.textBox2.ForeColor = System.Drawing.Color.Maroon;
            this.textBox2.Location = new System.Drawing.Point(0, 262);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(255, 20);
            this.textBox2.TabIndex = 6;
           // this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(255, 228);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // picBox
            // 
            this.picBox.BackColor = System.Drawing.SystemColors.Control;
            this.picBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBox.Image = global::GameCaro.Properties.Resources.pic4;
            this.picBox.Location = new System.Drawing.Point(28, 91);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(52, 46);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox.TabIndex = 8;
            this.picBox.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // GameCaro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 487);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panelBanco);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GameCaro";
            this.Text = "GameCaroWinForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
           // this.Load += new System.EventHandler(this.GameCaro_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        private System.Windows.Forms.Panel panelBanco;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ProgressBar proDemgio;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox textIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }   
}

