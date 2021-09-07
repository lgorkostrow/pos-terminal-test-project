using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PosTerminal.Core.Exceptions
{
    public class CountryNotFoundException : Exception
    {
        public CountryNotFoundException(string country, IEnumerable<string> availableCountries) : base(
            ConvertToErrorMessage(country, availableCountries))
        {
        }

        private static string ConvertToErrorMessage(string country, IEnumerable<string> availableCountries)
        {
            return $"Country - {country} not found in list of countries: {string.Join(", ", availableCountries)}";
        }
    }
}