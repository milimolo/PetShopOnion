using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.ApplicationService;
using PetShop.Core.DomainService;
using PetShop.Infrastructure.Data;
using PetShop.Infrastructure.Data.Repositories;
using PetShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2019
{
    class Program
    {
        static void Main(string[] args)
        {
            FakeDB.InitData();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var petService = serviceProvider.GetRequiredService<IPetService>();

            var serviceCollectionOwner = new ServiceCollection();
            serviceCollectionOwner.AddScoped<IOwnerRepository, OwnerRepository>();
            serviceCollectionOwner.AddScoped<IOwnerService, OwnerService>();

            var serviceProviderOwner = serviceCollectionOwner.BuildServiceProvider();
            var ownerService = serviceProviderOwner.GetRequiredService<IOwnerService>();

            new Printer(petService, ownerService);

            Console.ReadLine();
        }
    }
}
