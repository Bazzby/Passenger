using Infrastructure.DTO;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IUserService
    {
        Task<UserDTO> GetAsync(string email);
        Task RegisterAsync(string email, string username, string password);
    }
}
