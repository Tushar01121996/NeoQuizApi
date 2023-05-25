using MediatR;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Domain.DTOs;

namespace QuickQuestionBank.Application.Features.QuestionAnswerMapping.Queries
{
    public class GetQuestionAnswerByQuestionIdQuery : IRequest<Response<List<QuestionAnswerMappingDTO>>>
    {
        public Guid Id { get; set; }
    }
}
