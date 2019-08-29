using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        IEnumerable<Pet> pets;
        public IEnumerable<Pet> ReadPets()
        {
            return pets;
        }
    }
}
