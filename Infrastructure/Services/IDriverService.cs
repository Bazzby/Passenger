using Core.Domain;
using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IDriverService
    {
        Task<DriverDTO> GetAsync(Guid userId);
    }
}
