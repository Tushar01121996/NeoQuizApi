using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Application.Interfaces.IRepository
{
    public interface IUserQuizAttemptRepository
    {
        Task<UserQuizAttempt> SaveAsync(UserQuizAttempt entity, string totalTime);
        
    }
}
