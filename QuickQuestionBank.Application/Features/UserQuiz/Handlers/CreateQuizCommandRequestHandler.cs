using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.UserQuiz.Commands;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain.DTOs;
using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Application.Features.UserQuiz.Handlers
{
    public class CreateQuizCommandRequestHandler : IRequestHandler<CreateQuizCommand, Response<QuizDTO>>
    {
        private readonly IQuizRepository _repository;
        private readonly IMapper _mapper;

        public CreateQuizCommandRequestHandler(IQuizRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<QuizDTO>> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            //Quiz result=  _mapper.Map<Quiz>(request.model);
            Quiz result = new();
            string msg = request.model.Id == null ? "Quiz Created Successfully" : "Quiz Updated Successfully";
            QuizDTO.MapDtoToEntity(request.model,result);
            Quiz response = await _repository.SaveAsync(result);
            if(response == null)
            {
                return new Response<QuizDTO>()
                {
                    Data = null,
                    Message = "Quiz Not Found!",
                    Count = 1,
                };
            }
            request.model.Id = response.Id;
            return new Response<QuizDTO>()
            {
                Data = request.model,
                Message = msg,
                Count = 1,
            };
        }
    }
}
