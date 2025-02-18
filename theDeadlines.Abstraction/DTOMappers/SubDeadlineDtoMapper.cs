using theDeadlines.Abstraction.DTOs;
using theDeadlines.Abstraction.IModels;

namespace theDeadlines.Abstraction.DTOMappers;

public static partial class SubDeadlineDtoMapper
{
    public static SubDeadlineDto MapToDto(this ISubDeadline subDeadline)
    {
        return new SubDeadlineDto
        {
            Id = subDeadline.Id,
            Description = subDeadline.Description,
            DeadlineId = subDeadline.Deadline.Id,
            DeadlineDate = subDeadline.DeadlineDate,
            Checklists = subDeadline.Checklists.Select(checklist => checklist.MapToDto()).ToList()
        };
    }
}