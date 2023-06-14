using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QuickQuestionBank.Application.Features.UserQuiz.Commands;
using QuickQuestionBank.Application.Features.UserQuiz.Queries;
using QuickQuestionBank.Domain.DTOs;

namespace QuickQuestionBank.API.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserQuizController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly Application.Interfaces.IRepository.IMailService _mailService;

        public UserQuizController(IMediator mediator, Application.Interfaces.IRepository.IMailService mailService)
        {
            this._mediator = mediator;
            this._mailService = mailService;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get(Guid id) =>
            Ok(await _mediator.Send(new GetUserQuizQuery { Id = id }));

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll() =>
            Ok(await _mediator.Send(new GetAllUserQuizQuery()));

        [HttpPost]
        [Route("save")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(List<UserQuizDTO> model)
        {
            for (int i = 0; i < model.Count; i++)
            {
                await _mediator.Send(new CreateUserQuizCommand { model = model[i] });
            }
            return Ok();//return Ok(response);
        }

        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var response = await _mediator.Send(new DeleteUserQuizQuery { Id = id });
            if (response.Count == 0)
            {
                return NotFound();
            }
            return Ok(response);
        }

    }
}
