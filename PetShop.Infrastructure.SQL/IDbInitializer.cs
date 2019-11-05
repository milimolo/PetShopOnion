using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.SQL
{
    public interface IDbInitializer
    {
        void Seed(PetAppContext pac);
    }
}
