using Microsoft.EntityFrameworkCore;
using PolyDo.Domain.Entities;
using PolyDo.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyDo.Infrastructure.Repositories {
    public class SubTaskRepository : ISubTaskRepository {
        private readonly AppDbContext _context;

        public SubTaskRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<SubTask>> GetAllSubTasksAsync() {
            return await _context.SubTasks.ToListAsync();
        }

        public async Task<SubTask> GetSubTaskByIdAsync(int id) {
            return await _context.SubTasks.FindAsync(id);
        }

        public async Task AddSubTaskAsync(SubTask subTask) {
            _context.SubTasks.Add(subTask);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSubTaskAsync(SubTask subTask) {
            _context.SubTasks.Update(subTask);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSubTaskAsync(int id) {
            var subTask = await _context.SubTasks.FindAsync(id);
            if (subTask != null) {
                _context.SubTasks.Remove(subTask);
                await _context.SaveChangesAsync();
            }
        }
    }
}
