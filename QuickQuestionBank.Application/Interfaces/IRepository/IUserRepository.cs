using QuickQuestionBank.Domain.Entities;


namespace QuickQuestionBank.Application.Interfaces.IRepository
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<User> GetAll();
        Task<User> DeleteAsync(int id);
        Task<User> SaveAsync(User entity);
    }
}
