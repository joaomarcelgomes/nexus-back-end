using System;
using Backend.Domain.Commands;
using Backend.Domain.Commands.UserCommands;
using Backend.Domain.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/user")]
    public class UserController : ControllerBase
    {
        [HttpPost("create")]
        [AllowAnonymous]
        public ActionResult<GenericCommandResult> Create([FromServices] UserHandler handler, [FromBody] CreateUserCommand command)
        {
            try
            {
                var response = (GenericCommandResult) handler.Handle(command);

                return response.Success? Ok(response) : BadRequest(response);
            }
            catch(Exception)
            {
                return BadRequest(new GenericCommandResult(false, "Error in try to create user", command));
            }
        }
    }
}