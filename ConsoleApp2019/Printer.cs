using PetShop.Core.ApplicationService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;

namespace ConsoleApp2019
{
    public class Printer
    {
        private IPetService _petService;
        private IOwnerService _ownerService;
        public Printer(IPetService petService, IOwnerService ownerService)
        {
            _petService = petService;
            _ownerService = ownerService;

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
                "Sort pets by price",
                "See 5 cheapest pets",
                "List all owners",
                "Search for owner by id",
                "Exit"
            };

            var selection = ShowMenu(menuItems);
            while (selection != 8)
            {
                switch (selection)
                {
                    case 1:
                        ListPets();
                        break;
                    case 2:
                        var searchTerm = AskQuestion("\nPlease write which type of pet you want to find");
                        searchPetTypes(searchTerm);
                        break;
                    case 3:
                        var petName = AskQuestion("\nPlease write the name of the pet.");
                        var petType = AskQuestion("Please write which type of pet it is.");
                        var birthday = AskQuestionDate("Please write the date of the pets birthday.");
                        var soldDate = AskQuestionDate("Please write the date of selling.");
                        var color = AskQuestion("Please write the color of the pet.");
                        //var previousOwner = AskQuestion("Please write the id of the previous owner.");
                        var price = AskQuestionNumber("Please write the price of the pet.");
                        var pet = _petService.NewPet(petName, petType, birthday, soldDate, color, null, price);
                        _petService.Create(pet);
                        break;
                    case 4:
                        var idForUpdate = PrintFindPetById();
                        var petToUpdate = _petService.FindPetById(idForUpdate);
                        Console.WriteLine($"Updating {petToUpdate.name}");
                        var newName = AskQuestion("Please write the name of the pet.");
                        var newType = AskQuestion("Please write which type of pet it is.");
                        var newBirthday = AskQuestionDate("Please write the date of the pets birthday.");
                        var newSoldDate = AskQuestionDate("Please write the date of selling.");
                        var newColor = AskQuestion("Please write the color of the pet.");
                        var newPreviousOwner = AskQuestionNumber("Please write the id of the previous owner.");
                        var newPrice = AskQuestionNumber("Please write the price of the pet.");
                        _petService.Update(new Pet()
                        {
                            ID = idForUpdate,
                            name = newName,
                            type = newType,
                            birthday = newBirthday,
                            soldDate = newSoldDate,
                            color = newColor,
                            previousOwner = null,
                            price = newPrice
                        });
                        break;
                    case 5:
                        var idForDelete = PrintFindPetById();
                        var petToDelete = _petService.FindPetById(idForDelete);
                        _petService.Delete(petToDelete);
                        break;
                    case 6:
                        PrintSortByPrice();
                        break;
                    case 7:
                        GetFiveCheapestPets();
                        break;
                    case 8:
                        ListOwners();
                        break;
                    case 9:
                        var searchId = AskQuestionNumber("\nPlease write the id of the owner you want to find");
                        searchOwners(searchId);
                        break;
                    case 10:

                        break;
                    case 11:
                        break;
                    case 12:
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

        int AskQuestionNumber(string question)
        {
            Console.WriteLine(question);
            int answer;

            while (!int.TryParse(Console.ReadLine(), out answer))
            {
                Console.WriteLine("\nPlease write a number.");
            }
            return answer;
        }

        DateTime AskQuestionDate(string question)
        {
            Console.WriteLine(question);
            string line = Console.ReadLine();
            DateTime dt;
            while(!DateTime.TryParseExact(line, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                Console.WriteLine("Invalid date, please retry with a date looking like: dd/MM/yyyy");
                line = Console.ReadLine();
            }
            return dt;
            
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

        void ListOwners()
        {
            Console.WriteLine("\nList of owners:");
            List<Owner> owners = _ownerService.GetOwners();
            foreach (var owner in owners)
            {
                Console.WriteLine($"\nID: {owner.id} \nFirst name: {owner.firstName} \nLast name: {owner.lastName} \nOwned pet: {owner.pets}");
            }
            Console.WriteLine("\n");
        }

        void searchPetTypes(string searchTerm)
        {
            string loopBreak = null;
            List<Pet> pets = _petService.GetPets();
            foreach (var pet in pets)
            {
                if (pet.type.ToLower().Contains(searchTerm.ToLower()))
                {
                    Console.WriteLine($"\nFound pet of the type {searchTerm}.");
                    Console.WriteLine($"\nID: {pet.ID} \nName: {pet.name} \nType: {pet.type} \nBirthday: {pet.birthday} \nDate of selling: {pet.soldDate} \nColor: {pet.color} \nPrice: {pet.price}");
                    loopBreak = "";
                }
            }
            if(loopBreak == null)
            {
                Console.WriteLine($"\nSorry could not find any pets of the type {searchTerm}.");
            }
        }
        void searchOwners(int searchId)
        {
            string loopBreak = null;
            var owners = _ownerService.GetOwners();
            foreach (var owner in owners)
            {
                if (owner.id ==(searchId))
                {
                    Console.WriteLine($"\nFound owner with the id: {searchId}.");
                    Console.WriteLine($"\nID: {owner.id} \nFirst name: {owner.firstName} \nLast name: {owner.lastName} \nOwned pet: {owner.pets}");
                    loopBreak = "";
                }
            }
            if (loopBreak == null)
            {
                Console.WriteLine($"\nSorry could not find an owner with the id: {searchId}.");
            }
        }

        List<Pet> SortListByPrice()
        {
            List<Pet> pets = _petService.GetPets();
            pets = _petService.ListSortedByPrice(pets);
            return pets;
        }

        void PrintSortByPrice()
        {
            Console.WriteLine("Sorting pets by price\n");

            var pets = SortListByPrice();

            foreach (var pet in pets)
            {
                Console.WriteLine($"\nID: {pet.ID} \nName: {pet.name} \nType: {pet.type} \nBirthday: {pet.birthday} \nDate of selling: {pet.soldDate} \nColor: {pet.color} \nPrice: {pet.price}");
            }
        }

        void GetFiveCheapestPets()
        {
            Console.WriteLine("\nThe five cheapest pets available: ");
            var pets = SortListByPrice();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"\nID: {pets[i].ID} \nName: {pets[i].name} \nType: {pets[i].type} \nBirthday: {pets[i].birthday} \nDate of selling: {pets[i].soldDate} \nColor: {pets[i].color} \nPrice: {pets[i].price}");
            }
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
                || selection > 10)
            {
                Console.WriteLine("\nPlease write a number between 1-10.");
            }
            return selection;
        }
    }
}
