using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QuickQuestionBank.Application.Features.QuestionAnswerMapping.Queries;
using QuickQuestionBank.Application.Features.QuizQuestionMapping.Commands;
using QuickQuestionBank.Application.Features.QuizQuestionMapping.Queries;
using QuickQuestionBank.Domain.DTOs;

namespace QuickQuestionBank.API.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class QuizQuestionMappingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuizQuestionMappingController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        
        [HttpGet]
        [Route("get-all-by-QuizId")]
        public async Task<IActionResult> GetAllByQuizId(Guid id) =>
           Ok(await _mediator.Send(new GetQuizQuestionByQuestionIdQuery { Id = id }));

        [HttpPost]
        [Route("save")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(QuizQuestionMappingDTO model)
        {
            var response = await _mediator.Send(new CreateQuizQuestionMappingCommand { model = model });
            return Ok(response);
        }

        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var response = await _mediator.Send(new DeleteQuizQuestionMappingQuery { Id = id });
            if (response.Count == 0)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
