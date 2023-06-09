﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QuickQuestionBank.Application.Features.UserInfo.Commands;
using QuickQuestionBank.Application.Features.UserInfo.Queries;
using QuickQuestionBank.Application.FeaturesUserInfo.Queries;
using QuickQuestionBank.Domain.DTOs;

namespace QuickQuestionBank.API.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserInfoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserInfoController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get(Guid id) =>
            Ok(await _mediator.Send(new GetUserInfoQuery { Id = id }));

        [HttpGet]
        [Authorize]
        [Route("getUnAssignedUser")]
        public async Task<IActionResult> GetUnAssignedById(Guid? QuizId) =>
       Ok(await _mediator.Send(new GetUnAssignedUserInfoQuery {QuizId=QuizId }));

        [HttpGet]
        [Authorize]
        [Route("get-all")]
        public async Task<IActionResult> GetAll() =>
            Ok(await _mediator.Send(new GetAllUserInfoQuery()));

        [HttpPost]
        [Authorize]
        [Route("save")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(UserInfoDTO model)
        {
            var response = await _mediator.Send(new CreateUserInfoCommand { model = model });
            return Ok(response);
        }

        [HttpDelete("id")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var response = await _mediator.Send(new DeleteUserInfoQuery { Id = id });
            if (response.Count == 0)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
