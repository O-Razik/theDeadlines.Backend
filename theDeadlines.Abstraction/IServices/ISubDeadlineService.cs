using theDeadlines.Abstraction.IModels;

namespace theDeadlines.Abstraction.IServices;

public interface ISubDeadlineService
{
    Task<ISubDeadline> CreateSubDeadlineAsync(ISubDeadline subDeadline);
    Task<ISubDeadline?> UpdateSubDeadlineAsync(ISubDeadline subDeadline);
    Task<ISubDeadline?> DeleteSubDeadlineAsync(Guid id);
}