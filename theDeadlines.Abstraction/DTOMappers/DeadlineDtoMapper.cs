using theDeadlines.Abstraction.DTOs;
using theDeadlines.Abstraction.IModels;

namespace theDeadlines.Abstraction.DTOMappers;

public static partial class DeadlineDtoMapper
{
    public static DeadlineDto MapToDto(this IDeadline deadline)
    {
        return new DeadlineDto
        {
            Id = deadline.Id,
            Name = deadline.Name,
            SubDeadlines = deadline.SubDeadlines.Select(subDeadline => subDeadline.MapToDto()).ToList()
        };
    }
}