using MediatR;
using QuickQuestionBank.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.FeaturesUserInfo.Queries
{
    public class DeleteUserInfoQuery : IRequest<Response<Guid?>>
    {
        public Guid Id { get; set; }
    }
}