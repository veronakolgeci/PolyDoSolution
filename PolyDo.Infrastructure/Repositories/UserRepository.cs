using Microsoft.EntityFrameworkCore;
using PolyDo.Domain.Entities;
using PolyDo.Infrastructure;

namespace PolyDo.Domain.Repositories {
    public class UserRepository : IUserRepository {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }

        public async Task Add(User user) {
            try {
                _appDbContext.Users.Add(user);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception) {

                throw;
            }        
        }

        public async Task<User> Get(string username) {
            try {
               return await _appDbContext.Users.Where(x => x.UserName.Equals(username)).FirstOrDefaultAsync();
            }
            catch (Exception) {

                throw;
            }
        }

        public async Task Update(User user) {
            try {
                _appDbContext.Users.Update(user);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception) {

                throw;
            }
        }
    }
}
