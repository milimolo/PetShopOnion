using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService
{
    public interface IPetRepository
    {
        Pet CreatePet(Pet pet);

        Pet DeletePet(Pet pet);

        Pet ReadPet(int id);

        IEnumerable<Pet> ReadPets();

        Pet UpdatePet(Pet petUpdate);
    }
}
