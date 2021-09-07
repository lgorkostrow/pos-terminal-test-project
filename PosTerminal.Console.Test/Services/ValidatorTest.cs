using System;
using System.Collections.Generic;
using PosTerminal.Console.Exceptions;
using PosTerminal.Console.Models;
using PosTerminal.Console.Services;
using Xunit;

namespace PosTerminal.Console.Test.Services
{
    public class ValidatorTest
    {
        [Theory]
        [MemberData(nameof(InvalidTestData))]
        public void ShouldThrowValidationException(InputData inputData)
        {
            var validator = new Validator();

            Action a = () => validator.Validate(inputData);

            Assert.Throws<ValidationException>(a);
        }
        
        [Fact]
        public void ShouldThrowArgumentException()
        {
            var validator = new Validator();

            Action a = () => validator.Validate<InputData>(null);

            Assert.Throws<ArgumentNullException>(a);
        }

        [Fact]
        public void ShouldPassValidation()
        {
            var validator = new Validator();
            var inputData = new InputData(new decimal[] { 1, 2, 5 }, 10, new decimal[] { 5, 5 });

            validator.Validate(inputData);
        }

        #region InvalidTestData

        public static IEnumerable<object[]> InvalidTestData()
        {
            yield return new object[]
            {
                new InputData(new decimal[] { 10 }, 0, new decimal[] { 10 })
            };

            yield return new object[]
            {
                new InputData(new decimal[] { 1, 5, 20 }, 10, new decimal[] { 10 })
            };

            yield return new object[]
            {
                new InputData(new decimal[] { 1, 5, 20 }, 20, new decimal[] { 5 })
            };
        }

        #endregion
    }
}