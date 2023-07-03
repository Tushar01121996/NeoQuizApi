using MediatR;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Features.UserQuiz.Commands
{
    public class CreateUserQuizAttemptCommand : IRequest<Response<UserQuizAttemptDTO>>
    {
        public UserQuizAttemptDTO model { get; set; }
        public string totalTime { get; set; }
        //public Guid id { get; set; }  
    }
}
