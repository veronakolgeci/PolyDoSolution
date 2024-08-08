using PolyDo.Application.DTOs;

namespace PolyDo.Application.Services {
    public interface IUserService {
        Task AddAsync(UserDto user);
        Task UpdateAsync(UserDto user);
        Task<UserDto> GetAsync(string username);
    }
}
