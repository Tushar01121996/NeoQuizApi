using Microsoft.EntityFrameworkCore;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain;
using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Infrastructure.Services.Repository
{
    public class TopicsRepository : ITopicsRepository
    {
        private readonly QuickQuestionDbContext _context;
        public TopicsRepository(QuickQuestionDbContext context) 
        {
            this._context = context;
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            Topics topic = await _context.Topics.FirstOrDefaultAsync(x => x.Id == id);
            if (topic == null)
            {
                return default;
            }
            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IReadOnlyList<Topics>> GetAllAsync()
        {
            return await _context.Topics.AsNoTracking().ToListAsync();
        }

        public async Task<Topics> GetByIdAsync(Guid id)
        {
            return await _context.Topics.AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<Topics> SaveAsync(Topics entity)
        {
            if (entity.Id == default)
            {
                await _context.AddAsync(entity);
            }
            else
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
