using QuickQuestionBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Interfaces.IRepository
{
    public interface IUserQuizRepository
    {
        Task<Guid> DeleteAsync(Guid id);
        Task<IReadOnlyList<UserQuiz>> GetAllAsync();
        Task<UserQuiz> GetByIdAsync(Guid id);
        Task<UserQuiz> SaveAsync(UserQuiz entity);
        Task<UserQuiz> GetbyUserIdandQuizId(Guid userId, Guid quizId);
    }
}
