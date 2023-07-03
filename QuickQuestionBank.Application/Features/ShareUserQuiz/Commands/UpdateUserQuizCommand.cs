using MediatR;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Domain.DTOs;
using QuickQuestionBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Features.Login.Commands
{
    public class UpdateUserQuizCommand : IRequest<string>
    {
       // public LoginUser login { get; set; }
        public Guid userId { get; set; }
        public Guid quizId { get; set; }

    }
}
