using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Siemns.DotNet.PmsApp.APIs.Models.Dao.Abstractions;
using Siemns.DotNet.PmsApp.APIs.Models.Entities;
using Siemns.DotNet.PmsApp.APIs.Models.Repository;

namespace Siemns.DotNet.PmsApp.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IDbService<Product,int> dbService) : ControllerBase
    {
        private readonly IDbService<Product, int> dbService = dbService;

        [HttpGet]
        [Route("all")]
        public ICollection<Product> GetAllProducts()
        {
            return [];
        }
    }
}
