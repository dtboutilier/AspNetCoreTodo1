using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreTodo.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoItemService _todoItemService;

        public TodoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }
        // GET: /<controller>/
        public async Task<IActionResult> IndexAsync()
        {
            // Get to-do items from database
            var todoItems = await _todoItemService.GetIncompleteItemsAsync();

            // Put items into a model

            var model = new TodoViewModel()
            {
                Items = todoItems,
            };

            // Pass the view to a model and render
            return View(model);
        }
    }
}
