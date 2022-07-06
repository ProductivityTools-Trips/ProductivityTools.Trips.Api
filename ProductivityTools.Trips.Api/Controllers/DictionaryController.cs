using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductivityTools.Trips.Api.Db;

namespace ProductivityTools.Trips.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictionaryController : ControllerBase
    {
        private readonly TripContext TripContext;
        public DictionaryController(TripContext context)
        {
            this.TripContext = context;
        }

        [HttpGet("Currencies")]
        public List<Currency> Currenncy()
        {
            var x = this.TripContext.Currency.ToList();
            return x;
        }
    }
}
