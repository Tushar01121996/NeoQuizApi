using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.UserInfo.Queries;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain.DTOs;

namespace QuickQuestionBank.Application.Features.UserInfo.Handlers
{
    public class GetAllUserInfoQueryRequestHandler : IRequestHandler<GetAllUserInfoQuery, Response<List<UserInfoDTO>>>
    {
        private readonly IUserInfoRepository _repository;
        private readonly IMapper _mapper;

        public GetAllUserInfoQueryRequestHandler(IUserInfoRepository repository, IMapper mapper)
        {
            this._repository = repository;
            _mapper = mapper;
        }

        public IMapper Mapper { get; }

        public async Task<Response<List<UserInfoDTO>>> Handle(GetAllUserInfoQuery request, CancellationToken cancellationToken)
        {
            //Fetch
            IReadOnlyList<QuickQuestionBank.Domain.Entities.UserInfo> result = await _repository.GetAllAsync();
            List<UserInfoDTO> list = new();
            //Map
            foreach (var quiz in result)
            {
                UserInfoDTO topicDTO = new();
                UserInfoDTO.MapEntityToDto(quiz, topicDTO);
                list.Add(topicDTO);
            }

            //Return
            return new Response<List<UserInfoDTO>>
            {
                Data = list,
                Message = "User Information found!",
                Count = list.Count
            };
        }
    }
}
