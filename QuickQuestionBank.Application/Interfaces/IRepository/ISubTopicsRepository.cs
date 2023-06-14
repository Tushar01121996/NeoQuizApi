using QuickQuestionBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Interfaces.IRepository
{
    public interface ISubTopicsRepository
    {
        Task<Guid> DeleteAsync(Guid id);
        Task<IReadOnlyList<SubTopics>> GetAllAsync();
        Task<SubTopics> GetByIdAsync(Guid TopicId);
        Task<SubTopics> GetByTopicIdAsync(Guid Topicid);
        Task<SubTopics> SaveAsync(SubTopics entity);
    }
}
