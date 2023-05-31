using MediatR;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Domain.DTOs;

namespace QuickQuestionBank.Application.Features.ShareQuiz.Queries {
    public class GetAllShareQuizQuery : IRequest<Response<List<ShareQuizDTO>>> {
    }
}
