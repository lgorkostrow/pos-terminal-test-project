using System;
using System.Collections.Generic;
using PosTerminal.Core.Exceptions;
using PosTerminal.Core.Services;
using Xunit;

namespace PosTerminal.Core.Test.Services
{
    public class CoinChangeServiceTest
    {
        [Theory]
        [MemberData(nameof(ValidTestData))]
        public void ShouldReturnDenominations(decimal[] availableDenominations, decimal change, decimal[] result)
        {
            var service = new CoinChangeService();

            Assert.Equal(result, service.Calculate(availableDenominations, change));
        }

        [Fact]
        public void ShouldThrowExceptionOnEmptyDenominations()
        {
            var service = new CoinChangeService();

            Action a = () => service.Calculate(new decimal[] { }, 4.50m);

            Assert.Throws<NoAvailableDenominationsFoundException>(a);
        }

        #region ValidTestData

        public static IEnumerable<object[]> ValidTestData()
        {
            yield return new object[]
            {
                new[] { 0.01m, 0.05m, 0.10m, 0.25m, 0.50m, 1.00m, 2.00m, 5.00m, 10.00m, 20.00m, 50.00m, 100.00m },
                4.50m,
                new[] { 2.00m, 2.00m, 0.50m },
            };

            yield return new object[]
            {
                new[] { 0.01m, 0.05m, 0.10m, 0.25m, 0.50m, 1.00m, 2.00m, 5.00m, 10.00m, 20.00m, 50.00m, 100.00m },
                6.99m,
                new[] { 5.00m, 1.00m, 0.50m, 0.25m, 0.10m, 0.10m, 0.01m, 0.01m, 0.01m, 0.01m },
            };

            yield return new object[]
            {
                new[] { 0.01m, 0.05m, 0.10m, 0.25m, 0.50m, 1.00m, 2.00m, 5.00m, 10.00m, 20.00m, 50.00m, 100.00m },
                0m,
                System.Array.Empty<decimal>(),
            };
        }

        #endregion
    }
}