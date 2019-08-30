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
        public static List<Pet> petList;

        public static void InitData()
        {
            var pet1 = new Pet()
            {
                ID = id++,
                name = "Lady",
                type = "Dog",
                birthday = new DateTime(2008, 4, 15),
                soldDate = new DateTime(2008, 8, 28),
                color = "red",
                previousOwner = "Mikkel svendsen",
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
                previousOwner = "John Madsen",
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
                previousOwner = "Elias Gøringsen",
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
                previousOwner = "Elias Gøringsen",
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
                previousOwner = "Elias Gøringsen",
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
                previousOwner = "Elias Gøringsen",
                price = 5000
            };
            petList = new List<Pet> { pet1, pet2, pet3, pet4, pet5, pet6 };
        }
    }
}
