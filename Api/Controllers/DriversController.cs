using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Commands;
using Infrastructure.Commands.Drivers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class DriversController : ApiControllerBase
    {
        public DriversController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Put([FromBody]CreateDriver command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }
    }
}