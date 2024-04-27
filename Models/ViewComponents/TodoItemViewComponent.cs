using Microsoft.AspNetCore.Mvc;

namespace TodoList.Models.ViewComponents
{
    public class TodoItemViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Todo.Todo todo)
        {
            return View(todo);
        }
    }
}
