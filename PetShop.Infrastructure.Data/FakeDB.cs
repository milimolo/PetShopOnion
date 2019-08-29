using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public static class FakeDB
    {
        public static IEnumerable<Pet> readPets;

        public static void InitData()
        {
            var pet1 = new Pet()
            {
                ID = 1,
                name = "Lady",
                type = "Islandsk Fårehund",
                color = "red",
                price = 4000
            };
            var pet2 = new Pet()
            {
                ID = 2,
                name = "John",
                type = "Golden Retriever",
                color = "Golden",
                price = 3500
            };
            
        }
    }
}
