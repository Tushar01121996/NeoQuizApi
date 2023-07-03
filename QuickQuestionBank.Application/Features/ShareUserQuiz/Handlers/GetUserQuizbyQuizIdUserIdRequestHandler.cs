using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.UserQuiz.Queries;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Features.UserQuiz.Handlers
{
    public class GetUserQuizbyQuizIdUserIdRequestHandler : IRequestHandler<GetUserQuizbyUserIdQuizIdQuery, Response<UserQuizDTO>>
    {
        private readonly IUserQuizRepository _repository;
        private readonly IMapper _mapper;

        public GetUserQuizbyQuizIdUserIdRequestHandler(IUserQuizRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<Response<UserQuizDTO>> Handle(GetUserQuizbyUserIdQuizIdQuery request, CancellationToken cancellationToken)
        {
            //Fetch date from database
            QuickQuestionBank.Domain.Entities.UserQuiz result = await _repository.GetbyUserIdandQuizId(request.userId, request.quizId);

            //Map using automapper or custom mapper
            UserQuizDTO topicdto = new();
            UserQuizDTO.MapEntityToDto(result, topicdto);
            return new Response<UserQuizDTO>()
            {
                Data = topicdto,
                Message = "User Quiz found successfully!",
                Count = 1,
            };
        }
    }
}
