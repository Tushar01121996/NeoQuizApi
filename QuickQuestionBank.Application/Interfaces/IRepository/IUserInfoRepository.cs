using QuickQuestionBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Interfaces.IRepository
{
    public interface IUserInfoRepository
    {
        Task<Guid> DeleteAsync(Guid id);
        Task<IReadOnlyList<UserInfo>> GetAllAsync();
        Task<UserInfo> GetByIdAsync(Guid id);
        Task<UserInfo> SaveAsync(UserInfo entity);
        Task<List<UserInfo>> GetUnAssignedByIdAsync(Guid? QuizId);
    }
}
