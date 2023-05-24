using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Application.Interfaces.IRepository
{
    public interface IQuizQuestionMappingRepository
    {
       // Task<Guid> DeleteAsync(Quiz entity);

        Task<Guid> DeleteAsync(Guid id);
        Task<IReadOnlyList<QuizQuestionMapping>> GetByQuizIdAsync(Guid id);
        Task<QuizQuestionMapping> SaveAsync(QuizQuestionMapping entity);
    }
}
