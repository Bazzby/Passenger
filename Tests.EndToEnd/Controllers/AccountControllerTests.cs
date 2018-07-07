using FluentAssertions;
using Infrastructure.Commands.Users;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Tests.EndToEnd.Controllers
{
    public class AccountControllerTests : ControllerTestsBase
    {
        [Fact]
        public async Task given_valid_current_and_new_password_it_should_be_changed()
        {
            var command = new ChangeUserPassword
            {
                CurrentPassword = "secret",
                NewPassword = "secret2"
            };
            var payload = GetPayload(command);
            var responce = await Client.PutAsync("account/password", payload);
            responce.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NoContent);
        }
    }
}
