namespace theDeadlines.Abstraction.DTOs;

public class ChecklistDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }
    
    public Guid SubDeadlineId { get; set; }

    public virtual ICollection<ChecklistItemDto>? ChecklistItems { get; set; }
}