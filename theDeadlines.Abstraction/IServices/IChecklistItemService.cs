using theDeadlines.Abstraction.IModels;

namespace theDeadlines.Abstraction.IServices;

public interface IChecklistItemService
{
    Task<IChecklistItem> CreateChecklistItemAsync(IChecklistItem checklistItem);
    Task<IChecklistItem?> UpdateChecklistItemAsync(IChecklistItem checklistItem);
    Task<IChecklistItem?> DeleteChecklistItemAsync(Guid id);
}