using Microsoft.AspNetCore.Mvc;

namespace lab4PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        [HttpDelete]
        public IResult re()
        {
            return Results.Content("er");
        }
    }
}
