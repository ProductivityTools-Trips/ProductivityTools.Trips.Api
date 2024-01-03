using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTools.Trips.Api.Db
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public string? Name { get; set; }
        public int TripId { get; set; }
        public int CurrencyId { get; set; }
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public decimal Expensed { get; set; }

        public decimal FamilyCost { get; set; }
        public decimal? FriendsDebit { get; set; }
    }
}
