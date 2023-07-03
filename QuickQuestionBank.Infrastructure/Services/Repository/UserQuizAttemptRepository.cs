using Microsoft.EntityFrameworkCore;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain;
using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Infrastructure.Services.Repository
{
    public class UserQuizAttemptRepository : IUserQuizAttemptRepository
    {
        private readonly QuickQuestionDbContext _context;
        public UserQuizAttemptRepository(QuickQuestionDbContext context)
        {
            this._context = context;
        }
        public async Task<UserQuizAttempt> SaveAsync(UserQuizAttempt entity, string totalTime)
        {
            if (entity.Id == default)
            {
                //UserQuizAttempt userQuizAttempt = await _context.UserQuizAttempt.FirstOrDefaultAsync(x => x.QuizId == entity.QuizId && x.QuestionId == entity.QuestionId && x.UserId == entity.UserId);
                //if(userQuizAttempt != null)
                //{
                //    _context.UserQuizAttempt.Remove(userQuizAttempt);
                //    await _context.SaveChangesAsync();
                //}
               
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();

                var data = await _context.UserQuiz.Where(x => x.UserId == entity.UserId && x.QuizId == entity.QuizId).FirstOrDefaultAsync();
                data.TimeDuration = totalTime;
                _context.Entry(data).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
           
            return entity;
        }
    }
}
