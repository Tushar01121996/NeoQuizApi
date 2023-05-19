using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.QuestionType.Queries;
using QuickQuestionBank.Application.Features.QuizQuestion.Queries;
using QuickQuestionBank.Application.Features.UserQuiz.Queries;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain.DTOs;
using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Application.Features.QuestionType.Handlers {

    public class GetAllQuestionTypeQueryRequestHandler : IRequestHandler<GetAllQuestionTypeQuery, Response<List<QuestionTypeDTO>>> {
        private readonly IQuestionTypeRepository _repository;
        private readonly IMapper _mapper;

        public GetAllQuestionTypeQueryRequestHandler(IQuestionTypeRepository repository, IMapper mapper)
        {
            this._repository = repository;
            _mapper = mapper;
        }

        public IMapper Mapper { get; }

        public async Task<Response<List<QuestionTypeDTO>>> Handle(GetAllQuestionTypeQuery request, CancellationToken cancellationToken) {
            //Fetch
            IReadOnlyList<QuickQuestionBank.Domain.Entities.QuestionType> result = await _repository.GetAllAsync();

            List<QuestionTypeDTO> list = new();
            //Map
            foreach (var quiz in result)
            {
                QuestionTypeDTO quizDTO = new();
                QuestionTypeDTO.MapEntityToDto(quiz, quizDTO);
                list.Add(quizDTO);
            }

            //Return
            return new Response<List<QuestionTypeDTO>> {
                Data = list,
                Message = "Question Types found!",
                Count = list.Count
            };
        }
    }
}
