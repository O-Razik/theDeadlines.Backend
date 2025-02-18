using theDeadlines.Abstraction.DTOs;
using theDeadlines.Abstraction.IModels;
using theDeadlines.DAL.Models;

namespace theDeadlines.DAL.Mappers.DtoMappers;

public static class ChecklistDtoMapper
{
    public static IChecklist MapToModel(this ChecklistDto checklist)
    {
        return new Checklist
        {
            Id = checklist.Id,
            Name = checklist.Name,
            SubDeadlineId = checklist.SubDeadlineId,
            ChecklistItems = (ICollection<ChecklistItem>)checklist.ChecklistItems!
        };
    }
}