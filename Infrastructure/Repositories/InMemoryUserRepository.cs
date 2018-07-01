using Core.Domain;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>()
        {
            new User("user1@gmail.com", "user1", "password", "salt"),
            new User("user1@gmai2.com", "user2", "password", "salt"),
            new User("user1@gmai3.com", "user3", "password", "salt"),
            new User("user1@gmai4.com", "user4", "password", "salt")
        };

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User Get(Guid id)
             => _users.SingleOrDefault(x => x.Id == id);

        public User Get(string email)
            => _users.SingleOrDefault(x => x.Email == email.ToLowerInvariant());

        public IEnumerable<User> GetAll()
            => _users;

        public void Remove(Guid id)
        {
            var user = Get(id);
            _users.Remove(user);
        }

        public void Update(User user)
        {
        }
    }
}
