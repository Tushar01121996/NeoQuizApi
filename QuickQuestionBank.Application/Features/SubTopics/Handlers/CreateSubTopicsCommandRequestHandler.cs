using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.QuestionType.Commands;
using QuickQuestionBank.Application.Features.SubTopics.Commands;
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
    public class CreateSubTopicsCommandRequestHandler : IRequestHandler<CreateSubTopicsCommand, Response<SubTopicsDTO>>
    {
        private readonly ISubTopicsRepository _repository;
        private readonly IMapper _mapper;

        public CreateSubTopicsCommandRequestHandler(ISubTopicsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<SubTopicsDTO>> Handle(CreateSubTopicsCommand request, CancellationToken cancellationToken)
        {
            QuickQuestionBank.Domain.Entities.SubTopics result = new();
            string msg = request.model.Id == null ? "Sub Topics Created Successfully" : "Sub Topics  Updated Successfully";
            SubTopicsDTO.MapDtoToEntity(request.model, result);
            QuickQuestionBank.Domain.Entities.SubTopics response = await _repository.SaveAsync(result);
            if (response == null)
            {
                return new Response<SubTopicsDTO>()
                {
                    Data = null,
                    Message = "Topics Not Found!",
                    Count = 1,
                };
            }
            request.model.Id = response.Id;
            return new Response<SubTopicsDTO>()
            {
                Data = request.model,
                Message = msg,
                Count = 1,
            };
        }
    }
}
