using Microsoft.AspNetCore.Mvc;
using ABCToDoList.Data;
using ABCToDoList.Models;
using Microsoft.EntityFrameworkCore;

namespace ABCToDoList.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoCategoryController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TodoCategoryController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoCategory>>> GetCategories()
    {
        var categories = await _context.TodoCategories.Include(c => c.TodoItems).ToListAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TodoCategory>> GetCategory(int id)
    {
        var category = await _context.TodoCategories.FindAsync(id);
        if (category == null) return NotFound();
        return category;
    }
}
