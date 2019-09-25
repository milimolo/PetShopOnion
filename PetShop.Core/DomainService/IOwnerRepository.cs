using PetShop.Core.DomainService.Filtering;
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

        FilteringList<Owner> ReadOwners(Filter filter);

        Owner UpdateOwner(Owner ownerUpdate);
    }
}

