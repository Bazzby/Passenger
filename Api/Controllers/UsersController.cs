﻿using Infrastructure.Commands;
using Infrastructure.Commands.Users;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.GetAsync(email);
            if (user == null)
            {
                return NotFound();
            }

            return Json(user);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.BrowseAsync();
            return Json(users);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Created($"users/{command.Email}", new object());
        }
    }
}