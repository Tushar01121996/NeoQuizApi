using MediatR;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Features.QuestionAnswerMapping.Queries
{
    public class DeleteQuestionAnswerMappingQuery : IRequest<Response<Guid?>> 
    {
        public Guid Id { get; set; }
    }
}
