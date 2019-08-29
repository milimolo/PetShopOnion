using PetShop.Core.ApplicationService;
using PetShop.Core.Entity;
using PetShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2019
{
    public class Printer
    {
        private IPetService _petService;
        public Printer(IPetService petService)
        {
            _petService = petService;
            List<Pet> pets = _petService.GetPets();
            foreach (var pet in pets)
            {
                Console.WriteLine($"\n ID: {pet.ID} \nName: {pet.name} \n Type: {pet.type} \n Birthday: {pet.birthday} \n Date of selling: {pet.soldDate} \n Color: {pet.color} \n Price: {pet.price}");
            }
        }
    }
}
