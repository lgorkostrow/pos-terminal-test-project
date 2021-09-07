using System;
using System.Collections.Generic;
using PosTerminal.Core.Exceptions;
using PosTerminal.Core.Models;
using Xunit;

namespace PosTerminal.Core.Test.Models
{
    public class ApplicationSettingsTest
    {
        [Theory]
        [MemberData(nameof(ValidTestData))]
        public void ShouldReturnDenominationsForCurrentCountry(
            string currentCountry,
            List<Country> countries,
            decimal[] result
        )
        {
            var settings = new ApplicationSettings(countries, currentCountry);

            Assert.Equal(result, settings.GetDenominationsForCurrentCountry());
        }
        
        [Theory]
        [MemberData(nameof(InvalidTestData))]
        public void ShouldThrowExceptionOnGetDenominationsForCurrentCountry(
            string currentCountry,
            List<Country> countries
        )
        {
            var settings = new ApplicationSettings(countries, currentCountry);

            Action a = () => settings.GetDenominationsForCurrentCountry();
            
            Assert.Throws<CountryNotFoundException>(a);
        }

        #region ValidTestData

        public static IEnumerable<object[]> ValidTestData()
        {
            yield return new object[]
            {
                "US",
                new List<Country>()
                {
                    new Country("US", new[] { 0.50m, 1, 5 }),
                    new Country("UK", new[] { 0.20m, 1, 5, 10 }),
                    new Country("IT", new[] { 0.10m, 1, 3, 5 }),
                },
                new[] { 0.50m, 1, 5 },
            };
            
            yield return new object[]
            {
                "IT",
                new List<Country>()
                {
                    new Country("US", new[] { 0.50m, 1, 5 }),
                    new Country("UK", new[] { 0.20m, 1, 5, 10 }),
                    new Country("IT", new[] { 0.10m, 1, 3, 5 }),
                },
                new[] { 0.10m, 1, 3, 5 },
            };
        }

        #endregion

        #region InvalidTestData

        public static IEnumerable<object[]> InvalidTestData()
        {
            yield return new object[]
            {
                "US",
                new List<Country>()
                {
                    new Country("UK", new[] { 0.20m, 1, 5, 10 }),
                    new Country("IT", new[] { 0.10m, 1, 3, 5 }),
                },
            };
            
            yield return new object[]
            {
                "IT",
                new List<Country>()
                {
                    new Country("US", new[] { 0.50m, 1, 5 }),
                    new Country("UK", new[] { 0.20m, 1, 5, 10 }),
                },
            };
        }

        #endregion
    }
}