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

    public class GetAllQuestionAnswerbyQuestionIdQueryRequestHandler : IRequestHandler<GetQuestionAnswerByQuestionIdQuery, Response<List<QuestionAnswerMappingDTO>>> {
        private readonly IQuestionAnswerMappingRepository _repository;
        private readonly IMapper _mapper;

        public GetAllQuestionAnswerbyQuestionIdQueryRequestHandler(IQuestionAnswerMappingRepository repository, IMapper mapper)
        {
            this._repository = repository;
            _mapper = mapper;
        }

        public IMapper Mapper { get; }

        public async Task<Response<List<QuestionAnswerMappingDTO>>> Handle(GetQuestionAnswerByQuestionIdQuery request, CancellationToken cancellationToken) {
            //Fetch
            IReadOnlyList<QuickQuestionBank.Domain.Entities.QuestionAnswerMapping> result = await _repository.GetAllByQuestionIdAsync(request.Id);
            List<QuestionAnswerMappingDTO> list = new();
            //Map
            foreach (var quiz in result)
            {
                QuestionAnswerMappingDTO quizDTO = new();
                QuestionAnswerMappingDTO.MapEntityToDto(quiz, quizDTO);
                list.Add(quizDTO);
            }

            //Return
            return new Response<List<QuestionAnswerMappingDTO>> {
                Data = list,
                Message = "Question Types found!",
                Count = list.Count
            };
        }
    }
}
