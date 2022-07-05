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
        [HttpGet("GetList")]
        public List<Expense> GetList(int tripId)
        {
            var r = this.TripContext.Expenses.Where(x=>x.TripId== tripId).ToList();
            return r;
        }

        [HttpGet("Get")]
        public Expense Get(int id)
        {
            var r = this.TripContext.Expenses.Where(x => x.ExpenseID == id).Single();
            return r;
        }


        [HttpPost("Save")]
        public StatusCodeResult Save(Expense expense)
        {
            var r = TripContext.Expenses.Where(x => x.ExpenseID == expense.ExpenseID).Single();
            r.Name = expense.Name;
            TripContext.SaveChanges();
            return Ok();
        }
    }
}
