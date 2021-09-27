using System;
using System.Collections;
using System.Threading.Tasks;
using Backend.Domain.Commands;
using Backend.Domain.Commands.BuyCommands;
using Backend.Domain.Handlers;
using Backend.Domain.Repositories;
using Backend.Domain.Shared.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/buy")]
    public class BuyController : ControllerBase
    {
        [HttpPost("create")]
        [Authorize(Roles = "Client")]
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

        [HttpGet("{id:guid}/products")]
        [Authorize(Roles = "Client")]
        public async Task<ActionResult<GenericCommandResult>> FindById([FromServices] IBuyRepository repository,[FromQuery] PaginationFilter filter, Guid id)
        {
            try
            {
                PaginationFilter paginationFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

                var buy = await repository.FindById(paginationFilter, id);

                if(buy == null)
                    return NotFound(new GenericCommandResult(false, "No buy were found", new ArrayList()));

                return Ok(new GenericCommandResult(true, "Buy", buy));
            }
            catch (Exception ex)
            {   Console.WriteLine(ex.Message);
                return BadRequest(new GenericCommandResult(false, "Error in try to query the buy", new ArrayList()));
            }
        }

        [HttpGet("results")]
        [Authorize(Roles = "Client")]
        public async Task<ActionResult<GenericCommandResult>> Results([FromServices] IBuyRepository repository,[FromQuery] PaginationFilter filter)
        {
            try
            {
                PaginationFilter paginationFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

                var buys = await repository.FindAll(paginationFilter);

                if(buys.Count == 0)
                    return NotFound(new GenericCommandResult(false, "No buys were found", new ArrayList()));

                return Ok(new GenericCommandResult(true, "Buy(s)", buys));
            }
            catch (Exception)
            {
                return BadRequest(new GenericCommandResult(false, "Error in try to query the buy(s)", new ArrayList()));
            }
        }
    }
}