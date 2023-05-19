using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.UserQuiz.Queries;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain.DTOs;
using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Application.Features.UserQuiz.Handlers {

    public class GetAllQuizQueryRequestHandler : IRequestHandler<GetAllQuizQuery, Response<List<QuizDTO>>> {
        private readonly IQuizRepository _repository;
        private readonly IMapper _mapper;

        public GetAllQuizQueryRequestHandler(IQuizRepository repository, IMapper mapper)
        {
            this._repository = repository;
            _mapper = mapper;
        }

        public IMapper Mapper { get; }

        public async Task<Response<List<QuizDTO>>> Handle(GetAllQuizQuery request, CancellationToken cancellationToken) {
            //Fetch
            IReadOnlyList<Quiz> result = await _repository.GetAllAsync();

            List<QuizDTO> list = new();
            //Map
            foreach (var quiz in result)
            {
                QuizDTO quizDTO = new();
                QuizDTO.MapEntityToDto(quiz, quizDTO);
                list.Add(quizDTO);
            }

            //Return
            return new Response<List<QuizDTO>> {
                Data = list,
                Message = "Quiz data found!",
                Count = list.Count
            };
        }
    }
}
