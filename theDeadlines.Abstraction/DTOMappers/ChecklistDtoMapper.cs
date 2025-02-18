using theDeadlines.Abstraction.DTOs;
using theDeadlines.Abstraction.IModels;

namespace theDeadlines.Abstraction.DTOMappers;

public static partial class ChecklistDtoMapper
{
    public static ChecklistDto MapToDto(this IChecklist checklist)
    {
        return new ChecklistDto
        {
            Id = checklist.Id,
            Name = checklist.Name,
            SubDeadlineId = checklist.SubDeadline.Id,
            ChecklistItems = checklist.ChecklistItems.Select(checklistItem => checklistItem.MapToDto()).ToList()
        };
    }
}