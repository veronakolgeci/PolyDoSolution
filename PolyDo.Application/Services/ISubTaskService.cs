using PolyDo.Application.DTOs;
using PolyDo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyDo.Domain.Repositories {
    public interface ISubTaskService {
        Task<IEnumerable<SubTaskDto>> GetAllSubTasksAsync();
        Task<SubTaskDto> GetSubTaskByIdAsync(int id);
        Task AddSubTaskAsync(SubTaskDto subTask);
        Task UpdateSubTaskAsync(SubTaskDto subTask);
        Task DeleteSubTaskAsync(int id);
    }
}
