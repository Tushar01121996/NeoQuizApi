using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.QuestionType.Queries;
using QuickQuestionBank.Application.Features.QuizQuestion.Queries;
using QuickQuestionBank.Application.Features.ShareQuiz.Queries;
using QuickQuestionBank.Application.Features.UserQuiz.Queries;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain.DTOs;
using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Application.Features.QuestionType.Handlers {

    public class GetAllShareQuizQueryRequestHandler : IRequestHandler<GetAllShareQuizQuery, Response<List<ShareQuizDTO>>> {
        private readonly IShareQuizRepository _repository;
        private readonly IMapper _mapper;

        public GetAllShareQuizQueryRequestHandler(IShareQuizRepository repository, IMapper mapper)
        {
            this._repository = repository;
            _mapper = mapper;
        }

        public IMapper Mapper { get; }

        public async Task<Response<List<ShareQuizDTO>>> Handle(GetAllShareQuizQuery request, CancellationToken cancellationToken) {
            //Fetch
            IReadOnlyList<QuickQuestionBank.Domain.Entities.ShareQuiz> result = await _repository.GetAllAsync();

            List<ShareQuizDTO> list = new();
            //Map
            foreach (var quiz in result)
            {
                ShareQuizDTO quizDTO = new();
                ShareQuizDTO.MapEntityToDto(quiz, quizDTO);
                list.Add(quizDTO);
            }

            //Return
            return new Response<List<ShareQuizDTO>> {
                Data = list,
                Message = "Share Quizes found!",
                Count = list.Count
            };
        }
    }
}
