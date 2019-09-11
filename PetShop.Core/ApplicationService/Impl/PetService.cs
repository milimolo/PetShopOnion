using PetShop.Core.ApplicationService;
using PetShop.Core.DomainService;
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
                previousOwner = previousOwner,
                price = price
            };
            return pet;
        }

        public Pet Create(Pet pet)
        {
            return _petRepo.CreatePet(pet);
        }

        public Pet Delete(Pet pet)
        {
            return _petRepo.DeletePet(pet);
        }

        public Pet FindPetById(int id)
        {
            return _petRepo.ReadPet(id);
        }

        public List<Pet> GetPets()
        {
            return _petRepo.ReadPets().ToList();
        }

        public Pet Update(Pet petToUpdate)
        {
            var pet = FindPetById(petToUpdate.ID);
            pet.name = petToUpdate.name;
            pet.type = petToUpdate.type;
            pet.birthday = petToUpdate.birthday;
            pet.soldDate = petToUpdate.soldDate;
            pet.color = petToUpdate.color;
            pet.previousOwner = petToUpdate.previousOwner;
            pet.price = petToUpdate.price;

            return _petRepo.UpdatePet(pet);
        }
        public List<Pet> ListSortedByPrice(List<Pet> pets)
        {
            pets = pets.OrderBy(pet => pet.price).ToList();
            return pets;
        }
    }
}
