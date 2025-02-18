using theDeadlines.Abstraction.IModels;

namespace theDeadlines.Abstraction.IServices;

public interface IDeadlineService
{
    Task<IEnumerable<IDeadline>> GetDeadlinesAsync();

    Task<IDeadline?> GetDeadlineAsync(Guid id);

    Task<IDeadline> CreateDeadlineAsync(IDeadline deadline);

    Task<IDeadline?> UpdateDeadlineAsync(IDeadline deadline);

    Task<IDeadline?> DeleteDeadlineAsync(Guid id);
}