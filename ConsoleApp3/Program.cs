using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Article art1 = new Article();
            Article art2 = new Article("A1234", "Tube");
            Article art3 = new Article("B9874", "Prise", 2.03m, 0.2m);
            Article art4 = new Article(art1);

            CompteBancaire cb1 = new CompteBancaire("Téo Tom", 1245.2m, "EUR");
            Console.WriteLine(cb1.Decrire());

            cb1.Debiter(245);
            Console.WriteLine(cb1.Decrire());

            cb1.Crediter(500);
            Console.WriteLine(cb1.Decrire());


            art1.AfficherArticle();
            art2.AfficherArticle();
            art3.AfficherArticle();
            art4.AfficherArticle();*/

            
            Console.WriteLine(ClasseChaine.RetourneInitiales("Gita", "Toms"));

            Console.ReadKey();
        }

    }
}
