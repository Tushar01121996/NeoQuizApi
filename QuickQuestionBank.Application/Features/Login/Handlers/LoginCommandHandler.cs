using MediatR;
using Microsoft.IdentityModel.Tokens;
using QuickQuestionBank.Application.Features.Login.Commands;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuickQuestionBank.Application.Features.Login.Handlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        public Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            // Authenticate the user based on the provided credentials
            bool isAuthenticated = AuthenticateUser(request.Username, request.Password);

            if (isAuthenticated)
            {
                // Generate JWT token
                var token = GenerateJwtToken(request.Username);
                return Task.FromResult(token);
            }

            throw new UnauthorizedAccessException("Invalid credentials");
        }

        private bool AuthenticateUser(string username, string password)
        {
            // Implement your authentication logic here
            // Example: check the username and password against a database
            return (username == "admin" && password == "password");
        }

        private string GenerateJwtToken(string username)
        {
            var key = Encoding.ASCII.GetBytes("8772ED32-E6A0-47A3-86E3-34C7D789F5C0"); // Replace with your actual secret key

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, username)
            }),
                Expires = DateTime.UtcNow.AddMinutes(60), // Token expires in 1 hour
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
