using Infrastructure.Commands;
using Infrastructure.Commands.Drivers;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Handlers.Drivers
{
    public class CreateDriverHandler : ICommandHandler<CreateDriver>
    {
        private readonly IDriverService _driverService;
        public CreateDriverHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async Task HandleAsync(CreateDriver command)
        {
            await _driverService.CreateAsync(command.UserId);
            var vehicle = command.Vehicle;
            await _driverService.SetVehicleAsync(command.UserId, vehicle.Brand, vehicle.Name, vehicle.Seats);
        }
    }
}
