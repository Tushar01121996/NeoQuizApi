using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.QuizQuestion.Commands;
using QuickQuestionBank.Application.Features.UserQuiz.Commands;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain.DTOs;
using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Application.Features.QuizQuestion.Handlers
{
    public class CreateQuizQuestionCommandRequestHandler : IRequestHandler<CreateQuizQuestionCommand, Response<QuizQuestionDTO>>
    {
        private readonly IQuizQuestionRepository _repository;
        private readonly IMapper _mapper;

        public CreateQuizQuestionCommandRequestHandler(IQuizQuestionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<QuizQuestionDTO>> Handle(CreateQuizQuestionCommand request, CancellationToken cancellationToken)
        {
            //Quiz result=  _mapper.Map<Quiz>(request.model);
            QuickQuestionBank.Domain.Entities.QuizQuestion result = new();
            string msg = request.model.Id == null ? "Quiz Question Created Successfully" : "Quiz Questions Updated Successfully";
            QuizQuestionDTO.MapDtoToEntity(request.model,result);
            QuickQuestionBank.Domain.Entities.QuizQuestion response = await _repository.SaveAsync(result);
            if(response == null)
            {
                return new Response<QuizQuestionDTO>()
                {
                    Data = null,
                    Message = "Quiz Not Found!",
                    Count = 1,
                };
            }
            request.model.Id = response.Id;
            return new Response<QuizQuestionDTO>()
            {
                Data = request.model,
                Message = msg,
                Count = 1,
            };
        }
    }
}
