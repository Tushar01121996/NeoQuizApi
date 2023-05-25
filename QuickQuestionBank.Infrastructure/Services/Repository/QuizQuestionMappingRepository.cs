using Microsoft.EntityFrameworkCore;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain;
using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Infrastructure.Services.Repository
{

    public class QuizQuestionMappingRepository : IQuizQuestionMappingRepository
    {
        private readonly QuickQuestionDbContext _context;

        public QuizQuestionMappingRepository(QuickQuestionDbContext context)
        {
            this._context = context;
        }
        public async Task<Guid> DeleteAsync(Guid id)
        {
            IReadOnlyList<QuizQuestionMapping> quiz = await _context.QuizQuestionMapping.Where(x => x.QuizId == id).ToListAsync();
            if(quiz == null) {
                return default;
            }
            _context.QuizQuestionMapping.RemoveRange(quiz);
            await _context.SaveChangesAsync(); 
            return id;
        }
        public async Task<QuizQuestionMapping> SaveAsync(QuizQuestionMapping entity)
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
        public async Task<IReadOnlyList<QuizQuestionMapping>> GetByQuizIdAsync(Guid id)
        {
            return await _context.QuizQuestionMapping.AsNoTracking().Where(x => x.QuizId == id).ToListAsync();
        }
    }
}
