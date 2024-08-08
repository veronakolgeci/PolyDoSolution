using Microsoft.EntityFrameworkCore;
using PolyDo.Domain.Entities;
using PolyDo.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyDo.Infrastructure.Repositories {
    public class TaskListRepository : ITaskListRepository {
        private readonly AppDbContext _context;

        public TaskListRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<TaskList>> GetAllListsAsync() {
            return await _context.TaskLists.Include(l => l.Tasks).ToListAsync();
        }

        public async Task<TaskList> GetListByIdAsync(int id) {
            return await _context.TaskLists.Include(l => l.Tasks)
                                       .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task AddListAsync(TaskList list) {
            _context.TaskLists.Add(list);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateListAsync(TaskList list) {
            _context.TaskLists.Update(list);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteListAsync(int id) {
            var list = await _context.TaskLists.FindAsync(id);
            if (list != null) {
                _context.TaskLists.Remove(list);
                await _context.SaveChangesAsync();
            }
        }
    }
}
