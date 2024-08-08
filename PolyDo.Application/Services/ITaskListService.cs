using PolyDo.Application.DTOs;
using PolyDo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyDo.Domain.Repositories {
    public interface ITaskListService {
        Task<IEnumerable<TaskListDto>> GetAllListsAsync();
        Task<TaskListDto> GetListByIdAsync(int id);
        Task AddListAsync(TaskListDto list);
        Task UpdateListAsync(TaskListDto list);
        Task DeleteListAsync(int id);
    }
}
