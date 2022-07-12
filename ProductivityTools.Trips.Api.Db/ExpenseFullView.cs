using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTools.Trips.Api.Db
{
    public class ExpenseFullView
    {
        public int TripId { get; set; }
        public string TripName { get; set; }
        public int ExpenseId { get; set; }
        public string ExpenseName { get; set; }
        public DateTime Date{get;set;}
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public decimal Value { get; set; }
        public decimal Discount { get; set; }
        public decimal ValueAfterDiscount { get; set; }
        public Nullable<decimal> Exchange { get; set; }
        public decimal Pln { get; set; }

        public decimal PlnAfterDiscount { get; set; }
        public decimal DayInPln { get; set; }
    }
}
