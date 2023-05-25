using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QuickQuestionBank.Application.Features.QuestionAnswerMapping.Commands;
using QuickQuestionBank.Application.Features.QuestionAnswerMapping.Queries;
using QuickQuestionBank.Domain.DTOs;

namespace QuickQuestionBank.API.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class QuesAnsMappingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuesAnsMappingController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get(Guid id) =>
            Ok(await _mediator.Send(new GetQuestionAnswerMappingQuery { Id = id }));

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll() =>
            Ok(await _mediator.Send(new GetAllQuestionAnswerMappingQuery()));

        [HttpGet]
        [Route("get-all-by-QuestionId")]
        public async Task<IActionResult> GetAllByQuestionId(Guid id) =>
           Ok(await _mediator.Send(new GetQuestionAnswerByQuestionIdQuery { Id = id }));

        [HttpPost]
        [Route("save")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(QuestionAnswerMappingDTO model)
        {
            var response = await _mediator.Send(new CreateQuestionAnswerMappingCommand { model = model });
            return Ok(response);
        }

        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var response = await _mediator.Send(new DeleteQuestionAnswerMappingQuery { Id = id });
            if (response.Count == 0)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
