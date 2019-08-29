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
                name = "John",
                type = "Dog",
                birthday = new DateTime(2002, 2, 21),
                soldDate = new DateTime(2004, 5, 06),
                color = "Golden",
                previousOwner = "John Madsen",
                price = 3500
            };

            petList = new List<Pet> { pet1, pet2 };
        }
    }
}
