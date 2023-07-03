using MediatR;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Domain.DTOs;
using QuickQuestionBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Features.Report.Commands
{
    public class AllUserResultCommand : IRequest<DataTable>
    {
       // public LoginUser login { get; set; }
        public Guid quizId { get; set; }

    }
}
