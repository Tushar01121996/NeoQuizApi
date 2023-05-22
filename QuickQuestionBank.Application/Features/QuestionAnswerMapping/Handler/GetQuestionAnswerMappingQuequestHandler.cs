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
using System.Reflection;

namespace QuickQuestionBank.Application.Features.QuestionAnswerMapping.Handlers {
    public class GetQuestionAnswerMappingQuequestHandler : IRequestHandler<GetQuestionAnswerMappingQuery, Response<QuestionAnswerMappingDTO>> {
        private readonly IQuestionAnswerMappingRepository _repository;
        private readonly IMapper _mapper;

        public GetQuestionAnswerMappingQuequestHandler(IQuestionAnswerMappingRepository repository,IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<Response<QuestionAnswerMappingDTO>> Handle(GetQuestionAnswerMappingQuery request, CancellationToken cancellationToken) {
            //Fetch date from database
            QuickQuestionBank.Domain.Entities.QuestionAnswerMapping result = await _repository.GetByIdAsync(request.Id);

            //Map using automapper or custom mapper
            QuestionAnswerMappingDTO quizdto = new();
            QuestionAnswerMappingDTO.MapEntityToDto(result, quizdto);
            return new Response<QuestionAnswerMappingDTO>() {
                Data = quizdto,
                Message = "Quiz found successfully!",
                Count = 1,
            };
        }
    }
}
