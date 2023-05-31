using Microsoft.EntityFrameworkCore;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain;
using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Infrastructure.Services.Repository
{

    public class ShareQuizRepository : IShareQuizRepository
    {
        private readonly QuickQuestionDbContext _context;

        public ShareQuizRepository(QuickQuestionDbContext context)
        {
            this._context = context;
        }
        public async Task<IReadOnlyList<ShareQuiz>> GetAllAsync()
        {
            return await _context.ShareQuizes.AsNoTracking().ToListAsync();
        }
        public async Task<ShareQuiz> SaveAsync(ShareQuiz entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
