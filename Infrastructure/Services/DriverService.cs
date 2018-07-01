using System;
using System.Collections.Generic;
using System.Text;
using Core.Repositories;
using Infrastructure.DTO;

namespace Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }
        public DriverDTO Get(Guid userId)
        {
            var driver = _driverRepository.Get(userId);

            return new DriverDTO
            {

            };
        }
    }
}
