using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.QuestionType.Commands;
using QuickQuestionBank.Application.Features.QuizQuestion.Commands;
using QuickQuestionBank.Application.Features.ShareQuiz.Commands;
using QuickQuestionBank.Application.Features.UserQuiz.Commands;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain.DTOs;
using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Application.Features.ShareQuiz.Handlers
{
    public class CreateShareQuizCommandRequestHandler : IRequestHandler<CreateShareQuizCommand, Response<ShareQuizDTO>>
    {
        private readonly IShareQuizRepository _repository;
        private readonly IMapper _mapper;

        public CreateShareQuizCommandRequestHandler(IShareQuizRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<ShareQuizDTO>> Handle(CreateShareQuizCommand request, CancellationToken cancellationToken)
        {
            //Quiz result=  _mapper.Map<Quiz>(request.model);
            QuickQuestionBank.Domain.Entities.ShareQuiz result = new();
            string msg = "Share Quiz Saved Successfully";
            ShareQuizDTO.MapDtoToEntity(request.model,result);
            QuickQuestionBank.Domain.Entities.ShareQuiz response = await _repository.SaveAsync(result);
            if(response == null)
            {
                return new Response<ShareQuizDTO>()
                {
                    Data = null,
                    Message = "Share Quiz Not Found!",
                    Count = 1,
                };
            }
            return new Response<ShareQuizDTO>()
            {
                Data = request.model,
                Message = msg,
                Count = 1,
            };
        }
    }
}
