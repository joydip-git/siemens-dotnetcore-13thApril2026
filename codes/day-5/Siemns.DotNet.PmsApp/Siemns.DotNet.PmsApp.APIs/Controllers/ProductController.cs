using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Siemns.DotNet.PmsApp.APIs.Models.Entities;
using Siemns.DotNet.PmsApp.APIs.Models.Repository;

namespace Siemns.DotNet.PmsApp.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("all")]
        public ICollection<Product> GetAllProducts()
        {
            DbContextOptionsBuilder<SiemensDbContext> builder = new();
            DbContextOptions<SiemensDbContext> options = builder
                .UseSqlServer("Data Source=JOYDIP-PC\\SQLEXPRESS;database=siemensdb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30")
                .Options;

            using var db = new SiemensDbContext(options);
            DbSet<Product> all = db.Products;
            //return all.ToList();
            return [.. all];
        }
    }
}
