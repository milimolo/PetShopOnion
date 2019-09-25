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
    public class PetRepository : IPetRepository
    {
        private PetAppContext _context;

        public PetRepository(PetAppContext context)
        {
            _context = context;
        }

        public Pet CreatePet(Pet pet)
        {
            if(pet != null)
            {
                _context.Attach(pet).State = EntityState.Added;
                _context.Entry(pet).Collection(p => p.ownersHistory).IsModified = true;
            }
            var petSaved = _context.pets.Add(pet).Entity;
            _context.SaveChanges();
            return petSaved;

            //Begge er gode, men lars synes States er bedre.

            /*var petToCreate = _context.pets.Add(pet).Entity;
            _context.SaveChanges();
            return petToCreate;*/
        }

        public Pet DeletePet(int id)
        {
            var entityRemoved = _context.Remove(new Pet { ID = id }).Entity;
            _context.SaveChanges();
            return entityRemoved;

            //Øverste sender kun 1 request til DB, mens den neden under sender 2.

            /*var removing = _context.pets.FirstOrDefault(p => p.ID == pet.ID);
            _context.Remove(removing);
            _context.SaveChanges();
            return removing;*/
        }

        public Pet ReadPetById(int id)
        {
            return _context.pets
                .Include(o => o.ownersHistory)
                .ThenInclude(po => po.owner)
                .FirstOrDefault(p => p.ID == id);
        }

        public FilteringList<Pet> ReadPets(Filter filter)
        {
            var filteredList = new FilteringList<Pet>();

            if(filter != null && filter.CurrentPage > 0 && filter.ItemsPrPage > 0)
            {
                filteredList.List = _context.pets
                    .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                    .Take(filter.ItemsPrPage)
                    .OrderBy(p => p.ID)
                    .Include(o => o.ownersHistory)
                    .ThenInclude(po => po.owner)
                    .ToList();
                return filteredList;
            }
            filteredList.List = _context.pets
                .Include(o => o.ownersHistory)
                .ThenInclude(po => po.owner);
            filteredList.count = filteredList.List.Count();
            return filteredList;
        }

        public Pet UpdatePet(Pet petUpdate)
        {
            if (petUpdate != null)
            {
                _context.Attach(petUpdate).State = EntityState.Modified;
                //_context.Entry(petUpdate).Collection(p => p.ownersHistory).IsModified = true;
            }
            var petOwners = new List<PetOwner>(petUpdate.ownersHistory ?? new List<PetOwner>());
            _context.petOwners.RemoveRange(
                _context.petOwners.Where(p => p.petId == petUpdate.ID)
                );
            foreach (var po in petOwners)
            {
                _context.Entry(po).State = EntityState.Added;
            }
            _context.SaveChanges();
            return petUpdate;
        }
    }
}
