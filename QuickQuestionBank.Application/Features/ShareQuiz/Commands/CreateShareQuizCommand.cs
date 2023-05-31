using MediatR;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Features.ShareQuiz.Commands
{
    public class CreateShareQuizCommand : IRequest<Response<ShareQuizDTO>>
    {
    public ShareQuizDTO model { get; set; }  
    //public Guid id { get; set; }  
    }
}
