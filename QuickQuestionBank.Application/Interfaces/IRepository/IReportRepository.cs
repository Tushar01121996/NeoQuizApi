using QuickQuestionBank.Domain.Entities;
using System.Data;

namespace QuickQuestionBank.Application.Interfaces.IRepository
{
    public interface IReportRepository
    {
        Task<DataTable> GetAllUserResultbyQuizIdAsync(Guid quizId);
       
    }
}
