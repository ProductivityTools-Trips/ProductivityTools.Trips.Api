using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductivityTools.Trips.Api.Db;

namespace ProductivityTools.Trips.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {

        private readonly TripContext TripContext;
        public CurrencyController(TripContext context)
        {
            this.TripContext = context;
        }

        [HttpGet("GetForTrip")]
        public List<TripCurrencyFullView> GetForTrip(int tripId)
        {
            var x = this.TripContext.TripCurrencyFullView.Where(x => x.TripId == tripId).ToList();
            return x;
        }

        [HttpPost("AddCurrency")]
        public void AddCurrency(TripCurrency tripCurrency)
        {
            this.TripContext.TripCurrencies.Add(tripCurrency);
            this.TripContext.SaveChanges();
        }
    }
}
