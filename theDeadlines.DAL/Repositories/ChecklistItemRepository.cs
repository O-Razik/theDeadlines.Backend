using Microsoft.EntityFrameworkCore;
using theDeadlines.Abstraction.IModels;
using theDeadlines.Abstraction.IRepositories;
using theDeadlines.DAL.Mappers.ModelMappers;
using theDeadlines.DAL.Models;

namespace theDeadlines.DAL.Repositories;

public class ChecklistItemRepository : IChecklistItemRepository
{
    private readonly DeadlinesContext _context;

    public ChecklistItemRepository(DeadlinesContext context)
    {
        this._context = context;
    }

    public async Task<IChecklistItem> CreateChecklistItemAsync(IChecklistItem checklistItem)
    {
        if (checklistItem == null) {
            throw new ArgumentNullException(nameof(checklistItem));
        }

        var mapToChecklistItem = checklistItem.MapToChecklistItem();

        await _context.ChecklistItems.AddAsync(mapToChecklistItem);
        await _context.SaveChangesAsync();

        return mapToChecklistItem;
    }

    public async Task<IChecklistItem?> UpdateChecklistItemAsync(IChecklistItem checklistItem)
    {
        if (checklistItem == null)
        {
            throw new ArgumentNullException(nameof(checklistItem));
        }

        var mapToChecklistItem = checklistItem.MapToChecklistItem();

        _context.ChecklistItems.Update(mapToChecklistItem);
        await _context.SaveChangesAsync();

        return mapToChecklistItem;
    }

    public async Task<IChecklistItem?> DeleteChecklistItemAsync(Guid id)
    {
        var checklistItem = await _context.ChecklistItems.FirstOrDefaultAsync(x => x.Id == id);
        if (checklistItem != null) _context.ChecklistItems.Remove(checklistItem);
        await _context.SaveChangesAsync();

        return checklistItem;
    }
}