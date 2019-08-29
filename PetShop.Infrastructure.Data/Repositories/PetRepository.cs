using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        private List<Pet> _pets = new List<Pet>();

        public Pet CreatePet(Pet pet)
        {
            pet.ID = FakeDB.id++;
            List<Pet> pets = FakeDB.petList.ToList();
            pets.Add(pet);
            FakeDB.petList = pets;
            return pet;
        }

        public Pet DeletePet(Pet pet)
        {
            List<Pet> pets = FakeDB.petList.ToList();
            pets.Remove(pet);
            FakeDB.petList = pets;
            return pet;
        }

        public Pet ReadPet(int id)
        {
            List<Pet> pets = FakeDB.petList.ToList();
            foreach (var pet in pets)
            {
                if(id == pet.ID)
                {
                    return pet;
                }
            }
            return null;
        }

        public IEnumerable<Pet> ReadPets()
        {
            return FakeDB.petList;
        }

        public Pet UpdatePet(Pet petUpdate)
        {
            var pet = this.ReadPet(petUpdate.ID);
            if(pet != null)
            {
                pet.name = petUpdate.name;
                pet.type = petUpdate.type;
                pet.birthday = petUpdate.birthday;
                pet.soldDate = petUpdate.soldDate;
                pet.color = petUpdate.color;
                pet.previousOwner = petUpdate.previousOwner;
                pet.price = petUpdate.price;
                return pet;
            }
            return null;
        }
    }
}
