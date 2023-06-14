using AutoMapper;
using MediatR;
using QuickQuestionBank.Application.Features.QuizQuestion.Queries;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Features.QuizQuestion.Handlers
{
    public class GetByTopicIdQuizQuestionCommandRequestHandler : IRequestHandler<GetByTopicIdQuizQuestionQuery, Response<List<QuizQuestionDTO>>>
    {
        private readonly IQuizQuestionRepository _repository;
        private readonly IMapper _mapper;

        public GetByTopicIdQuizQuestionCommandRequestHandler(IQuizQuestionRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<Response<List<QuizQuestionDTO>>> Handle(GetByTopicIdQuizQuestionQuery request, CancellationToken cancellationToken)
        {
           
            //Fetch date from database
           List<QuickQuestionBank.Domain.Entities.QuizQuestion> result = await _repository.GetByTopicIdAsync(request.TopicId,request.SubTopicId);

            List<QuizQuestionDTO> list = new();
            //Map
            foreach (var quiz in result)
            {
                QuizQuestionDTO quizDTO = new();
                QuizQuestionDTO.MapEntityToDto(quiz, quizDTO);
                list.Add(quizDTO);
            }

            //Return
            return new Response<List<QuizQuestionDTO>>
            {
                Data = list,
                Message = "Quiz Questions data found!",
                Count = list.Count
            };
        }
    }
}

