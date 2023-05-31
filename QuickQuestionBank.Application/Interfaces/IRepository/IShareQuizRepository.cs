using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Application.Interfaces.IRepository
{
    public interface IShareQuizRepository
    {
        Task<ShareQuiz> SaveAsync(ShareQuiz entity);
        Task<IReadOnlyList<ShareQuiz>> GetAllAsync();
    }
}
