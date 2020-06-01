namespace SnakeGame
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
			this.components = new System.ComponentModel.Container();
			this.screen = new System.Windows.Forms.PictureBox();
			this.textGameOver = new System.Windows.Forms.Label();
			this.buttonStart = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.screen)).BeginInit();
			this.SuspendLayout();
			// 
			// screen
			// 
			this.screen.Location = new System.Drawing.Point(9, 10);
			this.screen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.screen.Name = "screen";
			this.screen.Size = new System.Drawing.Size(600, 600);
			this.screen.TabIndex = 0;
			this.screen.TabStop = false;
			// 
			// textGameOver
			// 
			this.textGameOver.AutoSize = true;
			this.textGameOver.BackColor = System.Drawing.Color.Transparent;
			this.textGameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textGameOver.ForeColor = System.Drawing.Color.Red;
			this.textGameOver.Location = new System.Drawing.Point(120, 184);
			this.textGameOver.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.textGameOver.Name = "textGameOver";
			this.textGameOver.Size = new System.Drawing.Size(363, 73);
			this.textGameOver.TabIndex = 1;
			this.textGameOver.Text = "Game Over";
			// 
			// buttonStart
			// 
			this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonStart.Location = new System.Drawing.Point(176, 310);
			this.buttonStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(233, 99);
			this.buttonStart.TabIndex = 2;
			this.buttonStart.Text = "Start";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(618, 621);
			this.Controls.Add(this.buttonStart);
			this.Controls.Add(this.textGameOver);
			this.Controls.Add(this.screen);
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "Form1";
			this.Text = "Snake by HowCSharp.Com";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.screen)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox screen;
        private System.Windows.Forms.Label textGameOver;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Timer timer1;
    }
}

