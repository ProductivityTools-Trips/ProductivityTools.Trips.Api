using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductivityTools.Trips.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {

        [HttpGet( "Date")]
        public string Get()
        {
            return DateTime.Now.ToString();
        }

        [HttpGet("List")]
        public string List()
        {
            return DateTime.Now.ToString();
        }
    }
}
