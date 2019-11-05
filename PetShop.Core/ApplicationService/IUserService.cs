using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService.Impl
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();

        User Get(long id);

        void Add(User entity);

        void Edit(User entity);

        void Remove(long id);
    }
}
