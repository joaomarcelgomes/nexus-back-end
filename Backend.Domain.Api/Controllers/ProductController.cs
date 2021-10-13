using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Backend.Domain.Commands;
using Backend.Domain.Commands.ProductCommands;
using Backend.Domain.Handlers;
using Backend.Domain.Repositories;
using Backend.Domain.Shared.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Domain.Api.Controllers
{    
    [ApiController]
    [Route("v1/product")]
    public class ProductController : ControllerBase
    {
        public static IWebHostEnvironment _environment;
        public ProductController(IWebHostEnvironment environment) => _environment = environment;

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

        [HttpPost("create/image")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<GenericCommandResult>> CreateImage([FromServices] ProductHandler handler,
            [FromForm] IFormFile file)
        {
            try
            {
                var directory = _environment.WebRootPath + "../images/";

                if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

                using (FileStream filestream = System.IO.File.Create(directory + file.FileName))
                {
                    await file.CopyToAsync(filestream);
                    filestream.Flush();
                    return Ok(new GenericCommandResult(true, "Image saved successfully", file));
                }
            }
            catch(Exception)
            {
                return BadRequest(new GenericCommandResult(false, "Error in try to save image", file));
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

        [HttpGet("result/image/{id}")]
        [AllowAnonymous]
        public ActionResult<GenericCommandResult> ResultImage(string id)
        {
            Byte[] file = System.IO.File.ReadAllBytes(_environment.WebRootPath + "../images/" + id);

            if(file.Length > 0)
                return Ok(new GenericCommandResult(true, "Image", File(file, "image/jpeg")));
 
            return BadRequest(new GenericCommandResult(false, "Image not found", new Byte()));
        }
    }
}