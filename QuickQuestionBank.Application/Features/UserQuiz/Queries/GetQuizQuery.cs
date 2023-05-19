using MediatR;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Domain.DTOs;

namespace QuickQuestionBank.Application.Features.UserQuiz.Queries {
    public class GetQuizQuery : IRequest<Response<QuizDTO>> {
        public Guid Id { get; set; }
    }
}
