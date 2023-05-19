using MediatR;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Domain.DTOs;

namespace QuickQuestionBank.Application.Features.UserQuiz.Queries {
    public class GetAllQuizQuery : IRequest<Response<List<QuizDTO>>> {
    }
}
