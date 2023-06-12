using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.UserInfo.Queries;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain.DTOs;

namespace QuickQuestionBank.Application.FeaturesUserInfo.Handlers
{
    public class GetUserInfoQueryRequestHandler : IRequestHandler<GetUserInfoQuery, Response<UserInfoDTO>>
    {
        private readonly IUserInfoRepository _repository;
        private readonly IMapper _mapper;

        public GetUserInfoQueryRequestHandler(IUserInfoRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<Response<UserInfoDTO>> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            //Fetch date from database
            QuickQuestionBank.Domain.Entities.UserInfo result = await _repository.GetByIdAsync(request.Id);

            //Map using automapper or custom mapper
            UserInfoDTO topicdto = new();
            UserInfoDTO.MapEntityToDto(result, topicdto);
            return new Response<UserInfoDTO>()
            {
                Data = topicdto,
                Message = "User Information found successfully!",
                Count = 1,
            };
        }
    }
}
