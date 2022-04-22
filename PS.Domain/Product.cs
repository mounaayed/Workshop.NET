using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PS.Domain
{
   public class Product
    {
        public virtual List<Achat> Achats { get; set; }

        public int ProductId { get; set; }

        [Required(ErrorMessage="name is reuquired")]
        [MaxLength(25,ErrorMessage ="you allowed to write only 25 character")]
        [StringLength(50)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]

        public double Price { get; set; }

        [Display(Name="production date")]
        [DataType(DataType.Date)]

        public DateTime DateProd { get; set; }
        [DataType(DataType.MultilineText)]

        public string  Description { get; set; }
        [Range(0,int.MaxValue)]
        public int Quantity { get; set; }

        public string ImageName { get; set; }

       // [ForeignKey("CategoryFK")]

        public virtual Category Category { get; set; }

       [ForeignKey("Category")]
        public int? CategoryFK { get; set; }  //fil base 3emalt chay te9oulech 3liya //bech direct tewali tod5el houni id moch category.categoryid
        //0 * 
        public  virtual List<Provider> Providers { get; set; }

      //  public virtual ICollection<Provider> Providers { get; set; }  lazy loading : par default yejibled ken attribut normal lezem prodcut.providers bech yejibhom


        public Product()
        {
            //ctro

        }

        public override string ToString()
        {
            return "name : " + Name + " description : "+Description + " dateeeeee : " +DateProd;
        }

        //         * forcer le passage par reference /

        public void Calculer(int a , int b ,ref int c)
        {
            c = a + b;
            Console.WriteLine(c);
        }

        public virtual void GetMyType()

        {

            Console.WriteLine("je suis un produit");
        }

    }
}
