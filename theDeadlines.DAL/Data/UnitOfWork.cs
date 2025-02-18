using theDeadlines.Abstraction.IRepositories;
using theDeadlines.DAL.Models;
using theDeadlines.DAL.Repositories;

namespace theDeadlines.DAL.Data;

public class UnitOfWork
{
    private readonly DeadlinesContext _context;

    public readonly IChecklistRepository ChecklistRepository;
    public readonly IChecklistItemRepository ChecklistItemRepository;
    public readonly IDeadlineRepository DeadlineRepository;
    public readonly ISubDeadlineRepository SubDeadlineRepository;

    public UnitOfWork(DeadlinesContext context)
    {
        _context = context;
        ChecklistRepository = new ChecklistRepository(_context);
        ChecklistItemRepository = new ChecklistItemRepository(_context);
        DeadlineRepository = new DeadlineRepository(_context);
        SubDeadlineRepository = new SubDeadlineRepository(_context);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

}