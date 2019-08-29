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
            var pet2 = new Pet()
            {
                name = "doggy",
                type = "Dog",
                birthday = DateTime.Parse("12-12-2012"),
                soldDate = DateTime.Parse("8-2-2014"),
                color = "red",
                previousOwner = "Mi svendsen",
                price = 29000
            };

            string[] menuItems =
            {
                "List all pets",
                "Search for pet types",
                "New pet",
                "Update pet",
                "Delete pet",
                "Exit"
            };

            var selection = ShowMenu(menuItems);
            while(selection != 6)
            {
                switch (selection)
                {
                    case 1:
                        ListMovies();
                        break;
                    case 2:
                        ListMovies();
                        break;
                    case 3:
                        CreateMovie();
                        break;
                    case 4:
                        ListMovies();
                        break;
                    case 5:
                        ListMovies();
                        break;
                    case 6:
                        Console.WriteLine("Exiting.");
                        break;
                    default:
                        break;
                }
            }
        }

        void CreateMovie()
        {
            Console.WriteLine("Please write the name of the pet.");
            var petName = Console.ReadLine();
            Console.WriteLine("Please write which type of pet it is.");
            var petType= Console.ReadLine();
            Console.WriteLine("Please write the date of the pets birthday.");
            var petBirthday = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Please write the date of selling.");
            var petSoldDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Please write the color of the pet.");
            var petColor = Console.ReadLine();
            Console.WriteLine("Please write the name of the previous owner.");
            var previousOwner = Console.ReadLine();
            Console.WriteLine("Please write the price of the pet.");
            var price = Convert.ToInt32(Console.ReadLine());
            var pet = new Pet()
            {
                name = petName,
                type = petType,
                birthday = petBirthday,
                soldDate = petSoldDate,
                color = petColor,
                previousOwner = previousOwner,
                price = price
            };
        }

        void ListMovies()
        {
            List<Pet> pets = _petService.GetPets();
            foreach (var pet in pets)
            {
                Console.WriteLine($"\nID: {pet.ID} \nName: {pet.name} \nType: {pet.type} \nBirthday: {pet.birthday} \nDate of selling: {pet.soldDate} \nColor: {pet.color} \nPrice: {pet.price}");
            }
            Console.WriteLine("\n");
        }

        int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select what you want to do.");
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while(!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 6)
            {
                Console.WriteLine("Please write a number between 1-6.");
            }
            return selection;
        }
    }
}
