using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService.Impl
{
    public class UserService: IUserService
    {
        readonly IUserRepository _userRepo;
        public UserService(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }
        public IEnumerable<User> GetAll()
        {
            return _userRepo.GetAll();
        }

        public User Get(long id)
        {
            return _userRepo.Get(id);
        }

        public void Add(User entity)
        {
            _userRepo.Add(entity);
        }

        public void Edit(User entity)
        {
            _userRepo.Edit(entity);
        }

        public void Remove(long id)
        {
            _userRepo.Remove(id);
        }
    }
}
