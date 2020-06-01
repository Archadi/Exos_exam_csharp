using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Init_09_10
{
    class Lecteur
    {
        //Attributs
        private string cheminDeBase;
        private bool change;
        private Random alea;
        private List<string> listeMP3;

        //Méthode
        private void CreerListeMP3(string repertoire)
        {
            listeMP3.Clear();
            if (!String.IsNullOrEmpty(repertoire))
            {
                string[] fichiers = Directory.GetFiles(String.Format(@"{0}", repertoire), "*.mp3");
                foreach (string fichier in fichiers)
                    this.listeMP3.Add(fichier);
            }
        }     

        public void CreerListeTotal(string repertoireCourant)
        {
            listeMP3.Clear();
            if (!String.IsNullOrEmpty(repertoireCourant))
            {
                string[] fichiers = Directory.GetFiles(String.Format(@"{0}", repertoireCourant), "*.mp3", SearchOption.AllDirectories);
                foreach (string fichier in fichiers)
                    this.listeMP3.Add(fichier);
            }
        }

        public void SauveListe(string chemin)
        {
            
            if (listeMP3 != null)
            {
                /*string chm = String.Format(@"{0}", chemin);
            string contenu = "";

            if (File.Exists(chm))
            {
                File.Delete(chm);
            }

            FileStream fs = File.Create(chm);

            foreach (string mp3 in this.listeMP3)
                contenu += mp3 + "\r\n";

            byte[] info = new UTF8Encoding(true).GetBytes(contenu);
            // Add some information to the file.
            fs.Write(info, 0, info.Length);*/

                Console.WriteLine("la liste est chargée");

                string fileName = chemin;

                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                using (StreamWriter sw = File.CreateText(fileName))
                {
                    Console.WriteLine("création du fichier");
                    foreach (String s in listeMP3)
                    {
                        sw.WriteLine(s);
                    }
                }
            }
        }


        public String Joue()
        {
            if (listeMP3 == null)
                listeMP3 = new List<String>();

            if (!String.IsNullOrEmpty(cheminDeBase))
            {
                CreerListeMP3(cheminDeBase);
                alea = new Random();
                int numero = alea.Next(0, listeMP3.Count);
                return listeMP3[numero];
            }
            else
                return "";
        }

        public void SetCheminDeBase(String chemin)
        {
            cheminDeBase = chemin;
        }


        public String GetCheminDeBase()
        {
            return cheminDeBase;
        }

        public void SetChange()
        {
            change = true;
        }

        public Dictionary<string, string> ListeTitresMp3()
        {
            Dictionary<string, string> lstTitresMp3 = new Dictionary<string, string>();
            string trt;
            int indice;
            if (listeMP3 != null)
            {
                
                foreach (string mp3 in this.listeMP3)
                {
                    indice = mp3.LastIndexOf('\\', mp3.Length - 1, mp3.Length);
                    trt = mp3.Substring(indice+1);
                    lstTitresMp3.Add(trt.Replace(".mp3", ""), mp3);
                }
            }
            return lstTitresMp3;
        }
    }
}
