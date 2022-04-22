using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{
    [Owned]
   public  class Adresse
    {

        //7otouch id w des relations
        //dima marboutin me3a be3athehom ki recuperihom jibhom fard mara (optimisation requette)
        public int StreetAdress { get; set; }
        public string City { get; set; }

    }
}
