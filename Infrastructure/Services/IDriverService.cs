using Infrastructure.DTO;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IDriverService : IService
    {
        Task<DriverDTO> GetAsync(Guid userId);
    }
}
