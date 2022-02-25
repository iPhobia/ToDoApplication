using System.Collections.Generic;

namespace ToDoApp.Core.Entites
{
    public class TaskGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        
        public virtual ICollection<Task> Tasks { get; set; }
    }
}