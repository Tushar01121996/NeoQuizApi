using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.SubTopics.Queries;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Features.SubTopics.Handlers
{
    public class GetByTopicIdQueryRequestHandler : IRequestHandler<GetByTopicIdQuery, Response<List<SubTopicsDTO>>>
    {
        private readonly ISubTopicsRepository _repository;
        private readonly IMapper _mapper;

        public GetByTopicIdQueryRequestHandler(ISubTopicsRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public async Task<Response<List<SubTopicsDTO>>> Handle(GetByTopicIdQuery request, CancellationToken cancellationToken)
        {
            //Fetch date from database
            //Fetch
            List<QuickQuestionBank.Domain.Entities.SubTopics> result = await _repository.GetByTopicIdAsync(request.TopicId);

            List<SubTopicsDTO> list = new();
            //Map
            foreach (var quiz in result)
            {
                SubTopicsDTO topicDTO = new();
                SubTopicsDTO.MapEntityToDto(quiz, topicDTO);
                list.Add(topicDTO);
            }

            //Return
            return new Response<List<SubTopicsDTO>>
            {
                Data = list,
                Message = "Topics found!",
                Count = list.Count
            };
        }
    }
}
