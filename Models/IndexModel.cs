namespace TodoList.Models
{
    public class IndexModel
    {
        public List<Todo.Todo>? list { get; set; } = new List<Todo.Todo>();
        public dynamic? ok { get; set; }
    }
}
