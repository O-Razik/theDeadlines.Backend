using theDeadlines.Abstraction.IModels;

namespace theDeadlines.Abstraction.IRepositories;

public interface ISubDeadlineRepository
{
    Task<ISubDeadline> CreateSubDeadlineAsync(ISubDeadline subDeadline);

    Task<ISubDeadline?> UpdateSubDeadlineAsync(ISubDeadline subDeadline);

    Task<ISubDeadline?> DeleteSubDeadlineAsync(Guid id);
}