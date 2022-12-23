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

        [HttpGet("Get")]
        public Journal Get(int journalId)
        {
            var x = this.TripContext.Journals.Where(x => x.JournalId == journalId).Single();
            return x;
        }

        [HttpPost("Add")]
        public int Add(Journal journal)
        {
            this.TripContext.Journals.Add(journal);
            this.TripContext.SaveChanges();
            return journal.JournalId;
        }

        [HttpPost("Update")]
        public void Update(Journal journal)
        {
            var j=this.TripContext.Journals.Single(x => x.JournalId == journal.JournalId);
            j.Notes = journal.Notes;
            this.TripContext.SaveChanges();
        }
    }
}
