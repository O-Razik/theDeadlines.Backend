namespace theDeadlines.Abstraction.DTOs;

public partial class SubDeadlineDto
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public Guid DeadlineId { get; set; }
    public DateTime? DeadlineDate { get; set; }
    public virtual ICollection<ChecklistDto>? Checklists { get; set; }
}