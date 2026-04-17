namespace TasksApp.Models
{
    public class TaskTag
    {
        public int TaskId { get; set; }
        public TaskItem? Task { get; set; }  // Make nullable

        public int TagId { get; set; }
        public Tag? Tag { get; set; }  // Make nullable
    }
}