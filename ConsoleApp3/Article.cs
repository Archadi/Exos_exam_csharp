using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Article
    {
        //ATTRIBUTS
        private String reference, designasion;
        private decimal prixHt;
        private static decimal tauxTva = 0.2m;

        //ACCESSEURS
        public string Reference { get => reference; set => reference = value; }
        public string Designasion { get => designasion; set => designasion = value; }
        public decimal PrixHt { get => prixHt; set => prixHt = value; }
        //public decimal TauxTva { get => tauxTva; set => tauxTva = value; }

        //CONSTRUCTEURS
        public Article()
        {
            Console.WriteLine("Article crée");
        }

        ~Article()
        {
            Console.WriteLine("Article détruit");
        }
        public Article(string reference, string designasion, decimal prixHt, decimal tauxTva)
        {
            this.reference = reference;
            this.designasion = designasion;
            this.prixHt = prixHt;
            //this.TauxTva = tauxTva;
        }

        public Article(string reference, string designasion)
        {
            this.reference = reference;
            this.designasion = designasion;

        }

        public Article(Article unArticle)
        {
            this.reference = unArticle.reference;
            this.designasion = unArticle.designasion;
            this.prixHt = unArticle.prixHt;
            //this.TauxTva = unArticle.tauxTva;
        }

        //METHODES

        public decimal CalculerPrixTTC()
        {
            return this.prixHt + (this.prixHt * (tauxTva / 100));
        }

        public void AfficherArticle()
        {
            decimal prixTtc = CalculerPrixTTC();
            Console.WriteLine("Réf : {0}\nDésigantion : {1}\nPrixHT : {2}\nTauxTVA : {3}\nPrixTTC : {4}", this.reference, this.designasion, this.prixHt, tauxTva, prixTtc);
            Console.WriteLine("-----");
        }

    }
}
