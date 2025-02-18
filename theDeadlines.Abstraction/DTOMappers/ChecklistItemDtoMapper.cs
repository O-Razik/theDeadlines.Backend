using theDeadlines.Abstraction.DTOs;
using theDeadlines.Abstraction.IModels;

namespace theDeadlines.Abstraction.DTOMappers;

public static partial class ChecklistItemDtoMapper
{
    public static ChecklistItemDto MapToDto(this IChecklistItem checklistItem)
    {
        return new ChecklistItemDto
        {
            Id = checklistItem.Id,
            Name = checklistItem.Name,
            IsCompleted = checklistItem.IsCompleted,
            ChecklistId = checklistItem.Checklist.Id
        };
    }
}