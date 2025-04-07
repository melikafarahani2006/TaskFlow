namespace ABCToDoList.Models;

public class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Priority { get; set; } = "C"; // A, B, or C
    public bool IsCompleted { get; set; } = false;

    public int CategoryId { get; set; }
    public TodoCategory? Category { get; set; } 
}
