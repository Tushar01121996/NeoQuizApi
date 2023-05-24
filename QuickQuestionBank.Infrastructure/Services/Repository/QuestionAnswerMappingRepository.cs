using Microsoft.EntityFrameworkCore;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain;
using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Infrastructure.Services.Repository
{

    public class QuestionAnswerMappingRepository : IQuestionAnswerMappingRepository
    {
        private readonly QuickQuestionDbContext _context;

        public QuestionAnswerMappingRepository(QuickQuestionDbContext context)
        {
            this._context = context;
        }
        public async Task<Guid> DeleteAsync(Guid id)
        {
            QuestionAnswerMapping quiz = await _context.QuestionAnswerMapping.FirstOrDefaultAsync(x => x.Id == id);
            if(quiz == null) {
                return default;
            }
            _context.QuestionAnswerMapping.Remove(quiz);
            await _context.SaveChangesAsync(); 
            return id;
        }
        public async Task<IReadOnlyList<QuestionAnswerMapping>> GetAllAsync()
        {
            return await _context.QuestionAnswerMapping.AsNoTracking().ToListAsync();
        }

        public async Task<QuestionAnswerMapping> GetByIdAsync(Guid id)
        {
            return await _context.QuestionAnswerMapping.AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }
        public async Task<QuestionAnswerMapping> SaveAsync(QuestionAnswerMapping entity)
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
        public async Task<IReadOnlyList<QuestionAnswerMapping>> GetAllByQuestionIdAsync(Guid id)
        {
            return await _context.QuestionAnswerMapping.AsNoTracking().Where(x => x.QuestionId == id).ToListAsync();
        }
    }
}
