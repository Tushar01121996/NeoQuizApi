using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.QuestionType.Commands;
using QuickQuestionBank.Application.Features.Topics.Commands;
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
    public class CreateTopicsCommandRequestHandler : IRequestHandler<CreateTopicsCommand, Response<TopicsDTO>>
    {
        private readonly ITopicsRepository _repository;
        private readonly IMapper _mapper;

        public CreateTopicsCommandRequestHandler(ITopicsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<Response<TopicsDTO>> Handle(CreateTopicsCommand request, CancellationToken cancellationToken)
        {
            QuickQuestionBank.Domain.Entities.Topics result = new();
            string msg = request.model.Id == null ? "Topics Created Successfully" : "Topics  Updated Successfully";
            TopicsDTO.MapDtoToEntity(request.model, result);
            QuickQuestionBank.Domain.Entities.Topics response = await _repository.SaveAsync(result);
            if (response == null)
            {
                return new Response<TopicsDTO>()
                {
                    Data = null,
                    Message = "Topics Not Found!",
                    Count = 1,
                };
            }
            request.model.Id = response.Id;
            return new Response<TopicsDTO>()
            {
                Data = request.model,
                Message = msg,
                Count = 1,
            };
        }
    }
}
