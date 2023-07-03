using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QuickQuestionBank.Application.Features.Report.Commands;
using QuickQuestionBank.Application.Features.UserQuiz.Commands;
using QuickQuestionBank.Application.Features.UserQuiz.Queries;
using QuickQuestionBank.Domain.DTOs;
using System.Data;

namespace QuickQuestionBank.API.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    
    public class ReportController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        [Route("get")]
        public async Task<IActionResult> Get(AllUserResultCommand command)
        {
            DataTable dt = await _mediator.Send(command);
            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(dt));
        }
            

       
    }
}
