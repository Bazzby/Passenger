﻿using Infrastructure.Commands.Users;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.GetAsync(email);
            if(user == null)
            {
                return NotFound();
            }

            return Json(user);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateUser request)
        {
            await _userService.RegisterAsync(request.Email, request.Username, request.Password);

            return Created($"users/{request.Email}", new object());
        }
    }
}