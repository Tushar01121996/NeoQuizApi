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
        [Authorize]
        [Route("get")]
        public async Task<IActionResult> Get(Guid id) =>
            Ok(await _mediator.Send(new GetUserQuizQuery { Id = id }));

        [HttpGet]
        [Route("getbyUserIdandQuizId")]
        public async Task<IActionResult> GetbyUserIdandQuizId(Guid userId, Guid quizId) =>
            Ok(await _mediator.Send(new GetUserQuizbyUserIdQuizIdQuery { userId = userId, quizId = quizId }));

        [HttpGet]
        [Authorize]
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

        [HttpPost]
        [Route("UserQuizsave")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UserQuizPost(UserQuizAttemptDTO model, string totalTime)
        {
            await _mediator.Send(new CreateUserQuizAttemptCommand { model = model, totalTime = totalTime });
            return Ok();
        }

        [HttpDelete("id")]
        [Authorize]
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
        //[HttpPut("updateUserQuizAttempt")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesDefaultResponseType]
        //public async Task<ActionResult> updateUserQuizAttempt(Guid userId, Guid quizId)
        //{
        //    //var response = await _mediator.Send(new DeleteUserQuizQuery { Id = id });
        //    //if (response.Count == 0)
        //    //{
        //    //    return NotFound();
        //    //}
        //    return Ok(response);
        //}

    }
}
