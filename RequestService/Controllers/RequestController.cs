using Microsoft.AspNetCore.Mvc;
using RequestService.Policies;

namespace RequestService.Controllers
{
    [Route("api/request")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly ClientPolicy _clientPolicy;
        private readonly IHttpClientFactory _clientFactory;

        public RequestController(ClientPolicy clientPolicy, IHttpClientFactory clientFactory)
        {
            _clientPolicy = clientPolicy;
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<ActionResult> MakeRequest()
        {

            //var client = new HttpClient();
            var client = _clientFactory.CreateClient("TestClient");

            //var response = await _clientPolicy.ImmediateHttpRetry.ExecuteAsync(
            //    () => client.GetAsync("https://localhost:7126/api/response/25"));

            var response = await client.GetAsync("https://localhost:7126/api/response25");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Success");
                return Ok();
            }
            Console.WriteLine("Failure");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
