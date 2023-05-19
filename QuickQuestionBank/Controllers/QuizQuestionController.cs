using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QuickQuestionBank.Entities.Models;
using QuickQuestionBank.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuickQuestionBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizQuestionController : ControllerBase
    {
        private readonly QuestionBankContext _context;
        private readonly IConfiguration _configuration;

        public QuizQuestionController(QuestionBankContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserAdmin model)
        {
            var user = _context.UserAdmin.SingleOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(_configuration["JwtSecret"]);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //    new Claim(ClaimTypes.Name, user.Id.ToString())
            //    }),
            //    Expires = DateTime.UtcNow.AddDays(7),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //var tokenString = tokenHandler.WriteToken(token);
            //return Ok(new { token = tokenString });
            return Ok();
        }

        //[HttpPost("register")]
        //public IActionResult Register([FromBody] CreateUserAdminCommand model)
        //{
        //    var userAdmin = new CreateUserAdminCommand { UserName = model.UserName, Password = model.Password };
        //    _context.UserAdmin.Add(userAdmin);
        //    _context.SaveChanges();

        //    return Ok(new { message = "User created successfully" });
        //}

        [HttpPost("register")]
        public IActionResult Register([FromBody] CreateUserAdminCommand model)
        {
            var userAdmin = new UserAdmin
            {
                UserName = model.UserName,
                Password = model.Password,
                First_Name = model.First_Name,
                Last_Name = model.Last_Name,
                Email = model.Email,
                Createon = DateTime.Now
            };
            _context.UserAdmin.Add(userAdmin);
            _context.SaveChanges();

            return Ok(new { message = "User created successfully" });
        }

    }

}
