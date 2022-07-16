using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTools.Trips.Api.Db
{
    public class TripCurrency
    {
        public int TripCurrencyId { get; set; }
        public int TripId { get; set; }
        public int CurrencyId { get; set; }
        public decimal Value { get; set; }
    }
}
