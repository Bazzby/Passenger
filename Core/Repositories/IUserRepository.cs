using Core.Domain;
using System;
using System.Collections.Generic;

namespace Core.Repositories
{
    public interface IUserRepository
    {
        User Get(Guid Id);
        User Get(string email);
        IEnumerable<User> GetAll();
        void Add(User user);
        void Update(User user);
        void Remove(Guid Id);
    }
}
