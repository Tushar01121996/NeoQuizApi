using Microsoft.EntityFrameworkCore;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain;
using QuickQuestionBank.Domain.Entities;
using static System.Reflection.Metadata.BlobBuilder;

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
            IReadOnlyList<QuizQuestionMapping> quiz = await _context.QuizQuestionMapping.AsNoTracking().Where(x => x.QuizId == id).ToListAsync();
            if (quiz == null)
            {
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
        public async Task<IReadOnlyList<QuestionOptionViewModel>> GetByQuizIdAsync(Guid id)
        {
            //var data = await _context.QuizQuestionMapping.Where(x => x.QuizId == id).ToListAsync();
            var value = from s in _context.QuizQuestionMapping
                        join r in _context.QuizQuestions on s.QuestionId equals r.Id
                        join o in _context.QuestionAnswerMapping on r.Id equals o.QuestionId
                        where s.QuizId == id
                        select new QuizQuestionMapping
                        {
                            Id = s.Id,
                            QuizId = s.QuizId,
                            QuestionId = s.QuestionId,
                            QuestionText = r.QuestionText,
                            SortOrder = r.SortOrder,
                            QuestionTypeId = r.QuestionTypeId,
                            OptionId = o.Id,
                            OptionText = o.OptionText,
                            OptionSortOrder = o.SortOrder,
                            IsCorrectAnswer = o.IsCorrectAnswer
                        };
            var result = value.GroupBy(x => new { x.QuestionId, x.QuestionText, x.QuestionTypeId })
                .Select(b => new QuestionOptionViewModel
                {
                    Options = b.Select(x=>new QuestionAnswerMapping { OptionText = x.OptionText, Id = x.OptionId, SortOrder = x.OptionSortOrder, IsCorrectAnswer=x.IsCorrectAnswer}).OrderBy(x=>x.SortOrder).ToList(),
                    // Accessing to DateOfIssue and IssuerName from Key.
                    QuestionId = b.Key.QuestionId,
                    QuestionText = b.Key.QuestionText,
                    QuestionTypeId = b.Key.QuestionTypeId
                    
                });
            return await result.ToListAsync();
        }
    }
}
