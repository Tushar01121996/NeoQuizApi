using Microsoft.EntityFrameworkCore;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain;
using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Infrastructure.Services.Repository
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly QuickQuestionDbContext _context;
        public UserInfoRepository(QuickQuestionDbContext context)
        {
            this._context = context;
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            UserInfo result = await _context.UserInfo.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return default;
            }
            _context.UserInfo.Remove(result);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IReadOnlyList<UserInfo>> GetAllAsync()
        {
            return await _context.UserInfo.AsNoTracking().ToListAsync();      
        }

        public async Task<UserInfo> GetByIdAsync(Guid id)
        {
            return await _context.UserInfo.AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<UserInfo> SaveAsync(UserInfo entity)
        {
            if (entity.Id == default)
            {
                await _context.AddAsync(entity);
            }
            else
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
