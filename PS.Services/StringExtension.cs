using PS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Services
{
   public static class StringExtension
    {
        //Static classes are sealed and therefore cannot be inherited.
        //lezem classe static w methode static w prendre en prametre un objet de la classe qu on veut ettendre
        public static void UpperName(this string s) //methode extension lil string  //lezem mot clé string   //hakéké tewali mete3ebe3a les méthodes string 
        {
            string c = s[0].ToString();

            s = c.ToUpper() + s.Substring(1);
            Console.WriteLine(s);
            
        }

        public static void UpperNameProvider(this Provider p) //methode extension lil string  //lezem mot clé string   //hakéké tewali mete3ebe3a les méthodes string 
        {
            p.UserName = p.UserName.ToUpper();

        }

        public static bool IntCategory(this Product p,Category c)
        {
            return p.Name.Equals(c.Name); 

        }
    }
}
