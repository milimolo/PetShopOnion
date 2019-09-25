using PetShop.Core.ApplicationService;
using PetShop.Core.DomainService;
using PetShop.Core.DomainService.Filtering;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.Repositories
{
    public class PetService : IPetService
    {
        readonly IPetRepository _petRepo;
        public PetService(IPetRepository petRepository)
        {
            _petRepo = petRepository;
        }

        public Pet NewPet(string name, string type, DateTime birthday, DateTime dateSold, string color, Owner previousOwner, int price)
        {
            var pet = new Pet()
            {
                name = name,
                type = type,
                birthday = birthday,
                soldDate = dateSold,
                color = color,
                price = price
            };
            return pet;
        }

        public Pet Create(Pet pet)
        {
            validatePet(pet);
            return _petRepo.CreatePet(pet);
        }

        public Pet Delete(int id)
        {
            return _petRepo.DeletePet(id);
        }

        public Pet FindPetById(int id)
        {
            return _petRepo.ReadPetById(id);
        }

        public FilteringList<Pet> GetPets(Filter filter = null)
        {
            return _petRepo.ReadPets(filter);
        }

        public Pet Update(Pet petToUpdate)
        {
            var pet = FindPetById(petToUpdate.ID);
            pet.name = petToUpdate.name;
            pet.type = petToUpdate.type;
            pet.birthday = petToUpdate.birthday;
            pet.soldDate = petToUpdate.soldDate;
            pet.color = petToUpdate.color;
            pet.price = petToUpdate.price;
            pet.ownersHistory = petToUpdate.ownersHistory;

            return _petRepo.UpdatePet(pet);
        }
        public List<Pet> ListSortedByPrice(List<Pet> pets)
        {
            pets = pets.OrderBy(pet => pet.price).ToList();
            return pets;
        }

        private void validatePet(Pet pet)
        {
            
        }

    }
}
