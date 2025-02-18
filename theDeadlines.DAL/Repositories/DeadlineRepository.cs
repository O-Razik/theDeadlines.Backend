using Microsoft.EntityFrameworkCore;
using theDeadlines.Abstraction.IModels;
using theDeadlines.Abstraction.IRepositories;
using theDeadlines.DAL.Mappers.ModelMappers;
using theDeadlines.DAL.Models;

namespace theDeadlines.DAL.Repositories
{
    public class DeadlineRepository : IDeadlineRepository
    {
        private readonly DeadlinesContext _context;

        public DeadlineRepository(DeadlinesContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<IDeadline>> GetDeadlinesAsync()
        {
            var deadlines = await _context.Deadlines
                .Include(d => d.SubDeadlines).ToListAsync();
            return deadlines;
        }

        public async Task<IDeadline?> GetDeadlineAsync(Guid id)
        {
            var deadline = await _context.Deadlines
                .Include(d => d.SubDeadlines).FirstOrDefaultAsync(x => x.Id == id);
            return deadline;
        }

        public async Task<IDeadline> CreateDeadlineAsync(IDeadline deadline)
        {
            if (deadline == null) throw new ArgumentNullException(nameof(deadline));

            var mapToDeadline = deadline.MapToDeadline();

            await _context.Deadlines.AddAsync(mapToDeadline);
            await _context.SaveChangesAsync();

            return mapToDeadline;
        }

        public async Task<IDeadline?> UpdateDeadlineAsync(IDeadline deadline)
        {
            if (deadline == null) throw new ArgumentNullException(nameof(deadline));

            var mapToDeadline = deadline.MapToDeadline();

            _context.Deadlines.Update(mapToDeadline);
            await _context.SaveChangesAsync();

            return mapToDeadline;
        }

        public async Task<IDeadline?> DeleteDeadlineAsync(Guid id)
        {
            var deadline = await _context.Deadlines.Include(d => d.SubDeadlines).FirstOrDefaultAsync(x => x.Id == id);
            if (deadline != null)
            {
                _context.Deadlines.Remove(deadline);
                await _context.SaveChangesAsync();
            }

            return deadline;
        }
    }
}