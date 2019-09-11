using Microsoft.EntityFrameworkCore;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.SQL
{
    public class PetAppContext: DbContext
    {
        public DbSet<Pet> pets { get; set; }
    }
}
