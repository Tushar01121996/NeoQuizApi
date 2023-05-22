using MediatR;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Domain.DTOs;

namespace QuickQuestionBank.Application.Features.QuestionAnswerMapping.Queries {
    public class GetQuestionAnswerMappingQuery : IRequest<Response<QuestionAnswerMappingDTO>> {
        public Guid Id { get; set; }
    }
}
