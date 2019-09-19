using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService
{
    public interface IOwnerRepository
    {
        Owner CreateOwner(Owner owner);

        Owner DeleteOwner(int id);

        Owner ReadOwner(int id);

        IEnumerable<Owner> ReadOwners();

        Owner UpdateOwner(Owner ownerUpdate);
    }
}

