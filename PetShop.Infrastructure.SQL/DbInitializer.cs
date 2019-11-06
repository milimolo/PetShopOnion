using PetShop.Core.Entity;
using PetShop.Infrastructure.SQL.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.SQL
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IAuthenticationHelper authenticationHelper;

        public DbInitializer(IAuthenticationHelper authHelper)
        {
            authenticationHelper = authHelper;
        }

        public void Seed(PetAppContext pac)
        {
            var owner1 = new Owner()
            {
                firstName = "Jens",
                lastName = "Madsen",
                Address = "Stenholdtvej 29",
                petHistory = new List<PetOwner>()
            };

            var owner2 = new Owner()
            {
                firstName = "Jørgen",
                lastName = "Jespersen",
                Address = "Løjtbækgade 14",
                petHistory = new List<PetOwner>()
            };

            var pet1 = new Pet()
            {
                name = "Lady",
                type = "Dog",
                birthday = new DateTime(2008, 4, 15),
                soldDate = new DateTime(2008, 8, 28),
                color = "red",
                price = 4000,
                ownersHistory = new List<PetOwner>()
            };

            var pet2 = new Pet()
            {
                name = "Fiddo",
                type = "Dog",
                birthday = new DateTime(2002, 2, 21),
                soldDate = new DateTime(2004, 5, 06),
                color = "Golden",
                price = 1500,
                ownersHistory = new List<PetOwner>()
            };

            owner1 = pac.owners.Add(owner1).Entity;
            owner2 = pac.owners.Add(owner2).Entity;


            PetOwner petOwner1 = new PetOwner
            {
                owner = owner1
            };

            PetOwner petOwner2 = new PetOwner
            {
                owner = owner2
            };

            PetOwner petOwner3 = new PetOwner
            {
                owner = owner1
            };

            pet1.ownersHistory.Add(petOwner1);
            pet2.ownersHistory.Add(petOwner2);


            _ = pac.pets.Add(pet1).Entity;
            _ = pac.pets.Add(pet2).Entity;


            string password = "12345";
            byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn;
            authenticationHelper.CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            authenticationHelper.CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);

            var user1 = new User
            {
                Username = "UserJoe",
                PasswordHash = passwordHashJoe,
                PasswordSalt = passwordSaltJoe,
                IsAdmin = true
            };
            var user2 = new User {
                Username = "AdminAnn",
                PasswordHash = passwordHashAnn,
                PasswordSalt = passwordSaltAnn,
                IsAdmin = false
            };
            _ = pac.Users.Add(user1).Entity;
            _ = pac.Users.Add(user2).Entity;


            pac.SaveChanges();
        }
    }
}
