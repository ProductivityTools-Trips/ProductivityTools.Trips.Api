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
            var r = this.TripContext.Expenses.Where(x => x.TripId == tripId).ToList();
            return r;
        }

        [HttpGet("GetFullView")]
        public List<ExpenseFullView> GetFullView(int tripId)
        {
            var r = this.TripContext.ExpensesFullView.Where(x => x.TripId == tripId).ToList();
            return r;
        }

        [HttpGet("Get")]
        public Expense Get(int id)
        {
            var r = this.TripContext.Expenses.Where(x => x.ExpenseId == id).Single();
            return r;
        }


        [HttpPost("Save")]
        public StatusCodeResult Save(Expense expense)
        {
            var r = TripContext.Expenses.Where(x => x.ExpenseId == expense.ExpenseId).Single();
            r.Name = expense.Name;
            r.Value = expense.Value;
            r.Discount = expense.Discount;
            r.CurrencyId= expense.CurrencyId;
            r.CategoryId= expense.CategoryId;
            r.Date= expense.Date;
            TripContext.SaveChanges();
            return Ok();
        }

        [HttpPost("Add")]
        public StatusCodeResult Add(Expense expense)
        {
            TripContext.Expenses.Add(expense);
            TripContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("Delete")]
        public StatusCodeResult Delete(int expenseId)
        {
            var e=TripContext.Expenses.Single(x => x.ExpenseId == expenseId);
            TripContext.Remove(e);
            TripContext.SaveChanges();
            return Ok();
        }
    }
}
