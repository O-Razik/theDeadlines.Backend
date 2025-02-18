using theDeadlines.Abstraction.DTOMappers;
using theDeadlines.Abstraction.DTOs;
using theDeadlines.Abstraction.IModels;
using theDeadlines.DAL.Models;

namespace theDeadlines.DAL.Mappers.DtoMappers;

public static class SubDeadlineDtoMapper
{
    public static ISubDeadline MapToModel(this SubDeadlineDto subDeadline) => new SubDeadline
    {
        Id = subDeadline.Id,
        Description = subDeadline.Description,
        DeadlineId = subDeadline.DeadlineId,
        DeadlineDate = subDeadline.DeadlineDate,
        Checklists = subDeadline.Checklists?.Select(checklist => (Checklist)checklist.MapToModel()).ToList()
    };
}