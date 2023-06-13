using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QuickQuestionBank.Application.Features.ShareUserQuiz.Commands;
using QuickQuestionBank.Application.Features.ShareUserQuiz.Queries;
using QuickQuestionBank.Domain.DTOs;

namespace QuickQuestionBank.API.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShareUserQuizController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly Application.Interfaces.IRepository.IMailService _mailService;

        public ShareUserQuizController(IMediator mediator, Application.Interfaces.IRepository.IMailService mailService)
        {
            this._mediator = mediator;
            this._mailService = mailService;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get(Guid id) =>
            Ok(await _mediator.Send(new GetShareUserQuizQuery { Id = id }));

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll() =>
            Ok(await _mediator.Send(new GetAllShareUserQuizQuery()));

        [HttpPost]
        [Route("save")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(List<ShareUserQuizDTO> model)
        {
            for (int i = 0; i < model.Count; i++)
            {
                await _mediator.Send(new CreateShareUserQuizCommand { model = model[i] });
            }
            return Ok();//return Ok(response);
        }

        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var response = await _mediator.Send(new DeleteShareUserQuizQuery { Id = id });
            if (response.Count == 0)
            {
                return NotFound();
            }
            return Ok(response);
        }

    }
}
