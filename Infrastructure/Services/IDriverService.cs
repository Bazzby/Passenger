using Core.Domain;
using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services
{
    public interface IDriverService
    {
        DriverDTO Get(Guid userId);
    }
}
