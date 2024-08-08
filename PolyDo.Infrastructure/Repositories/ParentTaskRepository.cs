using Microsoft.EntityFrameworkCore;
using PolyDo.Domain.Entities;
using PolyDo.Domain.Repositories;

namespace PolyDo.Infrastructure.Repositories {
    public class ParentTaskRepository : IParentTaskRepository {
        private readonly AppDbContext _context;

        public ParentTaskRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<ParentTask>> GetAllTasksAsync() {
            return await _context.ParentTasks.Include(t => t.SubTasks).ToListAsync();
        }

        public async Task<ParentTask> GetTaskByIdAsync(int id) {
            return await _context.ParentTasks.Include(t => t.SubTasks)
                                      .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddTaskAsync(ParentTask task) {
            try {
                _context.ParentTasks.Add(task);
                await _context.SaveChangesAsync();
            }
            catch (Exception) {

                throw;
            }
        }

        public async Task UpdateTaskAsync(ParentTask task) {
            try {
                _context.ParentTasks.Update(task);
                await _context.SaveChangesAsync();
            }
            catch (Exception) {

                throw;
            }
        }

        public async Task DeleteTaskAsync(int id) {
            try {
                var task = await _context.ParentTasks.FindAsync(id);
                if (task != null) {
                    _context.ParentTasks.Remove(task);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception) {

                throw;
            }
        }
    }
}
