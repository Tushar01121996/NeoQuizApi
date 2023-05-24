using Microsoft.EntityFrameworkCore;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain;
using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Infrastructure.Services.Repository
{

    public class QuizQuestionRepository : IQuizQuestionRepository
    {
        private readonly QuickQuestionDbContext _context;

        public QuizQuestionRepository(QuickQuestionDbContext context)
        {
            this._context = context;
        }
        public async Task<Guid> DeleteAsync(Guid id)
        {
            QuizQuestion quiz = await _context.QuizQuestions.FirstOrDefaultAsync(x => x.Id == id);
            if(quiz == null) {
                return default;
            }
            _context.QuizQuestions.Remove(quiz);
            await _context.SaveChangesAsync(); 
            return id;
        }
        public async Task<IReadOnlyList<QuizQuestion>> GetAllAsync()
        {
            return await _context.QuizQuestions.AsNoTracking().ToListAsync();
        }
        public async Task<QuizQuestion> GetByIdAsync(Guid id)
        {
            return await _context.QuizQuestions.AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }
        public async Task<QuizQuestion> SaveAsync(QuizQuestion entity)
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
