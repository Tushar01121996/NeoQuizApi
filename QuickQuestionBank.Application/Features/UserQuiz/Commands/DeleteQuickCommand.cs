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
    public class DeleteQuickCommand: IRequest<Response<QuizDTO>>
    {
        //public QuizDTO model { get; set; }
        public Guid Id { get; set; }
    }
}
