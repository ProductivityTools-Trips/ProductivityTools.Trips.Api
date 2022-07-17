using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductivityTools.Trips.Api.Db;

namespace ProductivityTools.Trips.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalController : ControllerBase
    {

        private readonly TripContext TripContext;
        public JournalController(TripContext context)
        {
            this.TripContext = context;
        }

        [HttpGet("GetForTrip")]
        public List<Journal> GetForTrip(int tripId)
        {
            var x = this.TripContext.Journals.Where(x => x.TripId == tripId).ToList();
            return x;
        }

        [HttpPost("Add")]
        public void Add(Journal journal)
        {
            this.TripContext.Journals.Add(journal);
            this.TripContext.SaveChanges();
        }
    }
}
