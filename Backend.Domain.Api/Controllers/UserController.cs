using System;
using System.Threading.Tasks;
using Backend.Domain.Api.Services;
using Backend.Domain.Commands;
using Backend.Domain.Commands.UserCommands;
using Backend.Domain.Entities;
using Backend.Domain.Handlers;
using Backend.Domain.Repositories;
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

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<GenericCommandResult>> Login([FromServices] IUserRepository repository,
            [FromBody] User model)
        {
            try
            {
                var response = await repository.Login(model.Email, model.Password);

                if (response != null)
                {
                    var token = TokenService.GenerateToken(response);

                    return Ok(new {response = response, token = token});
                }

                return NotFound(new GenericCommandResult(false, "User not found", model));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(new GenericCommandResult(false, "Error trying to login", model));
            }
        }
    }
}