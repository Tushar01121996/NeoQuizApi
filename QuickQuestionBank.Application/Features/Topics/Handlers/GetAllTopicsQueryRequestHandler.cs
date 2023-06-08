using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.QuestionType.Queries;
using QuickQuestionBank.Application.Features.Topics.Queries;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Features.Topics.Handlers
{
    public class GetAllTopicsQueryRequestHandler : IRequestHandler<GetAllTopicsQuery, Response<List<TopicsDTO>>>
    {
        private readonly ITopicsRepository _repository;
        private readonly IMapper _mapper;

        public GetAllTopicsQueryRequestHandler(ITopicsRepository repository, IMapper mapper)
        {
            this._repository = repository;
            _mapper = mapper;
        }

        public IMapper Mapper { get; }

        public async Task<Response<List<TopicsDTO>>> Handle(GetAllTopicsQuery request, CancellationToken cancellationToken)
        {
            //Fetch
            IReadOnlyList<QuickQuestionBank.Domain.Entities.Topics> result = await _repository.GetAllAsync();

            List<TopicsDTO> list = new();
            //Map
            foreach (var quiz in result)
            {
                TopicsDTO topicDTO = new();
                TopicsDTO.MapEntityToDto(quiz, topicDTO);
                list.Add(topicDTO);
            }

            //Return
            return new Response<List<TopicsDTO>>
            {
                Data = list,
                Message = "Topics found!",
                Count = list.Count
            };
        }
    }
}
