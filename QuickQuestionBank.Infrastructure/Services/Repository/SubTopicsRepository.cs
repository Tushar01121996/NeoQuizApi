using Microsoft.EntityFrameworkCore;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain;
using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Infrastructure.Services.Repository
{
    public class SubTopicsRepository : ISubTopicsRepository
    {
        private readonly QuickQuestionDbContext _context;
        public SubTopicsRepository(QuickQuestionDbContext context)
        {
            this._context = context;
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            SubTopics subtopic = await _context.SubTopics.FirstOrDefaultAsync(x => x.Id == id);
            if (subtopic == null)
            {
                return default;
            }
            _context.SubTopics.Remove(subtopic);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IReadOnlyList<SubTopics>> GetAllAsync()
        {
            // return await _context.SubTopics.AsNoTracking().ToListAsync();
            var subTopics =  from s in _context.SubTopics
                  join r in _context.Topics on s.TopicId equals r.Id
            select new SubTopics
            {
                Id=s.Id,
                TopicName=r.TopicName,
                SubTopicName=s.SubTopicName,
                TopicId=s.TopicId
            };
            return await subTopics.AsNoTracking().ToListAsync();           
        }

        public async Task<SubTopics> GetByIdAsync(Guid id)
        {
            return await _context.SubTopics.AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<SubTopics> SaveAsync(SubTopics entity)
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
