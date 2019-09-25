using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.DomainService.Filtering;
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

        public FilteringList<Owner> GetOwners(Filter filter)
        {
            return _ownerRepo.ReadOwners(filter);
        }

        public Owner Update(Owner ownerToUpdate)
        {
            var owner = FindOwnerById(ownerToUpdate.id);
            owner.firstName = ownerToUpdate.firstName;
            owner.lastName = ownerToUpdate.lastName;
            owner.Address = ownerToUpdate.Address;
            owner.petHistory = ownerToUpdate.petHistory;

            return _ownerRepo.UpdateOwner(owner);
        }

        public Owner newOwner(string firstName, string lastName, string address, List<PetOwner> petHistory)
        {
            var owner = new Owner()
            {
                firstName = firstName,
                lastName = lastName,
                Address = address,
                petHistory = petHistory
            };
            return owner;
        }
    }
}
