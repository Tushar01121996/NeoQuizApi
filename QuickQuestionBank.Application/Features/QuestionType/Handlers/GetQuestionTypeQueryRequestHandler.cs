using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.QuestionType.Queries;
using QuickQuestionBank.Application.Features.QuizQuestion.Queries;
using QuickQuestionBank.Application.Features.UserQuiz.Queries;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain.DTOs;
using QuickQuestionBank.Domain.Entities;
using System.Reflection;

namespace QuickQuestionBank.Application.Features.QuestionType.Handlers {
    public class GetQuestionTypeQueryRequestHandler : IRequestHandler<GetQuestionTypeQuery, Response<QuestionTypeDTO>> {
        private readonly IQuestionTypeRepository _repository;
        private readonly IMapper _mapper;

        public GetQuestionTypeQueryRequestHandler(IQuestionTypeRepository repository,IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<Response<QuestionTypeDTO>> Handle(GetQuestionTypeQuery request, CancellationToken cancellationToken) {
            //Fetch date from database
            QuickQuestionBank.Domain.Entities.QuestionType result = await _repository.GetByIdAsync(request.Id);

            //Map using automapper or custom mapper
            QuestionTypeDTO quizdto = new();
            QuestionTypeDTO.MapEntityToDto(result, quizdto);
            return new Response<QuestionTypeDTO>() {
                Data = quizdto,
                Message = "Quiz found successfully!",
                Count = 1,
            };
        }
    }
}
