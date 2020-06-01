using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public  static string Codage(String mot)
        {
            char char0 = Convert.ToChar(((int)mot[0] + 3) % 122 == (int)mot[0] + 3 ? (int)mot[0] + 3 : 97 + 2 );
            char char1 = Convert.ToChar(((int)mot[1] + 3) % 122 == (int)mot[1] + 3 ? (int)mot[1] + 3 : 97 + 2);
            char char2 = Convert.ToChar(((int)mot[2] + 3) % 122 == (int)mot[2] + 3 ? (int)mot[2] + 3 : 97 + 2);
            char char3 = Convert.ToChar(((int)mot[3] + 3) % 122 == (int)mot[3] + 3 ? (int)mot[3] + 3 : 97 + 2);
            char char4 = Convert.ToChar(((int)mot[4] + 3) % 122 == (int)mot[4] + 3 ? (int)mot[4] + 3 : 97 + 2);

            string motConvert = char0 + "" + char1 + "" + char2+ "" +char3 +""+ char4;

            return motConvert;
        }
        static void Main(string[] args)
        {
            #region Ex1

            //affection du variable par calcule
            /*Double var = (12+5*12.5-1253.68);

            //calcule de la moyonne
            List<Double> notes = new List<double> {1.0, 5.5, 9.9, 2.8, 9.6 };
            Double moy = notes.Average();*/

            #endregion Ex1

            #region Ex2

            /*Console.Write("Entrez la valeur du rayon : ");
            Double rayon = Convert.ToDouble(Console.ReadLine());

            Double perimetre = 2 * Math.PI * rayon;
            Double surface = 2 * Math.PI * Math.Pow(rayon, 2.0);

            Console.WriteLine("Le perimetre du cercle est égale à "+ Math.Round(perimetre, 2) +" cm");
            Console.WriteLine("La surface du cercle est égale à " + Math.Round(surface, 2) + " cm2");*/

            #endregion Ex2

            #region Ex3
            /*Console.Write("Tapez un mot : ");
            String mot = Console.ReadLine();
            Console.WriteLine(Codage(mot));*/

            #endregion Ex3

            #region Ex4
            /*String affichage = "un peu\n";
            affichage += "beaucoup\n";
            affichage += "passionnément\n";
            affichage += "\"je t'aime\" dit-elle\n";
            affichage += "le fichier à importer est Z:\\mpsi\\file.txt\n";
            Console.Write(affichage);*/

            #endregion Ex4


            #region Tableau:Exercice
            /*int[] age = new int[6] { 20, 14, 22, 19, 25, 15, };
            String[] prenom = new String[6] { "Ali", "Tom", "Toto", "Zoé", "Joé", "Léo", };
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine(prenom[i] + ":" + age[i]);
            }*/

            #endregion Tableau:Exercice

            #region Liste:Exercice
            /*var fruits = new List<string> { "banane", "fraise", "cerise", "kiwi", "orange"};
            fruits.Remove("banane");
            fruits.ForEach(fruit => Console.WriteLine(fruit + ""));*/
            #endregion Liste:Exercice

            #region Dictionaire:Exercice
            /*Dictionary<String, int> leDico = new Dictionary<String, int>();
            leDico.Add("Léo Favo", 29);
            leDico.Add("Tom Kabel", 78);
            leDico.Add("Ali Jhon", 12);
            leDico.Add("Zoé Lucas", 45);
            leDico.Add("Léa Mulo", 30);
            leDico.Add("Mao Tazma", 16);
            String item3 = leDico.ElementAt(3).Key;
            String item5 = leDico.ElementAt(5).Key;
            leDico.Remove(item3);
            leDico.Remove(item5);
            String nom;
            int age;
            for (int i = 0; i < 2; i++)
            {
                Console.Write("Entrez un prénon et nom de famille : ");
                Console.WriteLine();

            }
            foreach (KeyValuePair<String, int> itm in leDico)
            {
                Console.WriteLine("{0} a {1} ans", itm.Key, itm.Value);
            }*/

            #endregion Dictionaire:Exercice

            #region Boucles:Exercice
            /*for(int i = 0; i <= 20; i++)
            {
                if (i % 2 == 0)
                    Console.Write(i+"; ");
            }
            Console.WriteLine("");
            Console.WriteLine("******************");

            Console.Write("Entrez un nombre : ");
            int scNb;
            int.TryParse(Console.ReadLine(), out scNb);
            int sum = 0;
            for(int i = 0; i <= scNb; i++)
            {
                sum += i;
            }
            Console.WriteLine("Somme = {0}", sum);
            Console.WriteLine("");
            Console.WriteLine("******************");*/
            #endregion Boucles:Exercice

            Console.ReadKey();
        }
    }
}
