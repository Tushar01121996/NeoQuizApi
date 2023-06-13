using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.QuestionType.Commands;
using QuickQuestionBank.Application.Features.ShareUserQuiz.Commands;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Features.ShareUserQuiz.Handlers
{
    public class CreateShareUserQuizCommandRequestHandler : IRequestHandler<CreateShareUserQuizCommand, Response<ShareUserQuizDTO>>
    {
        private readonly IShareUserQuizRepository _repository;
        private readonly IMapper _mapper;

        public CreateShareUserQuizCommandRequestHandler(IShareUserQuizRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<ShareUserQuizDTO>> Handle(CreateShareUserQuizCommand request, CancellationToken cancellationToken)
        {
            QuickQuestionBank.Domain.Entities.ShareUserQuiz result = new();
            string msg = request.model.Id == null ? "Quiz Shared Created Successfully" : "Quiz Shared Updated Successfully";
            ShareUserQuizDTO.MapDtoToEntity(request.model, result);
            QuickQuestionBank.Domain.Entities.ShareUserQuiz response = await _repository.SaveAsync(result);
            if (response == null)
            {
                return new Response<ShareUserQuizDTO>()
                {
                    Data = null,
                    Message = "Topics Not Found!",
                    Count = 1,
                };
            }
            request.model.Id = response.Id;
            return new Response<ShareUserQuizDTO>()
            {
                Data = request.model,
                Message = msg,
                Count = 1,
            };
        }
    }
}
