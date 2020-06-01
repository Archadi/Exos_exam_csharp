using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public static class ClasseChaine
    {
   

        /*public ClasseChaine()
        {
        }*/

        public static String RetourneInitiales(String leNom, String lePrenom)
        {
            if (!string.IsNullOrEmpty(leNom) || !string.IsNullOrEmpty(lePrenom) )
                return leNom.Replace(" ", "")[0] + "." + lePrenom.Replace(" ", "")[0];
            else
                return "";
        }
    }
}
