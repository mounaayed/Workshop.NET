using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PS.Domain
{
    public class Client
    {//nafes client yechri méme produit ca ne se passe pas ahawka 3leh negedou haka(table porteuse de donnée ma3adech manymany)
        [Key]
        public int Cin { get; set; }
        public DateTime DateNaissance { get; set; }
        public string email { get; set; }

        public string nom { get; set; }
        public string Prenom { get; set; }


        public virtual List<Achat> Achats { get; set; }

    }
}
