using theDeadlines.Abstraction.IModels;

namespace theDeadlines.Abstraction.IRepositories;

public interface IChecklistRepository
{
    Task<IEnumerable<IChecklist>> GetChecklistsAsync();

    Task<IChecklist?> GetChecklistAsync(Guid id);

    Task<IChecklist> CreateChecklistAsync(IChecklist checklist);

    Task<IChecklist?> UpdateChecklistAsync(IChecklist checklist);

    Task<IChecklist?> DeleteChecklistAsync(Guid id);
}