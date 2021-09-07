using System.Collections.Generic;
using System.Linq;
using PosTerminal.Core.Exceptions;

namespace PosTerminal.Core.Models
{
    public class ApplicationSettings
    {
        public string CurrentCountry { get; }
        public IList<Country> Countries { get; }

        public ApplicationSettings(IList<Country> countries, string currentCountry)
        {
            Countries = countries;
            CurrentCountry = currentCountry;
        }

        public decimal[] GetDenominationsForCurrentCountry()
        {
            if (string.IsNullOrEmpty(CurrentCountry) || Countries.All(x => x.Name != CurrentCountry))
            {
                throw new CountryNotFoundException(CurrentCountry, Countries.Select(x => x.Name));
            }

            return Countries.FirstOrDefault(x => x.Name == CurrentCountry)!.Denominations;
        }
    }

    public class Country
    {
        public string Name { get; }
        public decimal[] Denominations { get; }

        public Country(string name, decimal[] denominations)
        {
            Name = name;
            Denominations = denominations;
        }
    }
}