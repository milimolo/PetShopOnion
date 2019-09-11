using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.SQL.Repositories
{
    class PetRepository : IPetRepository
    {
        private PetAppContext _context;

        public PetRepository(PetAppContext context)
        {
            _context = context;
        }

        public Pet CreatePet(Pet pet)
        {
            _context.Attach(pet).State = EntityState.Added;
            _context.SaveChanges();
            return pet;

            //Begge er gode, men lars synes States er bedre.

            /*var petToCreate = _context.pets.Add(pet).Entity;
            _context.SaveChanges();
            return petToCreate;*/
        }

        public Pet DeletePet(Pet pet)
        {
            var entityRemoved = _context.Remove(new Pet { ID = pet.ID }).Entity;
            _context.SaveChanges();
            return entityRemoved;

            //Øverste sender kun 1 request til DB, mens den neden under sender 2.

            /*var removing = _context.pets.FirstOrDefault(p => p.ID == pet.ID);
            _context.Remove(removing);
            _context.SaveChanges();
            return removing;*/
        }

        public Pet ReadPet(int id)
        {
            return _context.pets.FirstOrDefault(p => p.ID == id);
        }

        public IEnumerable<Pet> ReadPets()
        {
            return _context.pets.ToList();
        }

        public Pet UpdatePet(Pet petUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
