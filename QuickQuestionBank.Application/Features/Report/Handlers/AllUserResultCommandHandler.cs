using MediatR;
using Microsoft.IdentityModel.Tokens;
using QuickQuestionBank.Application.Features.Login.Commands;
using QuickQuestionBank.Application.Features.Report.Commands;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain.Entities;
using System;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Features.Report.Handlers
{
    public class AllUserResultCommandHandler : IRequestHandler<AllUserResultCommand, DataTable>
    {
        private readonly IReportRepository _repository;
        public AllUserResultCommandHandler(IReportRepository repository) 
        {
            _repository = repository;
        }
        public Task<DataTable> Handle(AllUserResultCommand request, CancellationToken cancellationToken)
        {
            // Authenticate the user based on the provided credentials
            Task<DataTable> result = _repository.GetAllUserResultbyQuizIdAsync(request.quizId);
            return result;

           // throw new UnauthorizedAccessException("Invalid credentials");
        }

        
    }
}
