using Microsoft.EntityFrameworkCore;
using theDeadlines.Abstraction.IModels;
using theDeadlines.Abstraction.IRepositories;
using theDeadlines.DAL.Mappers.ModelMappers;
using theDeadlines.DAL.Models;

namespace theDeadlines.DAL.Repositories;

public class ChecklistRepository : IChecklistRepository
{
    private readonly DeadlinesContext _context;
    public ChecklistRepository(DeadlinesContext context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<IChecklist>> GetChecklistsAsync()
    {
        var checklists = await _context.Checklists
            .Include(c => c.ChecklistItems).ToListAsync();
        return checklists;
    }

    public async Task<IChecklist?> GetChecklistAsync(Guid id)
    {
        var checklist = await _context.Checklists
            .Include(c => c.ChecklistItems).FirstOrDefaultAsync(x => x.Id == id);
        return checklist;
    }

    public async Task<IChecklist> CreateChecklistAsync(IChecklist checklist)
    {
        if (checklist == null) throw new ArgumentNullException(nameof(checklist));

        var mapToChecklist = checklist.MapToChecklist();

        await _context.Checklists.AddAsync(mapToChecklist);
        await _context.SaveChangesAsync();

        return mapToChecklist;
    }

    public async Task<IChecklist?> UpdateChecklistAsync(IChecklist checklist)
    {
        if (checklist == null) throw new ArgumentNullException(nameof(checklist));

        var mapToChecklist = checklist.MapToChecklist();

        _context.Checklists.Update(mapToChecklist);
        await _context.SaveChangesAsync();

        return mapToChecklist;
    }

    public async Task<IChecklist?> DeleteChecklistAsync(Guid id)
    {
        var checklist = await _context.Checklists.Include(c => c.ChecklistItems).FirstOrDefaultAsync(x => x.Id == id);
        if (checklist != null)
        {
            _context.Checklists.Remove(checklist);
            await _context.SaveChangesAsync();
        }

        return checklist;
    }
}