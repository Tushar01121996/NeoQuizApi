using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.QuizQuestion.Queries;
using QuickQuestionBank.Application.Features.UserQuiz.Queries;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain.DTOs;
using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Application.Features.QuizQuestion.Handlers {

    public class GetAllQuizQuestionQueryRequestHandler : IRequestHandler<GetAllQuizQuestionQuery, Response<List<QuizQuestionDTO>>> {
        private readonly IQuizQuestionRepository _repository;
        private readonly IMapper _mapper;

        public GetAllQuizQuestionQueryRequestHandler(IQuizQuestionRepository repository, IMapper mapper)
        {
            this._repository = repository;
            _mapper = mapper;
        }

        public IMapper Mapper { get; }

        public async Task<Response<List<QuizQuestionDTO>>> Handle(GetAllQuizQuestionQuery request, CancellationToken cancellationToken) {
            //Fetch
            IReadOnlyList<QuickQuestionBank.Domain.Entities.QuizQuestion> result = await _repository.GetAllAsync();

            List<QuizQuestionDTO> list = new();
            //Map
            foreach (var quiz in result)
            {
                QuizQuestionDTO quizDTO = new();
                QuizQuestionDTO.MapEntityToDto(quiz, quizDTO);
                list.Add(quizDTO);
            }

            //Return
            return new Response<List<QuizQuestionDTO>> {
                Data = list,
                Message = "Quiz Questions data found!",
                Count = list.Count
            };
        }
    }
}
