using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Application.Interfaces.IRepository
{
    public interface IQuizRepository
    {
       // Task<Guid> DeleteAsync(Quiz entity);

        Task<Guid> DeleteAsync(Guid id);
        Task<IReadOnlyList<Quiz>> GetAllAsync();
        Task<Quiz> GetByIdAsync(Guid id);
        Task<Quiz> SaveAsync(Quiz entity);
    }
}
