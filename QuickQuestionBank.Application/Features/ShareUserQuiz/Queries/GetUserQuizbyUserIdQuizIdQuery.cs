﻿using MediatR;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Features.UserQuiz.Queries
{
    public class GetUserQuizbyUserIdQuizIdQuery : IRequest<Response<UserQuizDTO>>
    {
        public Guid userId { get; set; }
        public Guid quizId { get; set; }
    }
}