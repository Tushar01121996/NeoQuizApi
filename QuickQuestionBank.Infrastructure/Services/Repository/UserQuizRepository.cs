using AutoMapper.Internal.Mappers;
using Microsoft.EntityFrameworkCore;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain;
using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Infrastructure.Services.Repository
{
    public class UserQuizRepository : IUserQuizRepository
    {
        private readonly QuickQuestionDbContext _context;
        private readonly Application.Interfaces.IRepository.IMailService _mailService;
        public UserQuizRepository(QuickQuestionDbContext context, Application.Interfaces.IRepository.IMailService mailService)
        {
            this._context = context;
            this._mailService = mailService;
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            UserQuiz result = await _context.UserQuiz.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return default;
            }
            _context.UserQuiz.Remove(result);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IReadOnlyList<UserQuiz>> GetAllAsync()
        {
            return await _context.UserQuiz.AsNoTracking().ToListAsync();
        }
        
        public async Task<UserQuiz> GetbyUserIdandQuizId(Guid userId, Guid quizId)
        {
            return await _context.UserQuiz.AsNoTracking().Where(x => x.UserId == userId && x.QuizId == quizId).FirstOrDefaultAsync();
        }
        public async Task<UserQuiz> GetByIdAsync(Guid id)
        {
            return await _context.UserQuiz.AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<UserQuiz> SaveAsync(UserQuiz entity)
        {
            var data = await _context.UserQuiz.Where(x => x.UserId == entity.UserId && x.QuizId == entity.QuizId).FirstOrDefaultAsync();
            if (data != null)
            {
                data.isAttempted = true;
                _context.Entry(data).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return entity;
            }
            else
            {
                var email = await _context.UserInfo.Where(x => x.Id == entity.UserId).FirstOrDefaultAsync();
                var quizDetails = await _context.Quiz.Where(x => x.Id == entity.QuizId).FirstOrDefaultAsync();
                MailRequest mailRequest = new MailRequest();
                mailRequest.Body = entity.Link;
                mailRequest.Subject = "Neo Quiz";
                mailRequest.ToEmail = email.Email;
                await _mailService.SendEmailAsync(mailRequest, email.FirstName, email.LastName, quizDetails.QuizTitle, quizDetails.QuizExpiryDate);

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
}
