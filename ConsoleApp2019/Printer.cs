using PetShop.Core.ApplicationService;
using PetShop.Core.ApplicationService.Impl;
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

            StartUI();
            
        }

        public void StartUI()
        {
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
            while (selection != 6)
            {
                switch (selection)
                {
                    case 1:
                        ListPets();
                        break;
                    case 2:
                        ListPets();
                        break;
                    case 3:
                        var petName = AskQuestion("\nPlease write the name of the pet.");
                        var petType = AskQuestion("Please write which type of pet it is.");
                        var birthday = DateTime.Parse(AskQuestion("Please write the date of the pets birthday."));
                        var soldDate = DateTime.Parse(AskQuestion("Please write the date of selling."));
                        var color = AskQuestion("Please write the color of the pet.");
                        var previousOwner = AskQuestion("Please write the name of the previous owner.");
                        var price = Convert.ToInt32(AskQuestion("Please write the price of the pet."));
                        var pet = _petService.NewPet(petName, petType, birthday, soldDate, color, previousOwner, price);
                        _petService.Create(pet);
                        break;
                    case 4:
                        var idForUpdate = PrintFindPetById();
                        var petToUpdate = _petService.FindPetById(idForUpdate);
                        Console.WriteLine($"Updating {petToUpdate.name}");
                        var newName = AskQuestion("Please write the name of the pet.");
                        var newType = AskQuestion("Please write which type of pet it is.");
                        var newBirthday = DateTime.Parse(AskQuestion("Please write the date of the pets birthday."));
                        var newSoldDate = DateTime.Parse(AskQuestion("Please write the date of selling."));
                        var newColor = AskQuestion("Please write the color of the pet.");
                        var newPreviousOwner = AskQuestion("Please write the name of the previous owner.");
                        var newPrice = Convert.ToInt32(AskQuestion("Please write the price of the pet."));
                        _petService.Update(new Pet()
                        {
                            ID = idForUpdate,
                            name = newName,
                            type = newType,
                            birthday = newBirthday,
                            soldDate = newSoldDate,
                            color = newColor,
                            previousOwner = newPreviousOwner,
                            price = newPrice
                        });
                        break;
                    case 5:
                        var idForDelete = PrintFindPetById();
                        var petToDelete = _petService.FindPetById(idForDelete);
                        _petService.Delete(petToDelete);
                        break;
                    case 6:
                        Console.WriteLine("Exiting.");
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Press enter to get back to menu");
                Console.ReadLine();
                Console.Clear();
                selection = ShowMenu(menuItems);
            }
        }

        int PrintFindPetById()
        {
            Console.WriteLine("\nInsert pet Id: ");
            int id;
            while(!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }
            return id;
        }

        string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        void ListPets()
        {
            Console.WriteLine("\nList of pets:");
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
