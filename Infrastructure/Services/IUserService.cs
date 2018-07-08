using Infrastructure.DTO;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<UserDTO> GetAsync(string email);
        Task RegisterAsync(string email, string username, string password, string role);
    }
}
