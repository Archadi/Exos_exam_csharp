using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Init_09_10
{
    public partial class Form1 : Form
    {
        Lecteur lecteur = new Lecteur();
        public Form1()
        {
            InitializeComponent();
            lecteur.SetCheminDeBase(@"D:\Documents\M1IL\Csharp init\sons");
            tbx_rep_crt.Text = lecteur.GetCheminDeBase();
            axWindowsMediaPlayer1.ErrorEvent += new EventHandler(player_ErrorEvent);
            
        }

        private void dataGridChage()
        {
            dataGridView1.Rows.Clear();
            foreach (KeyValuePair<string, string> mp3 in lecteur.ListeTitresMp3())
            {
                dataGridView1.Rows.Add(mp3.Key, mp3.Value);
            }
            
        }
        private void player_ErrorEvent(object sender, System.EventArgs e)
        {
            // Get the description of the first error. 
            string errDesc = axWindowsMediaPlayer1.Error.get_Item(0).errorDescription;
            // Display the error description.
            System.Windows.Forms.MessageBox.Show(errDesc);
        }

        private void btn_chx_rep_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Choisissez un répertoire";
            DialogResult dialogResult = folderBrowserDialog1.ShowDialog();

            if (dialogResult.Equals(DialogResult.OK))
            {
                lecteur.SetCheminDeBase(folderBrowserDialog1.SelectedPath);
                dataGridChage();
                tbx_rep_crt.Text = lecteur.GetCheminDeBase();
                //LoadSongTitles();
            }
            else
            {
                lecteur.SetCheminDeBase(folderBrowserDialog1.SelectedPath);
                dataGridChage();
                tbx_rep_crt.Text = lecteur.GetCheminDeBase();
                //lbFolder.Text = "";
            }
        }

        private void btn_lecture_Click(object sender, EventArgs e)
        {
            String encours = lecteur.Joue();
            tbx_titre.Text = encours;
            axWindowsMediaPlayer1.URL = encours;
            lecteur.SetChange();
            dataGridChage();
        }

        private void btn_lst_titres_Click(object sender, EventArgs e)
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            //once you have the path you get the directory with:
            var directory = System.IO.Path.GetDirectoryName(path);
            string fichier = directory + @"\" + "listeMP3.txt";
            fichier = fichier.Replace(@"file:\", "");
            Console.WriteLine(fichier);

            lecteur.SauveListe(@"D:\Documents\M1IL\Csharp init\temp\listeMP3.txt");
        }

        
    }
}
