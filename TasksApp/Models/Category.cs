using System;
using System.Collections.Generic;

namespace TasksApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;  // Initialize
        public string Description { get; set; } = string.Empty;  // Initialize
        public DateTime CreatedAt { get; set; }

        // Navigation property
        public ICollection<TaskItem>? Tasks { get; set; }  // Make nullable
    }
}