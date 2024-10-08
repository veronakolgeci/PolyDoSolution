﻿

namespace PolyDo.Application.DTOs {
    public class ParentTaskDto {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }
        public int? ListId { get; set; }
        public List<SubTaskDto> SubTasks { get; set; }
    }
}
