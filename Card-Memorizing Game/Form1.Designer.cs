
namespace Card_Memorizing_Game
{
    partial class Form1
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
            this.ModeMenu = new System.Windows.Forms.Panel();
            this.Hard = new System.Windows.Forms.Button();
            this.Meduim = new System.Windows.Forms.Button();
            this.Easy = new System.Windows.Forms.Button();
            this.ModeTile = new System.Windows.Forms.Label();
            this.ModeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ModeMenu
            // 
            this.ModeMenu.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ModeMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ModeMenu.Controls.Add(this.Hard);
            this.ModeMenu.Controls.Add(this.Meduim);
            this.ModeMenu.Controls.Add(this.Easy);
            this.ModeMenu.Controls.Add(this.ModeTile);
            this.ModeMenu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ModeMenu.Location = new System.Drawing.Point(255, 142);
            this.ModeMenu.Name = "ModeMenu";
            this.ModeMenu.Size = new System.Drawing.Size(362, 350);
            this.ModeMenu.TabIndex = 0;
            // 
            // Hard
            // 
            this.Hard.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hard.ForeColor = System.Drawing.Color.Red;
            this.Hard.Location = new System.Drawing.Point(125, 234);
            this.Hard.Name = "Hard";
            this.Hard.Size = new System.Drawing.Size(97, 56);
            this.Hard.TabIndex = 3;
            this.Hard.Text = "Hard";
            this.Hard.UseVisualStyleBackColor = true;
            this.Hard.Click += new System.EventHandler(this.ModeSet);
            // 
            // Meduim
            // 
            this.Meduim.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Meduim.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Meduim.Location = new System.Drawing.Point(125, 172);
            this.Meduim.Name = "Meduim";
            this.Meduim.Size = new System.Drawing.Size(97, 56);
            this.Meduim.TabIndex = 2;
            this.Meduim.Text = "Meduim";
            this.Meduim.UseVisualStyleBackColor = true;
            this.Meduim.Click += new System.EventHandler(this.ModeSet);
            // 
            // Easy
            // 
            this.Easy.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Easy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Easy.Location = new System.Drawing.Point(125, 110);
            this.Easy.Name = "Easy";
            this.Easy.Size = new System.Drawing.Size(97, 56);
            this.Easy.TabIndex = 1;
            this.Easy.Text = "Easy";
            this.Easy.UseVisualStyleBackColor = true;
            this.Easy.Click += new System.EventHandler(this.ModeSet);
            // 
            // ModeTile
            // 
            this.ModeTile.AutoSize = true;
            this.ModeTile.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModeTile.Location = new System.Drawing.Point(57, 67);
            this.ModeTile.Name = "ModeTile";
            this.ModeTile.Size = new System.Drawing.Size(239, 28);
            this.ModeTile.TabIndex = 0;
            this.ModeTile.Text = "Choose the diffculity:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 621);
            this.Controls.Add(this.ModeMenu);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ModeMenu.ResumeLayout(false);
            this.ModeMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel ModeMenu;
        private System.Windows.Forms.Button Hard;
        private System.Windows.Forms.Button Meduim;
        private System.Windows.Forms.Button Easy;
        private System.Windows.Forms.Label ModeTile;
    }
}

