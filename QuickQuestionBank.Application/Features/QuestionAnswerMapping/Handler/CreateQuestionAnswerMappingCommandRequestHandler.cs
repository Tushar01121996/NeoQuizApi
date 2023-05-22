using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.QuestionAnswerMapping.Commands;
using QuickQuestionBank.Application.Features.QuestionType.Commands;
using QuickQuestionBank.Application.Features.QuizQuestion.Commands;
using QuickQuestionBank.Application.Features.UserQuiz.Commands;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain.DTOs;
using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Application.Features.QuestionAnswerMapping.Handlers
{
    public class CreateQuestionAnswerMappingCommandRequestHandler : IRequestHandler<CreateQuestionAnswerMappingCommand, Response<QuestionAnswerMappingDTO>>
    {
        private readonly IQuestionAnswerMappingRepository _repository;
        private readonly IMapper _mapper;

        public CreateQuestionAnswerMappingCommandRequestHandler(IQuestionAnswerMappingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<QuestionAnswerMappingDTO>> Handle(CreateQuestionAnswerMappingCommand request, CancellationToken cancellationToken)
        {
            //Quiz result=  _mapper.Map<Quiz>(request.model);
            QuickQuestionBank.Domain.Entities.QuestionAnswerMapping result = new();
            string msg = request.model.Id == null ? "Question Answer Created Successfully" : "Question Answer Updated Successfully";
            QuestionAnswerMappingDTO.MapDtoToEntity(request.model,result);
            QuickQuestionBank.Domain.Entities.QuestionAnswerMapping response = await _repository.SaveAsync(result);
            if(response == null)
            {
                return new Response<QuestionAnswerMappingDTO>()
                {
                    Data = null,
                    Message = "Question Answer Not Found!",
                    Count = 1,
                };
            }
            request.model.Id = response.Id;
            return new Response<QuestionAnswerMappingDTO>()
            {
                Data = request.model,
                Message = msg,
                Count = 1,
            };
        }
    }
}
