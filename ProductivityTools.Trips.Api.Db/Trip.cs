using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTools.Trips.Api.Db
{
    public class Trip
    {
        public int TripId { get; set; }
        public string Name { get; set; }
        public int? Days { get; set; }
        public int? Nights { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string? Description { get; set; }
        public string? Learnings { get; set; }
    }
}
