﻿using Microsoft.AspNetCore.Http;
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

        [HttpGet( "Date")]
        public string Get()
        {
            return DateTime.Now.ToString();
        }

        [HttpGet("List")]
        public List<Trip> List()
        {
            var r=TripContext.Trips.ToList();
            return r;
        }

        [HttpGet("Get")]
        public Trip Get(int id)
        {
            var r = TripContext.Trips.Where(x=>x.BagID==id).Single();
            return r;
        }

        [HttpPost("Save")]
        public StatusCodeResult Save(Trip trip)
        {
            var r = TripContext.Trips.Where(x => x.BagID == trip.BagID).Single();
            r.Name = trip.Name;
            TripContext.SaveChanges();
            return Ok();
        }


    }
}
