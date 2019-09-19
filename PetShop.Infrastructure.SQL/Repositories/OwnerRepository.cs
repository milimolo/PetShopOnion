using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.SQL.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private PetAppContext _context;

        public OwnerRepository(PetAppContext context)
        {
            _context = context;
        }
        public Owner CreateOwner(Owner owner)
        {
            if (owner != null)
            {
                _context.Attach(owner).State = EntityState.Added;
            }
            var ownerSaved = _context.owners.Add(owner).Entity;
            _context.SaveChanges();
            return owner;
        }

        public Owner DeleteOwner(int id)
        {
            var entityToRemove = _context.Remove(new Owner { id = id }).Entity;
            _context.SaveChanges();
            return entityToRemove;
        }

        public Owner ReadOwner(int id)
        {
            var foundOwner = _context.owners.FirstOrDefault(o => o.id == id);
            return foundOwner;
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return _context.owners.ToList();
        }

        public Owner UpdateOwner(Owner ownerUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
