using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Dictionaire:Exercice
            Dictionary<String, int> leDico = new Dictionary<String, int>();
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
            for(int i = 0; i < 2; i++)
            {
                Console.Write("Entrez un prénon et nom de famille : ");
                Console.WriteLine();

            }
            foreach (KeyValuePair<String, int> itm in leDico)
            {
                Console.WriteLine("{0} a {1} ans", itm.Key, itm.Value);
            }
            
            #endregion Dictionaire:Exercice

            Console.Read();
        }
    }
}
