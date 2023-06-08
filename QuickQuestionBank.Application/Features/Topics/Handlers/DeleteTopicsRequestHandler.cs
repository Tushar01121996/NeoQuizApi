using MediatR;
using QuickQuestionBank.Application.Features.QuestionType.Queries;
using QuickQuestionBank.Application.Features.Topics.Queries;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Features.Topics.Handlers
{
    public class DeleteTopicsRequestHandler : IRequestHandler<DeleteTopicsQuery, Response<Guid?>>
    {
        private readonly ITopicsRepository _repository;

        public DeleteTopicsRequestHandler(ITopicsRepository repository)
        {
            this._repository = repository;
        }

        public async Task<Response<Guid?>> Handle(DeleteTopicsQuery request, CancellationToken cancellationToken)
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
