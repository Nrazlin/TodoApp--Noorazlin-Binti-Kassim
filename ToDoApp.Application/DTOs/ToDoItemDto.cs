namespace ToDoApp.Application.DTOs;

public class ToDoItemDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}
