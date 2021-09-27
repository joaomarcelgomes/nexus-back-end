using System;
using Backend.Domain.Commands;
using Backend.Domain.Commands.BuyCommands;
using Backend.Domain.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/buy")]
    public class BuyController : ControllerBase
    {
        [HttpPost("create")]
        public ActionResult<GenericCommandResult> Create([FromServices] BuyHandler handler,
            [FromBody] CreateBuyCommand command)
        {
            try
            {
                var response = (GenericCommandResult) handler.Handle(command);

                return response.Success? Ok(response) : BadRequest(response);
            }
            catch(Exception)
            {
                return BadRequest(new GenericCommandResult(false, "Error in try to create buy", command));
            }
        }
    }
}