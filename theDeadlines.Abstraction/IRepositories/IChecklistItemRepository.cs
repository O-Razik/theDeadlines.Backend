using theDeadlines.Abstraction.IModels;

namespace theDeadlines.Abstraction.IRepositories;

public interface IChecklistItemRepository
{
    Task<IChecklistItem> CreateChecklistItemAsync(IChecklistItem checklistItem);

    Task<IChecklistItem?> UpdateChecklistItemAsync(IChecklistItem checklistItem);

    Task<IChecklistItem?> DeleteChecklistItemAsync(Guid id);
}