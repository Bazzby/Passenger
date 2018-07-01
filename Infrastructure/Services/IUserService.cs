using Infrastructure.DTO;

namespace Infrastructure.Services
{
    public interface IUserService
    {
        UserDTO Get(string email);
        void Register(string email, string username, string password);
    }
}
