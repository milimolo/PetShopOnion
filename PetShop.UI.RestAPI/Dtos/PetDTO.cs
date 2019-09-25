using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.UI.RestAPI.Dtos
{
    public class PetDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string  Type { get; set; }

        public DateTime Birthday { get; set; }
    }
}
