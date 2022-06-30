using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductivityTools.Trips.Api.Db;

namespace ProductivityTools.Trips.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly TripContext TripContext;
        public ExpenseController(TripContext context)
        {
            this.TripContext = context;
        }
        [HttpGet("Get")]
        public List<Expense> Get(int id)
        {
            var r = this.TripContext.Expenses.Where(x=>x.BagId==id).ToList();
            return r;
        }
    }
}
