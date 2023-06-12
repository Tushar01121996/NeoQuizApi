using MediatR;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Features.Topics.Commands
{
    public class CreateTopicsCommand: IRequest<Response<TopicsDTO>>
    {
        public TopicsDTO model { get; set; }
    }
}

