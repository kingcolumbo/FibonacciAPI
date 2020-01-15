using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using FibonacciApi.Business;

namespace FibonacciApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FibController : ControllerBase
    {
        private readonly ILogger<FibController> _logger;

        public FibController(ILogger<FibController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets the n-th value in the Fibonnacci Sequence using matrices and principles of linear recurrence
        /// </summary>
        /// <param name="n"></param>
        /// <returns>the n-th value in the fib sequence</returns>
        [HttpGet]
        [Route("{n}")]
        [Authorize]        
        public ActionResult<string> Get(int n)
        {
            _logger.LogInformation("Beginning a fibonnacci search!");
            try
            {
                //create new fib object and return the result
                var f = new Fib();
                var res = f.FindFib(n);
                return Ok(res.ToString());
            }
            catch (OverflowException e) //catch any result overflow issues if it becomes too large
            {
                _logger.LogError(e.ToString());
            }        
            //return generic error for security reasons
            return BadRequest("Error has occurred");
        }
    }
}
