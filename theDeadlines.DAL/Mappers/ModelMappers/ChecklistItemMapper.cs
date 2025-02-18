using theDeadlines.Abstraction.IModels;
using theDeadlines.DAL.Models;

namespace theDeadlines.DAL.Mappers.ModelMappers;

public static partial class ChecklistItemMapper
{
    public static ChecklistItem MapToChecklistItem(this IChecklistItem checklistItem)
    {
        return new ChecklistItem
        {
            Id = checklistItem.Id,
            Name = checklistItem.Name,
            IsCompleted = checklistItem.IsCompleted,
            ChecklistId = checklistItem.Checklist.Id,
            Checklist = checklistItem.Checklist.MapToChecklist()
        };
    }
}