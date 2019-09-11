using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        public Owner CreateOwner(Owner owner)
        {
            owner.id = FakeDB.ownerID++;
            List<Owner> owners = FakeDB.ownerList.ToList();
            owners.Add(owner);
            FakeDB.ownerList = owners;
            return owner;
        }

        public Owner DeleteOwner(Owner owner)
        {
            List<Owner> owners = FakeDB.ownerList.ToList();
            owners.Remove(owner);
            FakeDB.ownerList = owners;
            return owner;
        }

        public Owner ReadOwner(int id)
        {
            List<Owner> owners = FakeDB.ownerList.ToList();
            foreach (var owner in owners)
            {
                if (id == owner.id)
                {
                    return owner;
                }
            }
            return null;
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return FakeDB.ownerList;
        }

        public Owner UpdateOwner(Owner ownerUpdate)
        {
            var owner = this.ReadOwner(ownerUpdate.id);
            if(owner != null)
            {
                owner.firstName = ownerUpdate.firstName;
                owner.lastName = ownerUpdate.lastName;
                owner.pets = ownerUpdate.pets;
                return owner;
            }
            return null;
        }
    }
}
