using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.UserQuiz.Commands;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain.DTOs;
using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Application.Features.UserQuiz.Handlers
{
    public class CreateUserQuizAttemptCommandRequestHandler : IRequestHandler<CreateUserQuizAttemptCommand, Response<UserQuizAttemptDTO>>
    {
        private readonly IUserQuizAttemptRepository _repository;
        private readonly IMapper _mapper;

        public CreateUserQuizAttemptCommandRequestHandler(IUserQuizAttemptRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<UserQuizAttemptDTO>> Handle(CreateUserQuizAttemptCommand request, CancellationToken cancellationToken)
        {
            //Quiz result=  _mapper.Map<Quiz>(request.model);
            UserQuizAttempt result = new();
            string msg = request.model.Id == null ? "User Quiz Attempt Created Successfully" : "User Quiz Attempt Updated Successfully";
            UserQuizAttemptDTO.MapDtoToEntity(request.model,result);
            UserQuizAttempt response = await _repository.SaveAsync(result);
            if(response == null)
            {
                return new Response<UserQuizAttemptDTO>()
                {
                    Data = null,
                    Message = "User Quiz Attempt Quiz Not Found!",
                    Count = 1,
                };
            }
            request.model.Id = response.Id;
            return new Response<UserQuizAttemptDTO>()
            {
                Data = request.model,
                Message = msg,
                Count = 1,
            };
        }
    }
}
