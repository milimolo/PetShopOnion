using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public static class FakeDB
    {
        public static int id = 1;
        public static int ownerID = 1;
        public static List<Owner> ownerList;
        public static List<Pet> petList;

        public static void InitData()
        {
            var owner = new Owner()
            {
                id = ownerID++,
                firstName = "Jens",
                lastName = "Madsen"
            };

            var owner1 = new Owner()
            {
                id = ownerID++,
                firstName = "Big",
                lastName = "Gachiman"
            };

            var owner2 = new Owner()
            {
                id = ownerID++,
                firstName = "Jørgen",
                lastName = "Jespersen"
            };

            var owner3 = new Owner()
            {
                id = ownerID++,
                firstName = "Legolas",
                lastName = "Gimli"
            };

            var owner4 = new Owner()
            {
                id = ownerID++,
                firstName = "Mads",
                lastName = "Mikkelsen"
            };

            var owner5 = new Owner()
            {
                id = ownerID++,
                firstName = "Jon",
                lastName = "Madsen"
            };

            var pet1 = new Pet()
            {
                ID = id++,
                name = "Lady",
                type = "Dog",
                birthday = new DateTime(2008, 4, 15),
                soldDate = new DateTime(2008, 8, 28),
                color = "red",
                previousOwner = new Owner { id=owner.id},
                price = 4000
            };
            var pet2 = new Pet()
            {
                ID = id++,
                name = "Fiddo",
                type = "Dog",
                birthday = new DateTime(2002, 2, 21),
                soldDate = new DateTime(2004, 5, 06),
                color = "Golden",
                previousOwner = owner1,
                price = 1500
            };
            var pet3 = new Pet()
            {
                ID = id++,
                name = "Jesse",
                type = "Cat",
                birthday = new DateTime(2003, 11, 01),
                soldDate = new DateTime(2004, 1, 12),
                color = "Black",
                previousOwner = owner2,
                price = 2500
            };
            var pet4 = new Pet()
            {
                ID = id++,
                name = "Miav",
                type = "Cat",
                birthday = new DateTime(2003, 11, 01),
                soldDate = new DateTime(2004, 1, 12),
                color = "Black",
                previousOwner = owner3,
                price = 2700
            };
            var pet5 = new Pet()
            {
                ID = id++,
                name = "Jes",
                type = "Goat",
                birthday = new DateTime(2003, 11, 01),
                soldDate = new DateTime(2004, 1, 12),
                color = "Grey",
                previousOwner = owner4,
                price = 3200
            };
            var pet6 = new Pet()
            {
                ID = id++,
                name = "Jessada",
                type = "Goat",
                birthday = new DateTime(2003, 11, 01),
                soldDate = new DateTime(2004, 1, 12),
                color = "Grey",
                previousOwner = owner5,
                price = 5000
            };
            petList = new List<Pet> { pet1, pet2, pet3, pet4, pet5, pet6 };
            ownerList = new List<Owner> { owner, owner1, owner2, owner3, owner4, owner5 };
        }
    }
}
