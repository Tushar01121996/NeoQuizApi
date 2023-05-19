using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.UserQuiz.Queries;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain.DTOs;
using QuickQuestionBank.Domain.Entities;
using System.Reflection;

namespace QuickQuestionBank.Application.Features.UserQuiz.Handlers {
    public class GetQuizQueryRequestHandler : IRequestHandler<GetQuizQuery, Response<QuizDTO>> {
        private readonly IQuizRepository _repository;
        private readonly IMapper _mapper;

        public GetQuizQueryRequestHandler(IQuizRepository repository,IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<Response<QuizDTO>> Handle(GetQuizQuery request, CancellationToken cancellationToken) {
            //Fetch date from database
            Quiz result = await _repository.GetByIdAsync(request.Id);

            //Map using automapper or custom mapper
            QuizDTO quizdto = new();
            QuizDTO.MapEntityToDto(result, quizdto);
            return new Response<QuizDTO>() {
                Data = quizdto,
                Message = "Quiz found successfully!",
                Count = 1,
            };
        }
    }
}
