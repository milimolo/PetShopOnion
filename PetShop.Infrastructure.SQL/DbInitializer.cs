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

            var owner1 = pac.owners.Add(new Owner()
            {
                firstName = "Jens",
                lastName = "Madsen"
            }).Entity;

            var owner2 = pac.owners.Add(new Owner()
            {
                firstName = "Jørgen",
                lastName = "Jespersen"
            }).Entity;

            var owner3 = pac.owners.Add(new Owner()
            {
                firstName = "Mads",
                lastName = "Mikkelsen"
            }).Entity;

            var pet1 = pac.pets.Add(new Pet()
            {
                name = "Lady",
                type = "Dog",
                birthday = new DateTime(2008, 4, 15),
                soldDate = new DateTime(2008, 8, 28),
                color = "red",
                previousOwner = new Owner { id = owner1.id },
                price = 4000
            }).Entity;

            var pet2 = pac.pets.Add(new Pet()
            {
                name = "Fiddo",
                type = "Dog",
                birthday = new DateTime(2002, 2, 21),
                soldDate = new DateTime(2004, 5, 06),
                color = "Golden",
                previousOwner = owner1,
                price = 1500
            }).Entity;

            var pet3 = pac.pets.Add(new Pet()
            {
                name = "Jesse",
                type = "Cat",
                birthday = new DateTime(2003, 11, 01),
                soldDate = new DateTime(2004, 1, 12),
                color = "Black",
                previousOwner = owner2,
                price = 2500
            }).Entity;

            var pet4 = pac.pets.Add(new Pet()
            {
                name = "Miav",
                type = "Cat",
                birthday = new DateTime(2003, 11, 01),
                soldDate = new DateTime(2004, 1, 12),
                color = "Black",
                previousOwner = owner3,
                price = 2700
            }).Entity;

            pac.SaveChanges();
        }
    }
}
