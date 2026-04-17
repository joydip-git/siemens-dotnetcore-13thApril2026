using Microsoft.AspNetCore.Mvc;
using Siemns.DotNet.PmsApp.APIs.Filters;
using Siemns.DotNet.PmsApp.APIs.Models.Dao.Abstractions;
using Siemns.DotNet.PmsApp.APIs.Models.DTOs;

namespace Siemns.DotNet.PmsApp.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //Approach:1
    //[TypeFilter<ProductExceptionFilter>]

    //Approach:2
    [ProductExceptionFilter]
    public class ProductController(IDbService<ProductDTO, int> dbService, ILogger<ProductController> logger) : ControllerBase
    {
        private readonly IDbService<ProductDTO, int> dbService = dbService;
        private readonly ILogger<ProductController> logger = logger;

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<ICollection<ProductDTO>>> GetAllProducts()
        {
            //try
            //{
            //{data:[], status code: 200, status text: OK}
            var records = await dbService.FetchAll();
            OkObjectResult okObjectResult = this.Ok(records);
            return okObjectResult;
            //}
            //catch (Exception e)
            //{
            //    ObjectResult problem = this.Problem(detail: e.ToString(), statusCode: 500);
            //    return problem;
            //}
        }

        [HttpGet]
        [Route("view/{id}")]
        public async Task<ActionResult<ProductDTO?>> GetProductById(int id)
        {
            //try
            //{
            var dto = await dbService.Fetch(id);
            logger.LogInformation(dto?.GetType().Name);
            if (dto != null)
                return this.Ok(dto);
            else
                return this.NoContent();
            //}
            //catch (Exception e)
            //{
            //    ObjectResult problem = this.Problem(detail: e.ToString(), statusCode: 500);
            //    return problem;
            //}
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<ProductDTO>> AddProduct([FromBody] ProductDTO p)
        {
            if (this.ModelState.IsValid)
            {
                //try
                //{
                var data = await dbService.Insert(p);
                return this.CreatedAtAction(nameof(AddProduct), data);
            }
            else
                throw new Exception("model invalid");
            //}
            //catch (Exception e)
            //{
            //    ObjectResult problem = this.Problem(detail: e.ToString(), statusCode: 500);
            //    return problem;
            //}
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<ProductDTO>> UpdateProduct([FromQuery(Name = "id")] int pid, [FromBody] ProductDTO p)
        {
            //try
            //{
            var dto = await dbService.Modify(pid, p);
            return this.AcceptedAtAction(nameof(UpdateProduct), dto);
            //}
            //catch (Exception e)
            //{
            //    ObjectResult problem = this.Problem(detail: e.ToString(), statusCode: 500);
            //    return problem;
            //}
        }

        [HttpDelete]
        [Route("delete/{pid}")]
        public async Task<ActionResult<ProductDTO>> DeleteProduct([FromRoute(Name = "pid")] int id)
        {
            //try
            //{
            var dto = await dbService.Remove(id);
            return this.Accepted(dto);
            //}
            //catch (Exception e)
            //{
            //    ObjectResult problem = this.Problem(detail: e.ToString(), statusCode: 500);
            //    return problem;
            //}
        }
    }
}
