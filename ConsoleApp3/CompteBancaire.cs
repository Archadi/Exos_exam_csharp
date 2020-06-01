using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class CompteBancaire
    {
        //ATTRIBUT
        private String tituaire;
        private decimal solde;
        private String devise;

        public int nbCompte;


        //CONSTRUCTEUR
        public CompteBancaire(String leTitulaire, decimal leSolde, String laDevise) {
            this.tituaire = leTitulaire;
            this.solde = leSolde;
            this.devise = laDevise;
        }
        ~CompteBancaire()
        {
            Console.WriteLine("Objet détruit");
        }

        //ACCESSEURS
        public String Titulaire { get; set; }
        public decimal Solde { get; set; }
        public String Devise { get; set; }

        //METHODES
        public void Crediter(decimal cdt)
        {
            this.solde += cdt;
        }

        public void Debiter(decimal cdt)
        {
            this.solde -= cdt;
        }

        public String Decrire()
        {
            return "Titulaire : " + this.tituaire + " ; Solde : " + this.solde + " " + this.devise;
        }



    }
}
