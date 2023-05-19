using MediatR;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Domain.DTOs;

namespace QuickQuestionBank.Application.Features.QuizQuestion.Queries {
    public class GetAllQuizQuestionQuery : IRequest<Response<List<QuizQuestionDTO>>> {
    }
}
