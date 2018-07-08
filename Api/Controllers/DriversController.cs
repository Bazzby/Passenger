using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Commands;
using Infrastructure.Commands.Drivers;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class DriversController : ApiControllerBase
    {
        private readonly IDriverService _driverService;
        public DriversController(IDriverService driverService, ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _driverService = driverService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var drivers = await _driverService.BrowseAsync();
            return Json(drivers);
        }

        [HttpPost]
        public async Task<IActionResult> Put([FromBody]CreateDriver command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }
    }
}