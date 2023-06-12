using MediatR;
using QuickQuestionBank.Application.FeaturesUserInfo.Queries;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;

namespace QuickQuestionBank.Application.Features.UserInfo.Handlers
{
    public class DeleteUserInfoRequestHandler : IRequestHandler<DeleteUserInfoQuery, Response<Guid?>>
    {
        private readonly IUserInfoRepository _repository;

        public DeleteUserInfoRequestHandler(IUserInfoRepository repository)
        {
            this._repository = repository;
        }

        public async Task<Response<Guid?>> Handle(DeleteUserInfoQuery request, CancellationToken cancellationToken)
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
