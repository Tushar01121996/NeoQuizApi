using QuickQuestionBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Interfaces.IRepository
{
    public interface IShareUserQuizRepository
    {
        Task<Guid> DeleteAsync(Guid id);
        Task<IReadOnlyList<ShareUserQuiz>> GetAllAsync();
        Task<ShareUserQuiz> GetByIdAsync(Guid id);
        Task<ShareUserQuiz> SaveAsync(ShareUserQuiz entity);
    }
}
