using System;
using System.Collections;
using System.Threading.Tasks;
using Backend.Domain.Commands;
using Backend.Domain.Commands.ProductCommands;
using Backend.Domain.Handlers;
using Backend.Domain.Repositories;
using Backend.Domain.Shared.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/product")]
    public class ProductController : ControllerBase
    {
        [HttpPost("create")]
        [Authorize(Roles = "Admin")]
        public ActionResult<GenericCommandResult> Create([FromServices] ProductHandler handler,
            [FromBody] CreateProductCommand command)
        {
            try
            {
                var response = (GenericCommandResult) handler.Handle(command);

                return response.Success? Ok(response) : BadRequest(response);
            }
            catch(Exception)
            {
                return BadRequest(new GenericCommandResult(false, "Error in try to create product", command));
            }
        }

        [HttpGet("results")]
        [AllowAnonymous]
        public async Task<ActionResult<GenericCommandResult>> Results([FromServices] IProductRepository repository,[FromQuery] PaginationFilter filter, [FromQuery] string search)
        {
            try
            {
                var paginationFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

                var products = string.IsNullOrEmpty(search)
                    ? await repository.FindAll(paginationFilter)
                    : await repository.FindByName(paginationFilter, search);

                if(products.Count == 0)
                    return NotFound(new GenericCommandResult(false, "No products were found", new ArrayList()));

                return Ok(new GenericCommandResult(true, "Products", products));
            }
            catch (Exception)
            {
                return BadRequest(new GenericCommandResult(false, "Error in try to query the product(s)", new ArrayList()));
            }
        }
    }
}