using AutoMapper;
using PolyDo.Application.DTOs;
using PolyDo.Domain.Entities;
using PolyDo.Domain.Repositories;

namespace PolyDo.Application.Services {
    public class UserService : IUserService {
        private readonly IUserRepository userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper) {
            this.userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(UserDto user) {
            var userMapped = _mapper.Map<User>(user);
            userMapped.CreatedOn = DateTime.Now;

            await userRepository.Add(userMapped);
        }

        public async Task<UserDto> GetAsync(string username) {
            var user = await userRepository.Get(username);
            var userMapped = _mapper.Map<UserDto>(user);

            return userMapped;

        }

        public async Task UpdateAsync(UserDto user) {
            var userMapped = _mapper.Map<User>(user);
            await userRepository.Update(userMapped);
        }
    }
}
