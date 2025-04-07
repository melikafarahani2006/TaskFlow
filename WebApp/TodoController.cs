using Microsoft.AspNetCore.Mvc;
using ABCToDoList.Data;
using ABCToDoList.Models;
using Microsoft.EntityFrameworkCore;

namespace ABCToDoList.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TodoController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodos()
    {
        return await _context.TodoItems.OrderBy(t => t.Priority).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
    { 
        // Ensure category is included
        var todoItem = await _context.TodoItems.Include(t => t.Category).FirstOrDefaultAsync(t => t.Id == id);

            if (todoItem == null)
                return NotFound();

            return Ok(todoItem);    
    }

    [HttpPost]
    public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
    {
    // Ensure the category exists
    var category = await _context.TodoCategories.FindAsync(todoItem.CategoryId);
    if (category == null)
    {
        return BadRequest("Invalid category ID");
    }

    _context.TodoItems.Add(todoItem);
    await _context.SaveChangesAsync();
    return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
    }


}
