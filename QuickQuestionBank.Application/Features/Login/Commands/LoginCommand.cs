using MediatR;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Domain.DTOs;
using QuickQuestionBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Features.Login.Commands
{
    public class LoginCommand : IRequest<string>
    {
       // public LoginUser login { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
