using PolyDo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyDo.Domain.Repositories {
    public interface ISubTaskRepository {
        Task<IEnumerable<SubTask>> GetAllSubTasksAsync();
        Task<SubTask> GetSubTaskByIdAsync(int id);
        Task AddSubTaskAsync(SubTask subTask);
        Task UpdateSubTaskAsync(SubTask subTask);
        Task DeleteSubTaskAsync(int id);
    }
}
