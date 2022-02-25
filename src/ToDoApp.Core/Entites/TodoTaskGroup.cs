using System.Collections.Generic;

namespace ToDoApp.Core.Entites
{
    public class TodoTaskGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; }

        public virtual ICollection<TodoTask> Tasks { get; set; } = new List<TodoTask>();
    }
}