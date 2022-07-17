using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTools.Trips.Api.Db
{
    public class Journal
    {
        public int JournalId { get; set; }
        public int TripId { get; set; }
        public string? Notes { get; set; }
    }
}
