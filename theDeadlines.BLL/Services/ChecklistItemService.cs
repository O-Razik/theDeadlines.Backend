using theDeadlines.Abstraction.IModels;
using theDeadlines.Abstraction.IRepositories;
using theDeadlines.Abstraction.IServices;
using theDeadlines.DAL.Data;

namespace theDeadlines.BLL.Services;

public class ChecklistItemService : IChecklistItemService
{
    private readonly UnitOfWork _unitOfWork;

    public ChecklistItemService(UnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<IChecklistItem> CreateChecklistItemAsync(IChecklistItem checklistItem)
    {
        return await _unitOfWork
            .ChecklistItemRepository
            .CreateChecklistItemAsync(checklistItem);
    }

    public async Task<IChecklistItem?> UpdateChecklistItemAsync(IChecklistItem checklistItem)
    {
        return await _unitOfWork
            .ChecklistItemRepository
            .UpdateChecklistItemAsync(checklistItem);
    }

    public async Task<IChecklistItem?> DeleteChecklistItemAsync(Guid id)
    {
        return await _unitOfWork
            .ChecklistItemRepository
            .DeleteChecklistItemAsync(id);
    }
}
