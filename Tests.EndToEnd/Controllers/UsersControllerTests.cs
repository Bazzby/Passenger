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
    public class UsersControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public UsersControllerTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task given_valid_email_user_should_exist()
        {
            var email = "user1@gmail.com";
            var user = await GetUserAsync(email);
            user.Email.Should().BeEquivalentTo(email);
        }

        [Fact]
        public async Task given_invalid_email_user_should_not_exist()
        {
            var email = "user1000@gmail.com";
            var responce = await _client.GetAsync($"users/{email}");
            responce.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task given_unique_email_user_should_be_created()
        {
            var request = new CreateUser
            {
                Email = "test@gmail.com",
                Username = "test",
                Password = "secret"
            };
            var payload = GetPayload(request);
            var responce = await _client.PostAsync("users", payload);
            responce.StatusCode.Should().BeEquivalentTo(HttpStatusCode.Created);
            responce.Headers.Location.ToString().Should().BeEquivalentTo($"users/{request.Email}");

            var user = await GetUserAsync(request.Email);
            user.Email.Should().BeEquivalentTo(request.Email);
        }

        private async Task<UserDTO> GetUserAsync(string email)
        {
            var responce = await _client.GetAsync($"users/{email}");
            var responseString = await responce.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserDTO>(responseString);
        }

        private static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
