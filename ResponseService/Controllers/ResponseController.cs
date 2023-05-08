using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ResponseService.Controllers
{
    [Route("api/response")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        [Route("{id}")]
        [HttpGet]
        public ActionResult GetResponse([FromRoute] int id)
        {
            Random rnd = new Random();
            int rndInt = rnd.Next(1, 101);
            if (rndInt >= id)
            {
                Console.WriteLine($"-> Return 500");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            else
            {
                Console.WriteLine($"-> Return 200");
                return Ok();
            }
        }
    }
}
