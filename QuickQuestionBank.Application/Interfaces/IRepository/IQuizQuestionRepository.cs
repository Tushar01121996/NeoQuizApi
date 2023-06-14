using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Application.Interfaces.IRepository
{
    public interface IQuizQuestionRepository
    {
       // Task<Guid> DeleteAsync(Quiz entity);

        Task<Guid> DeleteAsync(Guid id);
        Task<IReadOnlyList<QuizQuestion>> GetAllAsync();
        Task<QuizQuestion> GetByIdAsync(Guid id);
        Task<List<QuizQuestion>> GetByTopicIdAsync(Guid? TopicId, Guid? SubTopicId);
        Task<QuizQuestion> SaveAsync(QuizQuestion entity);
    }
}
