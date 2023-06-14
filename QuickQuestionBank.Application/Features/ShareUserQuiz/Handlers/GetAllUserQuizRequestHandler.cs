using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.QuestionType.Queries;
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
    public class GetAllUserQuizQueryRequestHandler : IRequestHandler<GetAllUserQuizQuery, Response<List<UserQuizDTO>>>
    {
        private readonly IUserQuizRepository _repository;
        private readonly IMapper _mapper;

        public GetAllUserQuizQueryRequestHandler(IUserQuizRepository repository, IMapper mapper)
        {
            this._repository = repository;
            _mapper = mapper;
        }

        public IMapper Mapper { get; }

        public async Task<Response<List<UserQuizDTO>>> Handle(GetAllUserQuizQuery request, CancellationToken cancellationToken)
        {
            //Fetch
            IReadOnlyList<QuickQuestionBank.Domain.Entities.UserQuiz> result = await _repository.GetAllAsync();



            List<UserQuizDTO> list = new();
            //Map
            foreach (var quiz in result)
            {
                UserQuizDTO topicDTO = new();
                UserQuizDTO.MapEntityToDto(quiz, topicDTO);
                list.Add(topicDTO);
            }

            //Return
            return new Response<List<UserQuizDTO>>
            {
                Data = list,
                Message = "Share Quizes found!",
                Count = list.Count
            };
        }
    }
}
