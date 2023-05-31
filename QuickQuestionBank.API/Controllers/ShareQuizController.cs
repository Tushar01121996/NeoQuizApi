using MailKit;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using QuickQuestionBank.Application.Features.ShareQuiz.Commands;
using QuickQuestionBank.Application.Features.ShareQuiz.Queries;
using QuickQuestionBank.Domain.DTOs;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Infrastructure.Services.Repository;
using QuickQuestionBank.Domain.Entities;
using Microsoft.IdentityModel.Abstractions;

namespace QuickQuestionBank.API.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class ShareQuizController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly Application.Interfaces.IRepository.IMailService _mailService;

        public ShareQuizController(IMediator mediator, Application.Interfaces.IRepository.IMailService mailService)
        {
            this._mediator = mediator;
            this._mailService = mailService;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll() =>
            Ok(await _mediator.Send(new GetAllShareQuizQuery()));

        [HttpPost]
        [Route("save")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(List<ShareQuizDTO> model)
        {
            MailRequest mailRequest = new MailRequest();
            for (int i=0; i < model.Count; i++)
            {
                mailRequest.Body = model[i].Link;
                mailRequest.Subject = "Neo Quiz";
                mailRequest.ToEmail = model[i].Email;
                var response = await _mediator.Send(new CreateShareQuizCommand { model = model[i] });
                if(response!=null)
                {
                    await _mailService.SendEmailAsync(mailRequest);
                }
            }
            return Ok();
        }
    }
}
