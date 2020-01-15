using Microsoft.AspNetCore.Mvc;

namespace FibonacciApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ErrorController : ControllerBase
    {

        [Route("/error")]
        public IActionResult Error() => Problem();
    }
}
