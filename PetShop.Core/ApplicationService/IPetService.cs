using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService
{
    public interface IPetService
    {
        Pet Create(Pet pet);

        Pet Delete(Pet pet);

        Pet FindPetById(int id);

        List<Pet> GetPets();

        Pet Update(Pet petToUpdate, Pet updatedPet);
    }
}
