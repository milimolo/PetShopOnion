using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entity
{
    public class PetOwner
    {
        public int Id { get; set; }
        public int ownerId { get; set; }
        public Owner owner { get; set; }
        public int petId { get; set; }
        public Pet pet { get; set; }
    }
}
