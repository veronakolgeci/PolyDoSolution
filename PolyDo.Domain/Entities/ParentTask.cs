
namespace PolyDo.Domain.Entities {
    public class ParentTask {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }
        public int? ParentTaskId { get; set; } 
        public int ListId { get; set; }
        public List<SubTask> SubTasks { get; set; } = new List<SubTask>();
    }
}
