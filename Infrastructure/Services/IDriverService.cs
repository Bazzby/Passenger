using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IDriverService : IService
    {
        Task<DriverDTO> GetAsync(Guid userId);
        Task CreateAsync(Guid userId);
        Task SetVehicleAsync(Guid userId, string brand, string name, int seats);
        Task<IEnumerable<DriverDTO>> BrowseAsync();
    }
}
