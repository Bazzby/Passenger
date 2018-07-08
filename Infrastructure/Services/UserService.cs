using AutoMapper;
using Core.Domain;
using Core.Repositories;
using Infrastructure.DTO;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);

            return _mapper.Map<User, UserDTO>(user);
        }

        public async Task RegisterAsync(string email, string username, string password, string role)
        {
            var user = await _userRepository.GetAsync(email);
            if (user != null)
            {
                throw new Exception($"User with email: '{email}' already exist");
            }

            var salt = Guid.NewGuid().ToString("N");
            user = new User(email, username, password, role, salt);
            await _userRepository.AddAsync(user);
        }
    }
}
