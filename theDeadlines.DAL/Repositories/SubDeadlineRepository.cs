using Microsoft.EntityFrameworkCore;
using theDeadlines.Abstraction.IModels;
using theDeadlines.Abstraction.IRepositories;
using theDeadlines.DAL.Mappers.ModelMappers;
using theDeadlines.DAL.Models;

namespace theDeadlines.DAL.Repositories;

public class SubDeadlineRepository : ISubDeadlineRepository
{
    private readonly DeadlinesContext _context;

    public SubDeadlineRepository(DeadlinesContext context)
    {
        this._context = context;
    }

    public async Task<ISubDeadline> CreateSubDeadlineAsync(ISubDeadline subDeadline)
    {
        if (subDeadline == null) throw new ArgumentNullException(nameof(subDeadline));

        var mapToSubDeadline = subDeadline.MapToSubDeadline();

        await _context.SubDeadlines.AddAsync(mapToSubDeadline);
        await _context.SaveChangesAsync();

        return mapToSubDeadline;
    }

    public async Task<ISubDeadline?> UpdateSubDeadlineAsync(ISubDeadline subDeadline)
    {
        if (subDeadline == null) throw new ArgumentNullException(nameof(subDeadline));

        var mapToSubDeadline = subDeadline.MapToSubDeadline();

        _context.SubDeadlines.Update(mapToSubDeadline);
        await _context.SaveChangesAsync();

        return mapToSubDeadline;
    }

    public async Task<ISubDeadline?> DeleteSubDeadlineAsync(Guid id)
    {
        var subDeadline = await _context.SubDeadlines
            .Include(sd => sd.Checklists)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (subDeadline != null)
        {
            _context.SubDeadlines.Remove(subDeadline);
            await _context.SaveChangesAsync();
        }

        return subDeadline;
    }
}