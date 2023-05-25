using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Application.Interfaces.IRepository
{
    public interface IQuestionAnswerMappingRepository
    {
       // Task<Guid> DeleteAsync(Quiz entity);

        Task<Guid> DeleteAsync(Guid id);
        Task<IReadOnlyList<QuestionAnswerMapping>> GetAllAsync();
        Task<QuestionAnswerMapping> GetByIdAsync(Guid id);
        Task<QuestionAnswerMapping> SaveAsync(QuestionAnswerMapping entity);
        Task<IReadOnlyList<QuestionAnswerMapping>> GetAllByQuestionIdAsync(Guid Id);
    }
}
