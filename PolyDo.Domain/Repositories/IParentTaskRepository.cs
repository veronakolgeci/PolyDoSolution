using PolyDo.Domain.Entities;

namespace PolyDo.Domain.Repositories {
    public interface IParentTaskRepository {
        Task<IEnumerable<ParentTask>> GetAllTasksAsync();
        Task<ParentTask> GetTaskByIdAsync(int id);
        Task AddTaskAsync(ParentTask task);
        Task UpdateTaskAsync(ParentTask task);
        Task DeleteTaskAsync(int id);
    }
}
