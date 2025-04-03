using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductivityTools.Trips.Api.Db;

namespace ProductivityTools.Trips.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DebugController : Controller
    {
        private readonly TripContext TripContext;

        public DebugController(TripContext context)
        {
            this.TripContext = context;
        }

        [HttpGet]
        [Route("Date")]
        public string Date()
        {
            return DateTime.Now.ToString();
        }

        [HttpGet]
        [Route("AppName")]
        public string AppName()
        {
            return "PTTrips";
        }

        [HttpPost]
        [Route("Hello")]
        public string Hello(object s)
        {
            return string.Concat($"Hello {s.ToString()} Current date:{DateTime.Now}");
        }

        [HttpGet]
        [Route("ServerName")]
        public string ServerName()
        {
            string server = this.TripContext.Database.SqlQuery<string>($"select @@SERVERNAME as value").Single();
            return server;
        }
    }

}
