﻿using MediatR;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Features.QuizQuestion.Queries
{
    public class GetByTopicIdQuizQuestionQuery : IRequest<Response<List<QuizQuestionDTO>>>
    {
        public Guid? TopicId { get; set; }

        public Guid? SubTopicId { get; set; }
    }
}
