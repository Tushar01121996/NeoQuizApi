using Microsoft.EntityFrameworkCore;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain;
using QuickQuestionBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Infrastructure.Services.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly QuickQuestionDbContext _context;

        public AuthRepository(QuickQuestionDbContext context)
        {
            this._context = context;
        }
        public bool LoginAsync(LoginUser login)
        {
            login = _context.Login.AsNoTracking().FirstOrDefault(q => q.Username == login.Username && q.Password == login.Password);
            return login != null ? true : false;
        }
    }
}
