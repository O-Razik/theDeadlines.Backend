using theDeadlines.Abstraction.DTOMappers;
using theDeadlines.Abstraction.DTOs;
using theDeadlines.Abstraction.IModels;
using theDeadlines.DAL.Models;

namespace theDeadlines.DAL.Mappers.DtoMappers;

public static partial class DeadlineDtoMapper
{
    public static IDeadline MapToModel(this DeadlineDto deadline) => new Deadline
    {
        Id = deadline.Id,
        Name = deadline.Name,
        SubDeadlines = deadline.SubDeadlines! as ICollection<SubDeadline>
    };
}