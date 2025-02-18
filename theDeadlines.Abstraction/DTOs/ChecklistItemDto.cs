namespace theDeadlines.Abstraction.DTOs;

public class ChecklistItemDto
{
    public Guid Id { get; set; }
    
    public string? Name { get; set; }
    
    public bool IsCompleted { get; set; }
    
    public Guid ChecklistId { get; set; }
}