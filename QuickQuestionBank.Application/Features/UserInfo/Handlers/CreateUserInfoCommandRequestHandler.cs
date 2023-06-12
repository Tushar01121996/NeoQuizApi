using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.UserInfo.Commands;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain.DTOs;

namespace QuickQuestionBank.Application.Features.UserInfo.Handlers
{
    public class CreateUserInfoCommandRequestHandler : IRequestHandler<CreateUserInfoCommand, Response<UserInfoDTO>>
    {
        private readonly IUserInfoRepository _repository;
        private readonly IMapper _mapper;

        public CreateUserInfoCommandRequestHandler(IUserInfoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<UserInfoDTO>> Handle(CreateUserInfoCommand request, CancellationToken cancellationToken)
        {
            QuickQuestionBank.Domain.Entities.UserInfo result = new();
            string msg = request.model.Id == null ? "User Information Created Successfully" : "User Information  Updated Successfully";
            UserInfoDTO.MapDtoToEntity(request.model, result);
            QuickQuestionBank.Domain.Entities.UserInfo response = await _repository.SaveAsync(result);
            if (response == null)
            {
                return new Response<UserInfoDTO>()
                {
                    Data = null,
                    Message = "Topics Not Found!",
                    Count = 1,
                };
            }
            request.model.Id = response.Id;
            return new Response<UserInfoDTO>()
            {
                Data = request.model,
                Message = msg,
                Count = 1,
            };
        }
    }
}
