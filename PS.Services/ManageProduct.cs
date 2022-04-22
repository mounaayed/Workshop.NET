using PS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Services
{
    public class ManageProduct //zidou public bech tekoun visible fi kol

    //ne5edemou bil anonyme 5ater on va utiliser la méthode dans cette classe et ne va pas etre utilisé par
    //d autres classe,peuvent etre appelé dans dautre methodes,utlisiw mara bara barka ba3ed on n a plus besoin(on ne va plus utiliser)
    {

        public List<Product> lsProduct { get; set; }

        //ye5ou char yeraja3 list product
        public Func<char, List<Product>> FindProduct; //definie delegue vers un methode anonyme qui a un type de retour  //type entre w le5era type sortie
        //pour affecter une valeur a findproduct lezem tet3ada 3la methode qui a un nom,on a choisie le constructeur de classe
        public Action<Category> ScanProduct;   //n pas de type de retour

        //interogation des sources de données,collection(bil link wala lambda expression)
        public List<Product> Methode1(char c)
        {
            var req = from p in lsProduct
                      where p.Name.StartsWith(c)
                      select p;
            return req.ToList();
        }

        public List<Product> Methode2(char c)
        {
            var req = from p in lsProduct
                      where p.Name.EndsWith(c)
                      select p;
            return req.ToList();
            //select bech selectionnit chnowa te7eb wa7da barka /to list lezem lista  
            //par defualt inumerable donc lezem tolist()
        }
        public ManageProduct()
        {
            FindProduct = Methode1; //5ater 3andou nafes sugnature
            FindProduct = Methode2;
            FindProduct = c =>
            {
                //eli ba3ed findproduct hiya methode anonyme
                var req = from p in lsProduct
                          where p.Name.StartsWith(c)
                          select p;
                return req.ToList();
            };  //mthode sans nom
            //FindProduct tenajem ta3tiha methode o5era mouhem nafes signature

            ScanProduct = cat =>
            {
                var req = from p in lsProduct
                          where p.Category.CategoryId == cat.CategoryId
                          select p;
                foreach (Product p in req)
                {
                    Console.WriteLine(p);
                }

            };


        }

        public IEnumerable<Chemical> GetChemicals(double price)
        {
            var req = from p in lsProduct.OfType<Chemical>()
                      where p.Price >= price
                      select p;
            var req2 = lsProduct.Where(p => p.Price > price).OfType<Chemical>();
            return req2.Take(5);
            //bech te5ou 5 preomer
            //ignorer 2 
            //  return req2.Skip(2);
            //IEnumerable(hiya interface) ki tebda 3andek list simple 5aliweha hakéké ma3adech tolist() 5ater optimisé lil systeme w 
            //ken te7teb manipuli 3la list héthika temchi teraja3 list 5ater heriti minha w tezid 3liha functionet 

        }

        public double GetAveragePrice()
        {
            return lsProduct.Average(p => p.Price); //ken bil mapda exression héthouma 
        }
        public double GetMaxPrice()
        {
            return lsProduct.Max(p => p.Price); //ken bil mapda exression héthouma 
        }

        public Product GetMaxProductPrice()
        {
            var maxprice = lsProduct.Max(p => p.Price);
            return lsProduct.Where(p => p.Price == maxprice).First();
        }





        public int GetCountProduct(string city)
        { 
            //var req1 = from p in lsProduct.OfType<Chemical>()
            //           where p.City.Equals(city)
            //           select p;

            //return req1.Count();
            var req2 = lsProduct.OfType<Chemical>().Where(p => p.Adresse.City.Equals(city));
            return req2.Count(); //jasser
        }

        public IEnumerable<Chemical> GetChemicalCity()
        {
            //var req1 = from p in lsProduct.OfType<Chemical>()
            //           orderby p.City descending
            //           select p;
            //return req1;
            var req2 = lsProduct.OfType<Chemical>().OrderBy(p => p.Adresse.City);
            return req2; //jasser
        }

        public IEnumerable<IGrouping<String, Chemical>> GetChemicalGroupByCity()
        {
            //var req1 = from p in lsProduct.OfType<Chemical>()
            //           orderby p.City  //ordre mouhem 
            //           group p by p.City ;
            //  foreach(var g in req1)
            //{
            //    Console.WriteLine(g.Key);     //min 3and profa //parcouri groupe w eli fi west groupe  //key valeur critere de goupement 
            //    foreach (var v in g)
            //    {
            //        Console.WriteLine(v);
            //    }

            //}
            //return req1;   //void cheye7a héthi min fou9 retour 

            //pas de select fi group by

            var req2 = lsProduct.OfType<Chemical>().OrderByDescending(p => p.Adresse.City).GroupBy(p => p.Adresse.City);
            return req2; //jasser
        }
    }
}
