using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.QuestionType.Commands;
using QuickQuestionBank.Application.Features.QuizQuestion.Commands;
using QuickQuestionBank.Application.Features.UserQuiz.Commands;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain.DTOs;
using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Application.Features.QuestionType.Handlers
{
    public class CreateQuestionTypeCommandRequestHandler : IRequestHandler<CreateQuestionTypeCommand, Response<QuestionTypeDTO>>
    {
        private readonly IQuestionTypeRepository _repository;
        private readonly IMapper _mapper;

        public CreateQuestionTypeCommandRequestHandler(IQuestionTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<QuestionTypeDTO>> Handle(CreateQuestionTypeCommand request, CancellationToken cancellationToken)
        {
            //Quiz result=  _mapper.Map<Quiz>(request.model);
            QuickQuestionBank.Domain.Entities.QuestionType result = new();
            string msg = request.model.Id == null ? "Question Type Created Successfully" : "Question Type Updated Successfully";
            QuestionTypeDTO.MapDtoToEntity(request.model,result);
            QuickQuestionBank.Domain.Entities.QuestionType response = await _repository.SaveAsync(result);
            if(response == null)
            {
                return new Response<QuestionTypeDTO>()
                {
                    Data = null,
                    Message = "Question Type Not Found!",
                    Count = 1,
                };
            }
            request.model.Id = response.Id;
            return new Response<QuestionTypeDTO>()
            {
                Data = request.model,
                Message = msg,
                Count = 1,
            };
        }
    }
}
