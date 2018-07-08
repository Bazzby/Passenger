using Api;
using FluentAssertions;
using Infrastructure.Commands.Users;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.EndToEnd.Controllers
{
    public class UsersControllerTests : ControllerTestsBase
    {
        [Fact]
        public async Task given_invalid_email_user_should_not_exist()
        {
            var email = "user1000@gmail.com";
            var responce = await Client.GetAsync($"users/{email}");
            responce.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task given_unique_email_user_should_be_created()
        {
            var command = new CreateUser
            {
                Email = "test@gmail.com",
                Username = "test",
                Password = "secret"
            };
            var payload = GetPayload(command);
            var responce = await Client.PostAsync("users", payload);
            responce.StatusCode.Should().BeEquivalentTo(HttpStatusCode.Created);
            responce.Headers.Location.ToString().Should().BeEquivalentTo($"users/{command.Email}");

            var user = await GetUserAsync(command.Email);
            user.Email.Should().BeEquivalentTo(command.Email);
        }

        private async Task<UserDTO> GetUserAsync(string email)
        {
            var responce = await Client.GetAsync($"users/{email}");
            var responseString = await responce.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserDTO>(responseString);
        }
    }
}
