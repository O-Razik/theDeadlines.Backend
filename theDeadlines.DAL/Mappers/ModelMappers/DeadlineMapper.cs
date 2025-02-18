using theDeadlines.Abstraction.IModels;
using theDeadlines.DAL.Models;

namespace theDeadlines.DAL.Mappers.ModelMappers;

public static class DeadlineMapper
{
    public static Deadline MapToDeadline(this IDeadline deadline)
    {
        return new Deadline
        {
            Id = deadline.Id,
            Name = deadline.Name,
            SubDeadlines = deadline.SubDeadlines.Select(subDeadline => subDeadline.MapToSubDeadline()).ToList()
        };
    }
}