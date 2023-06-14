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
    public class GetByTopicIdQueryRequestHandler : IRequestHandler<GetByTopicIdQuery, Response<SubTopicsDTO>>
    {
        private readonly ISubTopicsRepository _repository;
        private readonly IMapper _mapper;

        public GetByTopicIdQueryRequestHandler(ISubTopicsRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public async Task<Response<SubTopicsDTO>> Handle(GetByTopicIdQuery request, CancellationToken cancellationToken)
        {
            //Fetch date from database
            QuickQuestionBank.Domain.Entities.SubTopics result = await _repository.GetByTopicIdAsync(request.TopicId);

            //Map using automapper or custom mapper
            SubTopicsDTO topicdto = new();
            SubTopicsDTO.MapEntityToDto(result, topicdto);
            return new Response<SubTopicsDTO>()
            {
                Data = topicdto,
                Message = "Sub Topics found successfully!",
                Count = 1,
            };
        }
    }
}
