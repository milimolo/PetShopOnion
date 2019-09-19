using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService
{
    public class OwnerService : IOwnerService
    {
        readonly IOwnerRepository _ownerRepo;
        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepo = ownerRepository;
        }

        public Owner createOwner(string firstName, string lastName)
        {
            var owner = new Owner()
            {
                firstName = firstName,
                lastName = lastName
            };
            return owner;
        }

        public Owner Create(Owner owner)
        {
            return _ownerRepo.CreateOwner(owner);
        }

        public Owner Delete(int id)
        {
            return _ownerRepo.DeleteOwner(id);
        }

        public Owner FindOwnerById(int id)
        {
            return _ownerRepo.ReadOwner(id);
        }

        public List<Owner> GetOwners()
        {
            return _ownerRepo.ReadOwners().ToList();
        }

        public Owner Update(Owner ownerToUpdate)
        {
            var owner = FindOwnerById(ownerToUpdate.id);
            owner.firstName = ownerToUpdate.firstName;
            owner.lastName = ownerToUpdate.lastName;
            owner.pets = ownerToUpdate.pets;

            return _ownerRepo.UpdateOwner(owner);
        }

        public Owner newOwner(string firstName, string lastName, List<Pet> pets)
        {
            var owner = new Owner()
            {
                firstName = firstName,
                lastName = lastName,
                pets = pets
            };
            return owner;
        }
    }
}
