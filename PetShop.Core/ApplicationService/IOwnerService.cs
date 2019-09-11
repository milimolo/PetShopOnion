using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService
{
    public interface IOwnerService
    {
        Owner newOwner(string firstName, string lastName, List<Pet> pets);
        Owner Create(Owner owner);

        Owner Delete(Owner owner);

        Owner FindOwnerById(int id);

        List<Owner> GetOwners();

        Owner Update(Owner ownerToUpdate);
    }
}
