using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.QuestionAnswerMapping.Commands;
using QuickQuestionBank.Application.Features.QuestionType.Commands;
using QuickQuestionBank.Application.Features.QuizQuestion.Commands;
using QuickQuestionBank.Application.Features.QuizQuestionMapping.Commands;
using QuickQuestionBank.Application.Features.UserQuiz.Commands;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain.DTOs;
using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Application.Features.QuizQuestionMapping.Handlers
{
    public class CreateQuizQuestionMappingCommandRequestHandler : IRequestHandler<CreateQuizQuestionMappingCommand, Response<QuizQuestionMappingDTO>>
    {
        private readonly IQuizQuestionMappingRepository _repository;
        private readonly IMapper _mapper;

        public CreateQuizQuestionMappingCommandRequestHandler(IQuizQuestionMappingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<QuizQuestionMappingDTO>> Handle(CreateQuizQuestionMappingCommand request, CancellationToken cancellationToken)
        {
            //Quiz result=  _mapper.Map<Quiz>(request.model);
            QuickQuestionBank.Domain.Entities.QuizQuestionMapping result = new();
            string msg = request.model.Id == null ? "Quiz Question Mapped Successfully" : "Quiz Question Mapped Successfully";
            QuizQuestionMappingDTO.MapDtoToEntity(request.model,result);
            QuickQuestionBank.Domain.Entities.QuizQuestionMapping response = await _repository.SaveAsync(result);
            if(response == null)
            {
                return new Response<QuizQuestionMappingDTO>()
                {
                    Data = null,
                    Message = "Quiz Question Mapping Not Found!",
                    Count = 1,
                };
            }
            request.model.Id = response.Id;
            return new Response<QuizQuestionMappingDTO>()
            {
                Data = request.model,
                Message = msg,
                Count = 1,
            };
        }
    }
}
