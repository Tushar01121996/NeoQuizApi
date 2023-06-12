using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.ShareUserQuiz.Queries;
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
    public class GetShareUserQuizQueryRequestHandler : IRequestHandler<GetShareUserQuizQuery, Response<ShareUserQuizDTO>>
    {
        private readonly IShareUserQuizRepository _repository;
        private readonly IMapper _mapper;

        public GetShareUserQuizQueryRequestHandler(IShareUserQuizRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<Response<ShareUserQuizDTO>> Handle(GetShareUserQuizQuery request, CancellationToken cancellationToken)
        {
            //Fetch date from database
            QuickQuestionBank.Domain.Entities.ShareUserQuiz result = await _repository.GetByIdAsync(request.Id);

            //Map using automapper or custom mapper
            ShareUserQuizDTO topicdto = new();
            ShareUserQuizDTO.MapEntityToDto(result, topicdto);
            return new Response<ShareUserQuizDTO>()
            {
                Data = topicdto,
                Message = "Sub Topics found successfully!",
                Count = 1,
            };
        }
    }
}
