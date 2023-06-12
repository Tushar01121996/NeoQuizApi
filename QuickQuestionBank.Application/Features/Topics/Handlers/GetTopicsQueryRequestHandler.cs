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
    public class GetTopicsQueryRequestHandler : IRequestHandler<GetTopicsQuery, Response<TopicsDTO>>
    {
        private readonly ITopicsRepository _repository;
        private readonly IMapper _mapper;

        public GetTopicsQueryRequestHandler(ITopicsRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<Response<TopicsDTO>> Handle(GetTopicsQuery request, CancellationToken cancellationToken)
        {
            //Fetch date from database
            QuickQuestionBank.Domain.Entities.Topics result = await _repository.GetByIdAsync(request.Id);

            //Map using automapper or custom mapper
            TopicsDTO topicdto = new();
            TopicsDTO.MapEntityToDto(result, topicdto);
            return new Response<TopicsDTO>()
            {
                Data = topicdto,
                Message = "Topics found successfully!",
                Count = 1,
            };
        }
    }
}
