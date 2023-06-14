using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.QuestionType.Commands;
using QuickQuestionBank.Application.Features.UserQuiz.Commands;
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
    public class CreateUserQuizCommandRequestHandler : IRequestHandler<CreateUserQuizCommand, Response<UserQuizDTO>>
    {
        private readonly IUserQuizRepository _repository;
        private readonly IMapper _mapper;

        public CreateUserQuizCommandRequestHandler(IUserQuizRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<UserQuizDTO>> Handle(CreateUserQuizCommand request, CancellationToken cancellationToken)
        {
            QuickQuestionBank.Domain.Entities.UserQuiz result = new();
            string msg = request.model.Id == null ? "Quiz Shared Created Successfully" : "Quiz Shared Updated Successfully";
            UserQuizDTO.MapDtoToEntity(request.model, result);
            QuickQuestionBank.Domain.Entities.UserQuiz response = await _repository.SaveAsync(result);
            if (response == null)
            {
                return new Response<UserQuizDTO>()
                {
                    Data = null,
                    Message = "Topics Not Found!",
                    Count = 1,
                };
            }
            request.model.Id = response.Id;
            return new Response<UserQuizDTO>()
            {
                Data = request.model,
                Message = msg,
                Count = 1,
            };
        }
    }
}
