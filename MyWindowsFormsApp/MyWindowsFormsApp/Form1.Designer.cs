﻿namespace MyWindowsFormsApp
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Tbx_User_Name = new System.Windows.Forms.TextBox();
            this.Tbx_Password = new System.Windows.Forms.TextBox();
            this.Bt_Login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // Tbx_User_Name
            // 
            this.Tbx_User_Name.Location = new System.Drawing.Point(165, 45);
            this.Tbx_User_Name.Name = "Tbx_User_Name";
            this.Tbx_User_Name.Size = new System.Drawing.Size(100, 20);
            this.Tbx_User_Name.TabIndex = 2;
            // 
            // Tbx_Password
            // 
            this.Tbx_Password.Location = new System.Drawing.Point(165, 96);
            this.Tbx_Password.Name = "Tbx_Password";
            this.Tbx_Password.Size = new System.Drawing.Size(100, 20);
            this.Tbx_Password.TabIndex = 3;
            // 
            // Bt_Login
            // 
            this.Bt_Login.Location = new System.Drawing.Point(165, 144);
            this.Bt_Login.Name = "Bt_Login";
            this.Bt_Login.Size = new System.Drawing.Size(75, 23);
            this.Bt_Login.TabIndex = 4;
            this.Bt_Login.Text = "Login";
            this.Bt_Login.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Bt_Login);
            this.Controls.Add(this.Tbx_Password);
            this.Controls.Add(this.Tbx_User_Name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Tbx_User_Name;
        private System.Windows.Forms.TextBox Tbx_Password;
        private System.Windows.Forms.Button Bt_Login;
    }
}

