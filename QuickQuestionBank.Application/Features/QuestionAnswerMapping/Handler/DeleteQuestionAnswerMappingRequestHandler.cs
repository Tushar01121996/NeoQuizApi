using MediatR;
using QuickQuestionBank.Application.Features.QuestionAnswerMapping.Queries;
using QuickQuestionBank.Application.Features.QuestionType.Queries;
using QuickQuestionBank.Application.Features.QuizQuestion.Queries;
using QuickQuestionBank.Application.Features.UserQuiz.Queries;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain.DTOs;
using QuickQuestionBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Features.QuestionAnswerMapping.Handlers
{
    public class DeleteQuestionAnswerMappingRequestHandler : IRequestHandler<DeleteQuestionAnswerMappingQuery, Response<Guid?>>
    {
        private readonly IQuestionAnswerMappingRepository _repository;

        public DeleteQuestionAnswerMappingRequestHandler(IQuestionAnswerMappingRepository repository)
        {
            this._repository = repository;
        }

        public async Task<Response<Guid?>> Handle(DeleteQuestionAnswerMappingQuery request, CancellationToken cancellationToken)
        {
            Guid result = await _repository.DeleteAsync(request.Id);
            string message = result != default ? "Record Deleted successfully!" : "Record Not Found!";
            return new Response<Guid?>()
            {
                Data = result != default ? result : null,
                Message = message,
                Count = 1,
            };
        }
    }
}
