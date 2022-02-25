namespace ToDoApp.Core.Entites
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string Content { get; set; }

        
        public virtual TodoTaskGroup Group { get; set; }
    }
}