namespace Init_09_10
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_chx_rep = new System.Windows.Forms.Button();
            this.btn_lecture = new System.Windows.Forms.Button();
            this.btn_lst_titres = new System.Windows.Forms.Button();
            this.tbx_rep_crt = new System.Windows.Forms.TextBox();
            this.tbx_titre = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.titre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chemin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(12, 130);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(614, 117);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.titre,
            this.chemin});
            this.dataGridView1.Location = new System.Drawing.Point(12, 262);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(614, 150);
            this.dataGridView1.TabIndex = 1;
            // 
            // btn_chx_rep
            // 
            this.btn_chx_rep.Location = new System.Drawing.Point(13, 13);
            this.btn_chx_rep.Name = "btn_chx_rep";
            this.btn_chx_rep.Size = new System.Drawing.Size(91, 23);
            this.btn_chx_rep.TabIndex = 2;
            this.btn_chx_rep.Text = "Choix répertoire";
            this.btn_chx_rep.UseVisualStyleBackColor = true;
            this.btn_chx_rep.Click += new System.EventHandler(this.btn_chx_rep_Click);
            // 
            // btn_lecture
            // 
            this.btn_lecture.Location = new System.Drawing.Point(178, 13);
            this.btn_lecture.Name = "btn_lecture";
            this.btn_lecture.Size = new System.Drawing.Size(75, 23);
            this.btn_lecture.TabIndex = 3;
            this.btn_lecture.Text = "Lecture";
            this.btn_lecture.UseVisualStyleBackColor = true;
            this.btn_lecture.Click += new System.EventHandler(this.btn_lecture_Click);
            // 
            // btn_lst_titres
            // 
            this.btn_lst_titres.Location = new System.Drawing.Point(319, 13);
            this.btn_lst_titres.Name = "btn_lst_titres";
            this.btn_lst_titres.Size = new System.Drawing.Size(75, 23);
            this.btn_lst_titres.TabIndex = 4;
            this.btn_lst_titres.Text = "Liste Titres";
            this.btn_lst_titres.UseVisualStyleBackColor = true;
            this.btn_lst_titres.Click += new System.EventHandler(this.btn_lst_titres_Click);
            // 
            // tbx_rep_crt
            // 
            this.tbx_rep_crt.Location = new System.Drawing.Point(13, 62);
            this.tbx_rep_crt.Name = "tbx_rep_crt";
            this.tbx_rep_crt.Size = new System.Drawing.Size(381, 20);
            this.tbx_rep_crt.TabIndex = 5;
            // 
            // tbx_titre
            // 
            this.tbx_titre.Location = new System.Drawing.Point(12, 104);
            this.tbx_titre.Name = "tbx_titre";
            this.tbx_titre.Size = new System.Drawing.Size(241, 20);
            this.tbx_titre.TabIndex = 6;
            // 
            // titre
            // 
            this.titre.HeaderText = "Titre";
            this.titre.Name = "titre";
            // 
            // chemin
            // 
            this.chemin.HeaderText = "Chemin";
            this.chemin.Name = "chemin";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 433);
            this.Controls.Add(this.tbx_titre);
            this.Controls.Add(this.tbx_rep_crt);
            this.Controls.Add(this.btn_lst_titres);
            this.Controls.Add(this.btn_lecture);
            this.Controls.Add(this.btn_chx_rep);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btn_chx_rep;
        private System.Windows.Forms.Button btn_lecture;
        private System.Windows.Forms.Button btn_lst_titres;
        private System.Windows.Forms.TextBox tbx_rep_crt;
        private System.Windows.Forms.TextBox tbx_titre;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn titre;
        private System.Windows.Forms.DataGridViewTextBoxColumn chemin;
    }
}

