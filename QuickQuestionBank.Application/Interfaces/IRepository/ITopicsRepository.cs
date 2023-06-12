using QuickQuestionBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Interfaces.IRepository
{
    public interface ITopicsRepository
    {
        Task<Guid> DeleteAsync(Guid id);
        Task<IReadOnlyList<Topics>> GetAllAsync();
        Task<Topics> GetByIdAsync(Guid id);
        Task<Topics> SaveAsync(Topics entity);
    }
}
