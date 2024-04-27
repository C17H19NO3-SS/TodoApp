using Microsoft.AspNetCore.Mvc;
using TodoList.Models.Button;

namespace TodoList.Models.ViewComponents
{
    public class ButtonViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ButtonProps todo)
        {
            return View(todo);
        }
    }
}
