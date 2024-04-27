using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using TodoList.Models;
using Dapper;
using TodoList.Models.Todo;
using TodoList.Tools;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IDbConnection connection;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            connection = new SqlConnection(configuration.GetConnectionString("default"));
            connection.Open();
        }

        public async Task<IActionResult> Index(int? ok)
        {
            return View(new IndexModel
            {
                list = (List<Todo>)await connection.QueryAsync<Todo>("SELECT ID, Title, IsEnded FROM dbo.Todos"),
                ok = ok != null ? ok : null
            });
        }

        [HttpPost]
        public dynamic RemoveTodo(int ID)
        {
            var isOK = 0;
            using (connection)
            {
                int rowsAffected = connection.Execute("DELETE FROM dbo.Todos WHERE ID = @ID", new
                {
                    ID = ID
                });
                if (rowsAffected > 0)
                    isOK = 1;
            }
            return RedirectToAction("Index", new
            {
                ok = isOK
            });
        }

        [HttpPost]
        public dynamic SetEnded(int ID, int IsEnded)
        {
            var isOK = 0;
            using (connection)
            {
                int rowsAffected = connection.Execute("UPDATE dbo.Todos SET IsEnded = @IsEnded WHERE ID = @ID", new
                {
                    ID = ID,
                    IsEnded = (dynamic?)(IsEnded == 1 ? true : IsEnded == 0 ? false : null)
                });
                if (rowsAffected > 0)
                    isOK = 1;
            }
            return RedirectToAction("Index", new
            {
                ok = isOK
            });
        }

        [HttpPost]
        public dynamic AddTodo(string Title)
        {
            var isOK = 0;
            using (connection)
            {
                int rowsAffected = connection.Execute("INSERT INTO dbo.Todos (Title) VALUES (@Title)", new
                {
                    Title
                });
                if (rowsAffected > 0)
                    isOK = 1;
            }
            return RedirectToAction("Index", new
            {
                ok = isOK
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
