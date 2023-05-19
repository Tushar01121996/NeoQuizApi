using MediatR;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Domain.DTOs;

namespace QuickQuestionBank.Application.Features.QuestionType.Queries {
    public class GetAllQuestionTypeQuery : IRequest<Response<List<QuestionTypeDTO>>> {
    }
}
