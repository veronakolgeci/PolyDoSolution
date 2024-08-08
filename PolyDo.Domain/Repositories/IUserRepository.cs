using PolyDo.Domain.Entities;

namespace PolyDo.Domain.Repositories {
    public interface IUserRepository {
        Task Add(User user);
        Task Update(User user);
        Task<User> Get(string username);
    }
}
