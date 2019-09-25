using Microsoft.EntityFrameworkCore;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.SQL
{
    public class PetAppContext: DbContext
    {
        public PetAppContext(DbContextOptions opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>()
                .HasMany(p => p.ownersHistory)
                .WithOne(po => po.pet)
                .HasForeignKey(po => po.petId);

            modelBuilder.Entity<Owner>()
                .HasMany(o => o.petHistory)
                .WithOne(po => po.owner)
                .HasForeignKey(po => po.ownerId);
        }
        public DbSet<Pet> pets { get; set; }

        public DbSet<Owner> owners { get; set; }

        public DbSet<PetOwner> petOwners { get; set; }
    }
}
