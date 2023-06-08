using MediatR;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Features.SubTopics.Commands
{
    public class CreateSubTopicsCommand : IRequest<Response<SubTopicsDTO>>
    {
        public SubTopicsDTO model { get; set; }
    }
}

