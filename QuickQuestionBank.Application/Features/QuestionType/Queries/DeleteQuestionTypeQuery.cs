using MediatR;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Features.QuestionType.Queries
{
    public class DeleteQuestionTypeQuery : IRequest<Response<Guid?>> 
    {
        public Guid Id { get; set; }
    }
}
