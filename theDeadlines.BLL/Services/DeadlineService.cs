using theDeadlines.Abstraction.IModels;
using theDeadlines.Abstraction.IServices;
using theDeadlines.DAL.Data;

namespace theDeadlines.BLL.Services;

public class DeadlineService : IDeadlineService
{
    private readonly UnitOfWork _unitOfWork;

    public DeadlineService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<IEnumerable<IDeadline>> GetDeadlinesAsync()
    {
        return _unitOfWork
            .DeadlineRepository
            .GetDeadlinesAsync();
    }

    public Task<IDeadline?> GetDeadlineAsync(Guid id)
    {
        return _unitOfWork
            .DeadlineRepository
            .GetDeadlineAsync(id);
    }

    public async Task<IDeadline> CreateDeadlineAsync(IDeadline deadline)
    {
        return await _unitOfWork
            .DeadlineRepository
            .CreateDeadlineAsync(deadline);
    }

    public async Task<IDeadline?> UpdateDeadlineAsync(IDeadline deadline)
    {
        return await _unitOfWork
            .DeadlineRepository
            .UpdateDeadlineAsync(deadline);
    }

    public async Task<IDeadline?> DeleteDeadlineAsync(Guid id)
    {
        return await _unitOfWork
            .DeadlineRepository
            .DeleteDeadlineAsync(id);
    }
}