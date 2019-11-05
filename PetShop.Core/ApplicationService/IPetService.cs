using PetShop.Core.DomainService.Filtering;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService
{
    public interface IPetService
    {
        Pet NewPet(string name, string type, DateTime birthday, DateTime dateSold, string color, Owner previousOwner, int price);

        Pet Create(Pet pet);

        Pet Delete(int id);

        Pet FindPetById(int id);

        List<Pet> GetPets(Filter filter = null);

        Pet Update(Pet petToUpdate);

        List<Pet> ListSortedByPrice(List<Pet> pets);
    }
}
