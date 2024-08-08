using PolyDo.Application.DTOs;

namespace PolyDo.Domain.Repositories {
    public interface IParentTaskService {
        Task<IEnumerable<ParentTaskDto>> GetAllTasksAsync();
        Task<ParentTaskDto> GetTaskByIdAsync(int id);
        Task AddTaskAsync(ParentTaskDto task);
        Task UpdateTaskAsync(ParentTaskDto task);
        Task DeleteTaskAsync(int id);
    }
}
