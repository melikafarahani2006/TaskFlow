using Microsoft.EntityFrameworkCore;
using ABCToDoList.Models;

namespace ABCToDoList.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<TodoItem> TodoItems { get; set; }
    public DbSet<TodoCategory> TodoCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoCategory>().HasData(
            new TodoCategory { Id = 1, Name = "Daily" },
            new TodoCategory { Id = 2, Name = "Weekly" },
            new TodoCategory { Id = 3, Name = "Monthly" }
        );
    }
}
