namespace ABCToDoList.Models;

public class TodoCategory
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; // Daily, Weekly, Monthly

    // Navigation property (one category can have many items)
    public List<TodoItem> TodoItems { get; set; } = new();
}
