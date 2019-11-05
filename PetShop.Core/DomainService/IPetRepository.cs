using PetShop.Core.DomainService.Filtering;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService
{
    public interface IPetRepository
    {
        Pet CreatePet(Pet pet);

        Pet DeletePet(int id);

        Pet ReadPetById(int id);

        IEnumerable<Pet> ReadPets(Filter filter);

        Pet UpdatePet(Pet petUpdate);
    }
}
