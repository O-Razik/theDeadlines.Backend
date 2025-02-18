namespace theDeadlines.Abstraction.DTOs;

public class DeadlineDto
{
    public Guid Id { get; set; }
    
    public string? Name { get; set; }
    
    public virtual ICollection<SubDeadlineDto>? SubDeadlines { get; set; }
}