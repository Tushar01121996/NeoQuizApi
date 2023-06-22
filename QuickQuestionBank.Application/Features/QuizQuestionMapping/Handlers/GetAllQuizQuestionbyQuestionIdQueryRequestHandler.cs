using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.QuestionAnswerMapping.Queries;
using QuickQuestionBank.Application.Features.QuestionType.Queries;
using QuickQuestionBank.Application.Features.QuizQuestion.Queries;
using QuickQuestionBank.Application.Features.UserQuiz.Queries;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain.DTOs;
using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Application.Features.QuestionAnswerMapping.Handlers {

    public class GetAllQuizQuestionbyQuestionIdQueryRequestHandler : IRequestHandler<GetQuizQuestionByQuestionIdQuery, Response<List<QuestionOptionViewModelDTO>>> {
        private readonly IQuizQuestionMappingRepository _repository;
        private readonly IMapper _mapper;

        public GetAllQuizQuestionbyQuestionIdQueryRequestHandler(IQuizQuestionMappingRepository repository, IMapper mapper)
        {
            this._repository = repository;
            _mapper = mapper;
        }

        public IMapper Mapper { get; }

        public async Task<Response<List<QuestionOptionViewModelDTO>>> Handle(GetQuizQuestionByQuestionIdQuery request, CancellationToken cancellationToken) {
            //Fetch
            IReadOnlyList<QuickQuestionBank.Domain.Entities.QuestionOptionViewModel> result = await _repository.GetByQuizIdAsync(request.Id);
            List<QuestionOptionViewModelDTO> list = new();
            //Map
            foreach (var quiz in result)
            {
                QuestionOptionViewModelDTO quizDTO = new();
                QuestionOptionViewModelDTO.MapEntityToDto(quiz, quizDTO);
                list.Add(quizDTO);
            }

            //Return
            return new Response<List<QuestionOptionViewModelDTO>> {
                Data = list,
                Message = "Quiz Question Mapping found!",
                Count = list.Count
            };
        }
    }
}
