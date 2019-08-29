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

        public Pet Update(Pet petToUpdate, Pet updatedPet)
        {
            return _petRepo.UpdatePet(petToUpdate, updatedPet);
        }
    }
}
