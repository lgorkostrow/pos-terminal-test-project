using System.Collections.Generic;
using PosTerminal.Console.Attributes;
using PosTerminal.Console.Models;
using Xunit;

namespace PosTerminal.Console.Test.Attributes
{
    public class SumValidationAttributeTest
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void ShouldCheckIsValid(object? price, bool result)
        {
            var attribute = new SumValidationAttribute("message");

            Assert.Equal(result, attribute.IsValid(price));
        }

        #region TestData

        public static IEnumerable<object?[]> TestData()
        {
            yield return new object?[]
            {
                new InputData(new decimal[] { 1, 2, 5, 10 }, 10, new decimal[] { 5, 2, 10 }),
                true,
            };

            yield return new object?[]
            {
                new InputData(new decimal[] { 1, 2, 5, 10 }, 10, new decimal[] { 5, 5 }),
                true,
            };

            yield return new object?[]
            {
                new InputData(new decimal[] { 1, 2, 5, 10 }, 10, new decimal[] { 5, 2}),
                false,
            };

            yield return new object?[]
            {
                null,
                false,
            };
        }

        #endregion
    }
}