using theDeadlines.Abstraction.IModels;

namespace theDeadlines.Abstraction.IRepositories
{
    public interface IDeadlineRepository
    {
        Task<IEnumerable<IDeadline>> GetDeadlinesAsync();

        Task<IDeadline?> GetDeadlineAsync(Guid id);

        Task<IDeadline> CreateDeadlineAsync(IDeadline deadline);

        Task<IDeadline?> UpdateDeadlineAsync(IDeadline deadline);

        Task<IDeadline?> DeleteDeadlineAsync(Guid id);
    }
}