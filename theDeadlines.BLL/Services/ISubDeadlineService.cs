using theDeadlines.Abstraction.IModels;
using theDeadlines.Abstraction.IServices;
using theDeadlines.DAL.Data;

namespace theDeadlines.BLL.Services;

public class SubDeadlineService : ISubDeadlineService
{
    private readonly UnitOfWork _unitOfWork;

    public SubDeadlineService(UnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<ISubDeadline> CreateSubDeadlineAsync(ISubDeadline subDeadline)
    {
        return await _unitOfWork
            .SubDeadlineRepository
            .CreateSubDeadlineAsync(subDeadline);
    }

    public async Task<ISubDeadline?> UpdateSubDeadlineAsync(ISubDeadline subDeadline)
    {
        return await _unitOfWork
            .SubDeadlineRepository
            .UpdateSubDeadlineAsync(subDeadline);
    }

    public async Task<ISubDeadline?> DeleteSubDeadlineAsync(Guid id)
    {
        return await _unitOfWork
            .SubDeadlineRepository
            .DeleteSubDeadlineAsync(id);
    }
}