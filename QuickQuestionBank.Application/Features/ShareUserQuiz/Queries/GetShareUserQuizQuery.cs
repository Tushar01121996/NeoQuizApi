using MediatR;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Features.ShareUserQuiz.Queries
{
    public class GetShareUserQuizQuery : IRequest<Response<ShareUserQuizDTO>>
    {
        public Guid Id { get; set; }
    }
}