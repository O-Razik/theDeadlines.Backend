using theDeadlines.Abstraction.IModels;
using theDeadlines.Abstraction.IServices;
using theDeadlines.DAL.Data;

namespace theDeadlines.BLL.Services;

public class ChecklistService : IChecklistService
{
    private readonly UnitOfWork _unitOfWork;
    public ChecklistService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task<IEnumerable<IChecklist>> GetChecklistsAsync()
    {
        return _unitOfWork
            .ChecklistRepository
            .GetChecklistsAsync();
    }

    public Task<IChecklist?> GetChecklistAsync(Guid id)
    {
        return _unitOfWork
            .ChecklistRepository
            .GetChecklistAsync(id);
    }

    public async Task<IChecklist> CreateChecklistAsync(IChecklist checklist)
    {
        return await _unitOfWork
            .ChecklistRepository
            .CreateChecklistAsync(checklist);
    }
    public async Task<IChecklist?> UpdateChecklistAsync(IChecklist checklist)
    {
        return await _unitOfWork
            .ChecklistRepository
            .UpdateChecklistAsync(checklist);
    }
    public async Task<IChecklist?> DeleteChecklistAsync(Guid id)
    {
        return await _unitOfWork
            .ChecklistRepository
            .DeleteChecklistAsync(id);
    }
}