using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Application.Interfaces.IRepository
{
    public interface IQuestionTypeRepository
    {
       // Task<Guid> DeleteAsync(Quiz entity);

        Task<Guid> DeleteAsync(Guid id);
        Task<IReadOnlyList<QuestionType>> GetAllAsync();
        Task<QuestionType> GetByIdAsync(Guid id);
        Task<QuestionType> SaveAsync(QuestionType entity);
    }
}
