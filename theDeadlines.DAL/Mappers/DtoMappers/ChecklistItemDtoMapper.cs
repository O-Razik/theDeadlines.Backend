using theDeadlines.Abstraction.DTOs;
using theDeadlines.Abstraction.IModels;
using theDeadlines.DAL.Models;

namespace theDeadlines.DAL.Mappers.DtoMappers;

public static class ChecklistItemDtoMapper
{
    public static IChecklistItem MapToModel(this ChecklistItemDto checklistItem)
    {
        return new ChecklistItem
        {
            Id = checklistItem.Id,
            Name = checklistItem.Name,
            IsCompleted = checklistItem.IsCompleted,
            ChecklistId = checklistItem.ChecklistId
        };
    }
}