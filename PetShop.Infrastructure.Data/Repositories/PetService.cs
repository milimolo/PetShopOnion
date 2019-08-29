using PetShop.Core.ApplicationService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Repositories
{
    public class PetService : IPetService
    {
        static int id = 1;
        private List<Pet> _petList = new List<Pet>();

        public Pet Create(Pet pet)
        {
            throw new NotImplementedException();
        }

        public Pet FindPetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pet> GetPets()
        {
            return _petList;
        }

        public Pet Update(Pet petUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
