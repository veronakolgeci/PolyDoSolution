﻿
namespace PolyDo.Domain.Entities {
    public class SubTask {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }
        public int TaskId { get; set; } 
    }
}
