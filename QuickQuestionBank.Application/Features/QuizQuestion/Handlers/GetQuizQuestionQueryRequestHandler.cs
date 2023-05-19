using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.QuizQuestion.Queries;
using QuickQuestionBank.Application.Features.UserQuiz.Queries;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain.DTOs;
using QuickQuestionBank.Domain.Entities;
using System.Reflection;

namespace QuickQuestionBank.Application.Features.QuizQuestion.Handlers {
    public class GetQuizQuestionQueryRequestHandler : IRequestHandler<GetQuizQuestionQuery, Response<QuizQuestionDTO>> {
        private readonly IQuizQuestionRepository _repository;
        private readonly IMapper _mapper;

        public GetQuizQuestionQueryRequestHandler(IQuizQuestionRepository repository,IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<Response<QuizQuestionDTO>> Handle(GetQuizQuestionQuery request, CancellationToken cancellationToken) {
            //Fetch date from database
            QuickQuestionBank.Domain.Entities.QuizQuestion result = await _repository.GetByIdAsync(request.Id);

            //Map using automapper or custom mapper
            QuizQuestionDTO quizdto = new();
            QuizQuestionDTO.MapEntityToDto(result, quizdto);
            return new Response<QuizQuestionDTO>() {
                Data = quizdto,
                Message = "Quiz found successfully!",
                Count = 1,
            };
        }
    }
}
