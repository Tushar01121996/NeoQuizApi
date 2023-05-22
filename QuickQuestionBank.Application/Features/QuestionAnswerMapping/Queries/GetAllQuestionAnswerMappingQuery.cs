using MediatR;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Domain.DTOs;

namespace QuickQuestionBank.Application.Features.QuestionAnswerMapping.Queries {
    public class GetAllQuestionAnswerMappingQuery : IRequest<Response<List<QuestionAnswerMappingDTO>>> {
    }
}
