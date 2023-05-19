using Microsoft.EntityFrameworkCore;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain;
using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Infrastructure.Services.Repository
{

    public class QuizRepository : IQuizRepository
    {
        private readonly QuickQuestionDbContext _context;

        public QuizRepository(QuickQuestionDbContext context)
        {
            this._context = context;
        }
        public async Task<Guid> DeleteAsync(Guid id)
        {
            Quiz quiz = await _context.Quiz.FirstOrDefaultAsync(x => x.Id == id);
            if(quiz == null) {
                return default;
            }
            _context.Quiz.Remove(quiz);
            await _context.SaveChangesAsync(); 
            return id;
        }
        public async Task<IReadOnlyList<Quiz>> GetAllAsync()
        {
            return await _context.Quiz.AsNoTracking().ToListAsync();
        }

        public async Task<Quiz> GetByIdAsync(Guid id)
        {
            return await _context.Quiz.AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }
        public async Task<Quiz> SaveAsync(Quiz entity)
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
