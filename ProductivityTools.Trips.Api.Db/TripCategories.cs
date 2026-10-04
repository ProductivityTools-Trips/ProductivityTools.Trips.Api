using System;
using System.Linq;

namespace ProductivityTools.Trips.Api.Db
{
    /// <summary>
    /// Allowed values of <see cref="Trip.TripCategory"/>. Optional – null means
    /// "no category".
    /// </summary>
    public static class TripCategories
    {
        public const string Ski = "Ski";
        public const string CityBreak = "CityBreak";
        public const string Vacations = "Vacations";
        public const string Festival = "Festival";
        public const string Spain = "Spain";

        public static readonly string[] All = { Ski, CityBreak, Vacations, Festival, Spain };

        /// <summary>Maps any casing to the canonical value; unknown/empty becomes null.</summary>
        public static string? Normalize(string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return null;
            return All.FirstOrDefault(c => string.Equals(c, value.Trim(), StringComparison.OrdinalIgnoreCase));
        }
    }
}
