using theDeadlines.Abstraction.IModels;
using theDeadlines.DAL.Models;

namespace theDeadlines.DAL.Mappers.ModelMappers;

public static class ChecklistMapper
{
    public static Checklist MapToChecklist(this IChecklist checklist)
    {
        return new Checklist
        {
            Id = checklist.Id,
            Name = checklist.Name,
            SubDeadlineId = checklist.SubDeadline.Id,
            SubDeadline = checklist.SubDeadline.MapToSubDeadline(),
            ChecklistItems = checklist.ChecklistItems.Select(checklistItem => checklistItem.MapToChecklistItem()).ToList()
        };
    }
}