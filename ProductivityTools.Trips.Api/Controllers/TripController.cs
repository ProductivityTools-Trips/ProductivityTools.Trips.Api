using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductivityTools.Trips.Api.Db;

namespace ProductivityTools.Trips.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly TripContext TripContext;
        public TripController(TripContext context)
        {
            this.TripContext = context;
        }

        [HttpGet("Date")]
        public string Get()
        {
            return DateTime.Now.ToString();
        }

        [HttpGet("List")]
        public List<Trip> List()
        {
            var r = TripContext.Trips.ToList();
            return r;
        }

        [HttpGet("FullView")]
        public List<TripFullView> FullView()
        {
            var r = TripContext.TripFullView.ToList();
            return r;
        }

        [HttpGet("Get")]
        public Trip Get(int id)
        {
            var r = TripContext.Trips.Where(x => x.TripId == id).Single();
            return r;
        }


        [HttpPost("Add")]
        public StatusCodeResult Add(Trip trip)
        {
            TripContext.Trips.Add(trip);
            TripContext.SaveChanges();
            return Ok();
        }

        [HttpPost("Save")]
        public StatusCodeResult Save(Trip trip)
        {
            var r = TripContext.Trips.Where(x => x.TripId == trip.TripId).Single();
            r.Name = trip.Name;
            r.Start= trip.Start;
            r.End= trip.End;
            r.Description= trip.Description;
            r.Days= trip.Days;
            r.Nights=trip.Nights;
            r.Learnings = trip.Learnings;
            TripContext.SaveChanges();
            return Ok();
        }


    }
}
