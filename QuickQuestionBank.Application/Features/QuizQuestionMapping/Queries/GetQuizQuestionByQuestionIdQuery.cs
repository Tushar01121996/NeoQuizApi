﻿using MediatR;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Domain.DTOs;

namespace QuickQuestionBank.Application.Features.QuestionAnswerMapping.Queries
{
    public class GetQuizQuestionByQuestionIdQuery : IRequest<Response<List<QuestionOptionViewModelDTO>>>
    {
        public Guid Id { get; set; }
    }
}
