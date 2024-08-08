namespace PolyDo.Domain.Entities {
    public class TaskList {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ParentTask> Tasks { get; set; } = new List<ParentTask>();
    }
}
