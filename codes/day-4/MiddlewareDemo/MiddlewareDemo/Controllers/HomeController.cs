using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiddlewareDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [Route("welcome/{name?}")] //{name:"joydip"}
        public string Greet([FromRoute(Name = "name")] string? personName)
        {
            return $"welcome to RESTful API (web api) {personName ?? "NA"}";
        }
    }
}
