using theDeadlines.Abstraction.IModels;
using theDeadlines.DAL.Models;

namespace theDeadlines.DAL.Mappers.ModelMappers;

public static class SubDeadlineMapper
{
    public static SubDeadline MapToSubDeadline(this ISubDeadline subDeadline)
    {
        return new SubDeadline
        {
            Id = subDeadline.Id,
            Description = subDeadline.Description,
            DeadlineId = subDeadline.Deadline.Id,
            Deadline = subDeadline.Deadline.MapToDeadline(),
            DeadlineDate = subDeadline.DeadlineDate,
            Checklists = subDeadline.Checklists.Select(checklist => checklist.MapToChecklist()).ToList()
        };
    }
}