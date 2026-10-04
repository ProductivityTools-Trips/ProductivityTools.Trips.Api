using System;
using System.Linq;

namespace ProductivityTools.Trips.Api.Db
{
    /// <summary>
    /// Allowed values of <see cref="Trip.TripType"/>. Stored as text so the
    /// API payload stays human readable ("Family", not 0).
    /// </summary>
    public static class TripTypes
    {
        public const string Family = "Family";
        public const string Friends = "Friends";
        public const string Company = "Company";

        public static readonly string[] All = { Family, Friends, Company };

        /// <summary>Maps any casing to the canonical value; unknown/empty falls back to Family.</summary>
        public static string Normalize(string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return Family;
            return All.FirstOrDefault(t => string.Equals(t, value.Trim(), StringComparison.OrdinalIgnoreCase)) ?? Family;
        }
    }
}
