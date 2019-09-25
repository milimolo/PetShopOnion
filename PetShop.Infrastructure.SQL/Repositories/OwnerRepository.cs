using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.DomainService.Filtering;
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
            return _context.owners
                .Include(o => o.petHistory)
                .ThenInclude(po => po.pet)
                .FirstOrDefault(o => o.id == id);
        }

        public FilteringList<Owner> ReadOwners(Filter filter)
        {
            var filteredList = new FilteringList<Owner>();

            if (filter != null && filter.CurrentPage > 0 && filter.ItemsPrPage > 0)
            {
                filteredList.List = _context.owners
                    .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                    .Take(filter.ItemsPrPage)
                    .OrderBy(o => o.id)
                    .Include(p => p.petHistory)
                    .ThenInclude(po => po.pet)
                    .ToList();
                return filteredList;
            }
            filteredList.List = _context.owners
                .Include(p => p.petHistory)
                .ThenInclude(po => po.pet);
            filteredList.count = filteredList.List.Count();
            return filteredList;
        }

        public Owner UpdateOwner(Owner ownerUpdate)
        {
            if (ownerUpdate != null)
            {
                _context.Attach(ownerUpdate).State = EntityState.Added;
                _context.Entry(ownerUpdate).Collection(o => o.petHistory).IsModified = true;
            }
            var ownerSaved = _context.owners.Update(ownerUpdate).Entity;
            _context.SaveChanges();
            return ownerUpdate;
        }
    }
}
