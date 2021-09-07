using System.Collections.Generic;
using PosTerminal.Console.Models;
using Xunit;

namespace PosTerminal.Console.Test.Models
{
    public class InputDataTest
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void ShouldReturnCorrectData(InputData inputData, decimal sum, decimal change)
        {
            Assert.Equal(sum, inputData.DenominationsSum);
            Assert.Equal(change, inputData.Change);
        }

        #region TestData

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[]
            {
                new InputData(new decimal[] { 1, 2, 5 }, 4.99m, new decimal[] { 5 }),
                5m,
                0.01m,
            };

            yield return new object[]
            {
                new InputData(new decimal[] { 1, 2, 5 }, 5.99m, new decimal[] { 5, 2 }),
                7m,
                1.01m,
            };
        }

        #endregion
    }
}