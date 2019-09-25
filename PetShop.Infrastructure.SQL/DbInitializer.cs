using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.SQL
{
    public class DbInitializer
    {
        public static void Seed(PetAppContext pac)
        {
            pac.Database.EnsureDeleted();
            pac.Database.EnsureCreated();

            var owner1 = new Owner()
            {
                firstName = "Jens",
                lastName = "Madsen",
                Address = "Stenholdtvej 29",
                petHistory = new List<PetOwner>()
            };

            var owner2 = new Owner()
            {
                firstName = "Jørgen",
                lastName = "Jespersen",
                Address = "Løjtbækgade 14",
                petHistory = new List<PetOwner>()
            };

            var pet1 = new Pet()
            {
                name = "Lady",
                type = "Dog",
                birthday = new DateTime(2008, 4, 15),
                soldDate = new DateTime(2008, 8, 28),
                color = "red",
                price = 4000,
                ownersHistory = new List<PetOwner>()
            };

            var pet2 = new Pet()
            {
                name = "Fiddo",
                type = "Dog",
                birthday = new DateTime(2002, 2, 21),
                soldDate = new DateTime(2004, 5, 06),
                color = "Golden",
                price = 1500,
                ownersHistory = new List<PetOwner>()
            };

            owner1 = pac.owners.Add(owner1).Entity;
            owner2 = pac.owners.Add(owner2).Entity;


            PetOwner petOwner1 = new PetOwner
            {
                owner = owner1
            };

            PetOwner petOwner2 = new PetOwner
            {
                owner = owner2
            };

            PetOwner petOwner3 = new PetOwner
            {
                owner = owner1
            };

            pet1.ownersHistory.Add(petOwner1);
            pet2.ownersHistory.Add(petOwner2);


            _ = pac.pets.Add(pet1).Entity;
            _ = pac.pets.Add(pet2).Entity;

            pac.SaveChanges();
        }
    }
}
