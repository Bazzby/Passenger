using Core.Domain;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class InMemoryDriverRepository : IDriverRepository
    {
        public static readonly ISet<Driver> _drivers = new HashSet<Driver>();
        public void Add(Driver driver)
        {
            _drivers.Add(driver);
        }

        public Driver Get(Guid userId)
            => _drivers.SingleOrDefault(x => x.UserId == userId);

        public IEnumerable<Driver> GetAll()
            => _drivers;

        public void Update(Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}
