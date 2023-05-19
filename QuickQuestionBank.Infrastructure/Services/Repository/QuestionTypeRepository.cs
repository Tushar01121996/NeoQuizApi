using Microsoft.EntityFrameworkCore;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain;
using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Infrastructure.Services.Repository
{

    public class QuestionTypeRepository : IQuestionTypeRepository
    {
        private readonly QuickQuestionDbContext _context;

        public QuestionTypeRepository(QuickQuestionDbContext context)
        {
            this._context = context;
        }
        public async Task<Guid> DeleteAsync(Guid id)
        {
            QuestionType quiz = await _context.QuestionTypes.FirstOrDefaultAsync(x => x.Id == id);
            if(quiz == null) {
                return default;
            }
            _context.QuestionTypes.Remove(quiz);
            await _context.SaveChangesAsync(); 
            return id;
        }
        public async Task<IReadOnlyList<QuestionType>> GetAllAsync()
        {
            return await _context.QuestionTypes.AsNoTracking().ToListAsync();
        }

        public async Task<QuestionType> GetByIdAsync(Guid id)
        {
            return await _context.QuestionTypes.AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }
        public async Task<QuestionType> SaveAsync(QuestionType entity)
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
