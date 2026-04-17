using System;
using System.Collections.Generic;

namespace TasksApp.Models  // Changed from TaskApp to TasksApp
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ColorCode { get; set; } = "#000000";
        public DateTime CreatedAt { get; set; }

        public ICollection<TaskTag>? TaskTags { get; set; }
    }
}