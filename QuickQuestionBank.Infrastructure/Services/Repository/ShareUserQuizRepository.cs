using Microsoft.EntityFrameworkCore;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain;
using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Infrastructure.Services.Repository
{
    public class ShareUserQuizRepository : IShareUserQuizRepository
    {
        private readonly QuickQuestionDbContext _context;
        public ShareUserQuizRepository(QuickQuestionDbContext context)
        {
            this._context = context;
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            ShareUserQuiz result = await _context.ShareUserQuiz.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return default;
            }
            _context.ShareUserQuiz.Remove(result);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IReadOnlyList<ShareUserQuiz>> GetAllAsync()
        {
            return await _context.ShareUserQuiz.AsNoTracking().ToListAsync();           
        }

        public async Task<ShareUserQuiz> GetByIdAsync(Guid id)
        {
            return await _context.ShareUserQuiz.AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<ShareUserQuiz> SaveAsync(ShareUserQuiz entity)
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
