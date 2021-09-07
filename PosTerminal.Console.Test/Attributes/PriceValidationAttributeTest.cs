using System.Collections.Generic;
using PosTerminal.Console.Attributes;
using Xunit;

namespace PosTerminal.Console.Test.Attributes
{
    public class PriceValidationAttributeTest
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void ShouldCheckIsValid(object? price, bool result)
        {
            var attribute = new PriceValidationAttribute("message");

            Assert.Equal(result, attribute.IsValid(price));
        }

        #region TestData

        public static IEnumerable<object?[]> TestData()
        {
            yield return new object?[]
            {
                5m,
                true,
            };

            yield return new object?[]
            {
                4.99m,
                true,
            };

            yield return new object?[]
            {
                0m,
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