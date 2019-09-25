using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entity
{
    public class Pet
    {
        public int ID { get; set; }

        public string name { get; set; }

        public string type { get; set; }

        public DateTime birthday { get; set; }

        public DateTime soldDate { get; set; }

        public string color { get; set; } 

        public double price { get; set; }
        public List<PetOwner> ownersHistory { get; set; }
    }
}
