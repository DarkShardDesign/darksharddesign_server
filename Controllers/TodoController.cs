using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using darksharddesign_server.Models;

namespace darksharddesign_server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TodoController : ControllerBase
  {
    private readonly TodoContext _context;
    
    public TodoController(TodoContext context)
    {
      _context = context;

      if (_context.TodoItems.Count() == 0)
      {
        _context.TodoItems.Add(new TodoItem { Name = "Item1" });
        _context.SaveChanges();
      }
    }

    [HttpGet]
    public ActionResult<List<TodoItem>> GetAll()
    {
      return _context.TodoItems.ToList();
    }

    [HttpGet("{id}", Name = "GetTodo")]
    public ActionResult<TodoItem> GetById(long id) 
    {
      var item = _context.TodoItems.Find(id);
      if (item == null) 
      {
        return NotFound();
      }

      return item;
    }
  }
}