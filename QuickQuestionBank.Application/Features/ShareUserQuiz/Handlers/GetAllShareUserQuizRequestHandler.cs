using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.QuestionType.Queries;
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
    public class GetAllShareUserQuizQueryRequestHandler : IRequestHandler<GetAllShareUserQuizQuery, Response<List<ShareUserQuizDTO>>>
    {
        private readonly IShareUserQuizRepository _repository;
        private readonly IMapper _mapper;

        public GetAllShareUserQuizQueryRequestHandler(IShareUserQuizRepository repository, IMapper mapper)
        {
            this._repository = repository;
            _mapper = mapper;
        }

        public IMapper Mapper { get; }

        public async Task<Response<List<ShareUserQuizDTO>>> Handle(GetAllShareUserQuizQuery request, CancellationToken cancellationToken)
        {
            //Fetch
            IReadOnlyList<QuickQuestionBank.Domain.Entities.ShareUserQuiz> result = await _repository.GetAllAsync();



            List<ShareUserQuizDTO> list = new();
            //Map
            foreach (var quiz in result)
            {
                ShareUserQuizDTO topicDTO = new();
                ShareUserQuizDTO.MapEntityToDto(quiz, topicDTO);
                list.Add(topicDTO);
            }

            //Return
            return new Response<List<ShareUserQuizDTO>>
            {
                Data = list,
                Message = "Share Quizes found!",
                Count = list.Count
            };
        }
    }
}
