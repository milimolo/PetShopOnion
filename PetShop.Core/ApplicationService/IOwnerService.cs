using PetShop.Core.DomainService.Filtering;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService
{
    public interface IOwnerService
    {
        Owner newOwner(string firstName, string lastName, string address, List<PetOwner> petHistory);
        Owner Create(Owner owner);

        Owner Delete(int id);

        Owner FindOwnerById(int id);

        FilteringList<Owner> GetOwners(Filter filter);

        Owner Update(Owner ownerToUpdate);
    }
}
