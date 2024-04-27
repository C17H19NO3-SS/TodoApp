namespace TodoList.Models.Todo
{
    public class Todo
    {
        public int ID { get; private set; }
        public string? Title { get; private set; }
        public bool IsEnded { get; private set; }
        public Todo set(int id, string title, bool isEnded)
        {
            ID = id;
            Title = title;
            IsEnded = isEnded;
            return this;
        }
    }
}
