﻿using MediatR;
using QuickQuestionBank.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Features.UserQuiz.Queries
{
    public class DeleteUserQuizQuery : IRequest<Response<Guid?>>
    {
        public Guid Id { get; set; }
    }
}