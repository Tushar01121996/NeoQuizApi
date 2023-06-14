using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.UserInfo.Queries;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Features.UserInfo.Handlers
{
    public class GetUnAssignedUserInfoQueryRequestHandler : IRequestHandler<GetUnAssignedUserInfoQuery, Response<List<UserInfoDTO>>>
    {
        private readonly IUserInfoRepository _repository;
        private readonly IMapper _mapper;

        public GetUnAssignedUserInfoQueryRequestHandler(IUserInfoRepository repository, IMapper mapper)
        {
            this._repository = repository;
            _mapper = mapper;
        }

        public IMapper Mapper { get; }

        public async Task<Response<List<UserInfoDTO>>> Handle(GetUnAssignedUserInfoQuery request, CancellationToken cancellationToken)
        {
            
            List<QuickQuestionBank.Domain.Entities.UserInfo> result = await _repository.GetUnAssignedByIdAsync(request.Id,request.QuizId);
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