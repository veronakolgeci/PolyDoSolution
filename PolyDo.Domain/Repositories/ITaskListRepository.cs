using PolyDo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyDo.Domain.Repositories {
    public interface ITaskListRepository {
        Task<IEnumerable<TaskList>> GetAllListsAsync();
        Task<TaskList> GetListByIdAsync(int id);
        Task AddListAsync(TaskList list);
        Task UpdateListAsync(TaskList list);
        Task DeleteListAsync(int id);
    }
}
